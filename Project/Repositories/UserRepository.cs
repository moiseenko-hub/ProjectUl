using Project.Models.Database;

namespace Project.Repositories
{
    public class UserRepository : BaselRepository<UserData>
    {
        public UserRepository(ProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}
