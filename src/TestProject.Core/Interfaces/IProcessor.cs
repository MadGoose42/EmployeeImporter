using TestProject.Core.Models;
using TestProject.Database;

namespace TestProject.Core.Interfaces
{
    internal interface IProcessor
    {
        Task<IEnumerable<Employee>> Process(Stream stream);
    }
}