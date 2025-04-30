using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Project.Models.Database;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ProjectDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PlaceController(ProjectDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var places = _context.Places.Include(p => p.Types).ToList();
            return View(places);
        }

        public IActionResult Details(int id)
        {
            var place = _context.Places
                .Include(p => p.Reviews).ThenInclude(r => r.User)
                .Include(p => p.Types)
                .FirstOrDefault(p => p.Id == id);

            return place == null ? NotFound() : View(place);
        }

        [Authorize]
        public IActionResult Create() => View();

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(string name, string shortDescription, string fullDescription, string types, IFormFile image)
        {
            // Создание нового объекта Place
            var place = new PlaceData
            {
                Name = name,
                ShortDescription = shortDescription,
                FullDescription = fullDescription
            };

            // Обработка типов
            if (!string.IsNullOrWhiteSpace(types))
            {
                var typeNames = types.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(t => t.Trim()).Distinct();

                foreach (var typeName in typeNames)
                {
                    var existing = _context.Types.FirstOrDefault(t => t.Name == typeName);
                    place.Types.Add(existing ?? new TypeData { Name = typeName });
                }
            }

            // Обработка изображения
            if (image != null && image.Length > 0)
            {
                // Генерация уникального имени файла
                var imageFileName = Path.GetFileNameWithoutExtension(image.FileName);
                var extension = Path.GetExtension(image.FileName);
                var uniqueFileName = $"{imageFileName}_{System.Guid.NewGuid()}{extension}";

                // Путь, куда будет сохранено изображение
                var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", uniqueFileName);

                // Сохранение файла на сервере
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Сохранение пути к изображению в базе данных
                place.ImagePath = "/images/" + uniqueFileName;
            }

            // Добавляем новое место в базу данных
            _context.Places.Add(place);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddReview(int placeId, string text)
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            var review = new ReviewData
            {
                PlaceId = placeId,
                UserId = userId,
                Text = text
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = placeId });
        }
    }
}
