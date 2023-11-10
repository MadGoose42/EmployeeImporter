using TestProject.Core.Models;
using TestProject.Database;

namespace TestProject.Core.Interfaces
{
    public interface IWriter
    {
        Task<IEnumerable<Employee>> Write(IEnumerable<Employee> Records);
    }
}