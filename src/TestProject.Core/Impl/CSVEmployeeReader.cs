using CsvHelper;
using System.Globalization;
using TestProject.Core.Models;
using IEmployeeReader = TestProject.Core.Interfaces.IEmployeeReader; // ambiguity with CSVHelper

namespace TestProject.Core.Impl
{
    public class CSVEmployeeReader : IEmployeeReader
    {
        /// <summary>
        /// Parses csv employee data from a srteam
        /// </summary>
        /// <param name="stream"></param>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an <see cref="EmployeeRecords"/> object
        /// that stores all the information that is required to perform the action.
        /// The query represented by this method is not executed until the object is enumerated by calling
        /// its <see cref="IEnumerable{T}.GetEnumerator"/> method.
        /// </remarks>
        /// <returns>A parsed <see cref="EmployeeRecords"/> one by one </returns>
        public IEnumerable<EmployeeRecords> Read(Stream stream)
            => ReadInternal(new StreamReader(stream));

        internal IEnumerable<EmployeeRecords> ReadInternal(TextReader reader)
        {
            using (reader)
            //"en-GB" because of European date format in .csv
            using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB")))
            {
                var result = csv.GetRecords<EmployeeRecords>();
                foreach (var parsed in result)
                {
                    yield return parsed;
                }
            }
        }
    }
}