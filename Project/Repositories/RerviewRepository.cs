using Project.Models.Database;

namespace Project.Repositories
{
    public class RerviewRepository : BaselRepository<ReviewData>
    {
        public RerviewRepository(ProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}
