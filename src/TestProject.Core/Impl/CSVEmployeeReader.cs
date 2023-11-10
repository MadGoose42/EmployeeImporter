using CsvHelper;
using System.Globalization;
using TestProject.Core.Models;
using IEmployeeReader = TestProject.Core.Interfaces.IEmployeeReader; // ambiguity with CSVHelper

namespace TestProject.Core.Impl
{
    public class CSVEmployeeReader : IEmployeeReader
    {
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