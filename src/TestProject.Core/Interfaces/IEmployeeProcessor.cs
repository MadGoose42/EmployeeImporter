using TestProject.Database;

namespace TestProject.Core.Interfaces
{
    public interface IEmployeeProcessor
    {
        /// <summary>
        /// Writes data from a stream to DB
        /// </summary>
        /// <param name="stream"></param>
        /// <returns> Written data </returns>
        Task<IEnumerable<Employee>> Process(Stream stream);
    }
}