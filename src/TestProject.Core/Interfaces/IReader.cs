using TestProject.Core.Models;

namespace TestProject.Core.Interfaces
{
    public interface IReader
    {
        IEnumerable<EmployeeRecords> Read(Stream stream);
    }
}