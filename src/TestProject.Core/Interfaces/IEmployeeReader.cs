using TestProject.Core.Models;

namespace TestProject.Core.Interfaces
{
    public interface IEmployeeReader
    {
        IEnumerable<EmployeeRecords> Read(Stream stream);
    }
}