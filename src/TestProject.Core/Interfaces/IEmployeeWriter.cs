using TestProject.Database;

namespace TestProject.Core.Interfaces
{
    public interface IEmployeeWriter
    {
        Task<IEnumerable<Employee>> Write(IEnumerable<Employee> Records);
    }
}