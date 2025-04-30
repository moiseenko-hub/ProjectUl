using Microsoft.AspNetCore.Identity;
using Project.Models.Database;

namespace Project
{
    public static class DbSeeder
    {
        public static void Seed(ProjectDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<UserData>
                {
                    new() { Username = "admin", PasswordHash = "admin123" },
                    new() { Username = "user1", PasswordHash = "user123" },
                    new() { Username = "user2", PasswordHash = "123456" }
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.Types.Any())
            {
                var types = new List<TypeData>
                {
                    new() { Name = "Культура" },
                    new() { Name = "Природа" },
                    new() { Name = "История" },
                    new() { Name = "Развлечения" }
                };
                context.Types.AddRange(types);
                context.SaveChanges();
            }

            if (!context.Places.Any())
            {
                var types = context.Types.ToList();

                var places = new List<PlaceData>
                {
                    new()
                    {
                        Name = "Эйфелева башня",
                        ShortDescription = "Знаменитая башня в Париже",
                        FullDescription = "Символ Франции и одно из самых узнаваемых зданий в мире.",
                        ImagePath = CopyImage("test.jpeg"),
                        Types = new List<TypeData> { types.First(t => t.Name == "Культура"), types.First(t => t.Name == "История") }
                    },
                    new()
                    {
                        Name = "Большой каньон",
                        ShortDescription = "Огромный каньон в Аризоне",
                        FullDescription = "Одно из природных чудес света.",
                        ImagePath = CopyImage("test.jpeg"),
                        Types = new List<TypeData> { types.First(t => t.Name == "Природа") }
                    },
                    new()
                    {
                        Name = "Диснейленд",
                        ShortDescription = "Тематический парк развлечений",
                        FullDescription = "Парк, где сбываются мечты детей и взрослых.",
                        ImagePath = CopyImage("test.jpeg"),
                        Types = new List<TypeData> { types.First(t => t.Name == "Развлечения") }
                    }
                };

                context.Places.AddRange(places);
                context.SaveChanges();
            }

            if (!context.Reviews.Any())
            {
                var users = context.Users.ToList();
                var places = context.Places.ToList();

                var reviews = new List<ReviewData>
                {
                    new() { PlaceId = places[0].Id, UserId = users[0].Id, Text = "Нереально красиво!" },
                    new() { PlaceId = places[1].Id, UserId = users[1].Id, Text = "Впечатляет масштаб!" },
                    new() { PlaceId = places[2].Id, UserId = users[2].Id, Text = "Дети были в восторге!" }
                };

                context.Reviews.AddRange(reviews);
                context.SaveChanges();
            }
        }

        private static string CopyImage(string fileName)
        {
            var source = Path.Combine(Directory.GetCurrentDirectory(), "SeedImages", fileName);
            var destinationDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            var destination = Path.Combine(destinationDir, fileName);

            if (!Directory.Exists(destinationDir))
                Directory.CreateDirectory(destinationDir);

            if (File.Exists(source) && !File.Exists(destination))
                File.Copy(source, destination);

            return "/images/" + fileName;
        }
    }
}
