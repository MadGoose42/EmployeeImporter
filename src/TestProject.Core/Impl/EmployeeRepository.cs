using TestProject.Core.Interfaces;
using TestProject.Database;

namespace TestProject.Core.Impl
{
    public record EmployeeRepository(TestProjectDbContext DbContext) : IEmployeeWriter
    {
        /// <summary>
        /// Wrires data to DB
        /// </summary>
        /// <param name="records"></param>
        /// <returns> Written data </returns>
        public async Task<IEnumerable<Employee>> Write(IEnumerable<Employee> records)
        {
            var recievedRecords = records.ToArray();
            await DbContext.Employees.AddRangeAsync(recievedRecords);
            await DbContext.SaveChangesAsync();
            return recievedRecords;
        }
    }
}
