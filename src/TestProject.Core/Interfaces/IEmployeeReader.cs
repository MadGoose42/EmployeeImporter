using TestProject.Core.Models;

namespace TestProject.Core.Interfaces
{
    public interface IEmployeeReader
    {
        /// <summary>
        /// Parses csv employee data from a srteam
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>Parsed csv data</returns>
        IEnumerable<EmployeeRecords> Read(Stream stream);
    }
}