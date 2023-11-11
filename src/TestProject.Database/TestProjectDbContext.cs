using Microsoft.EntityFrameworkCore;

namespace TestProject.Database
{
    public class TestProjectDbContext : DbContext
    {
        // settings and options are in DI in .Web/Program.cs
        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}