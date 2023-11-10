using TestProject.Core.Interfaces;
using TestProject.Database;

namespace TestProject.Core.Impl
{
    public record EmployeeRepository(TestProjectDbContext DbContext) : IEmployeeWriter
    {
        public async Task<IEnumerable<Employee>> Write(IEnumerable<Employee> records)
        {
            var recievedRecords = records.ToArray();
            await DbContext.Employees.AddRangeAsync(recievedRecords);
            await DbContext.SaveChangesAsync();
            return recievedRecords;
        }
    }
}
