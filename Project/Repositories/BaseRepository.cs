using Microsoft.EntityFrameworkCore;
using Project.Models.Database;

namespace Project.Repositories
{
    public abstract class BaselRepository<TDbModel> where TDbModel : BaseModel
    {
        protected ProjectDbContext _dbContext;
        protected DbSet<TDbModel> _dbSet;

        public BaselRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TDbModel>();
        }

        public virtual TDbModel Get(int id)
        {
            return _dbSet
                .AsNoTracking()
                .First(x => x.Id == id);
        }

        public virtual List<TDbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Add(TDbModel item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }

        public virtual void Remove(int id)
        {
            var item = _dbSet.FirstOrDefault(x => x.Id == id);
            _dbSet.Remove(item);
            _dbContext.SaveChanges();
        }

        public virtual void Update(TDbModel model)
        {
            _dbSet.Update(model);
            _dbContext.SaveChanges();
        }
    }
}
