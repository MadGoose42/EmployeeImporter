using Microsoft.EntityFrameworkCore;

namespace TestProject.Database
{
    public class TestProjectDbContext : DbContext
    {
        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options) : base(options)
        {
        }
        //public DBContext() { }

        public DbSet<Employee> Employees { get; set; }
    }
}