using Project.Models.Database;

namespace Project.Repositories
{
    public class PlaceRepository : BaselRepository<PlaceData>
    {
        public PlaceRepository(ProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}
