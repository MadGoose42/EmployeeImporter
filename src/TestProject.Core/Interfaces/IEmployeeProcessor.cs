using TestProject.Database;

namespace TestProject.Core.Interfaces
{
    public interface IEmployeeProcessor
    {
        Task<IEnumerable<Employee>> Process(Stream stream);
    }
}