using Microsoft.EntityFrameworkCore;
using ValleyProject.Models;

namespace ValleyProject.ApplicationConnection
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Peoples> peoples { get; set; }

    }
}
