using Project.Models.Database;

namespace Project.Repositories
{
    public class TypeRepository : BaselRepository<TypeData>
    {
        public TypeRepository(ProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}
