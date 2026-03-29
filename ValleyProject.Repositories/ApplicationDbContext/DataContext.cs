using Microsoft.EntityFrameworkCore;
using ValleyProject.Entities.Model;


namespace DataAccessLayer.ApplicationDbContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

    }
}
