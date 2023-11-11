using TestProject.Database;

namespace TestProject.Core.Interfaces
{
    public interface IEmployeeWriter
    {
        /// <summary>
        /// Wrires data to DB
        /// </summary>
        /// <param name="records"></param>
        /// <returns> Written data </returns>
        Task<IEnumerable<Employee>> Write(IEnumerable<Employee> Records);
    }
}