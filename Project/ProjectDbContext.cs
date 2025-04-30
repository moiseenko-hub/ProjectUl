using Microsoft.EntityFrameworkCore;
using Project.Models.Database;

namespace Project
{
    public class ProjectDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public ProjectDbContext() { }

        public DbSet<PlaceData> Places { get; set; }
        public DbSet<ReviewData> Reviews { get; set; }
        public DbSet<TypeData> Types { get; set; }
        public DbSet<UserData> Users {  get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> option) : base(option) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
