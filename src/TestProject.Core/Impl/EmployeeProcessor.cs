using TestProject.Core.Interfaces;
using TestProject.Database;
using IEmployeeReader = TestProject.Core.Interfaces.IEmployeeReader;
using IEmployeeWriter = TestProject.Core.Interfaces.IEmployeeWriter;

namespace TestProject.Core.Impl
{
    public record EmployeeProcessor(IEmployeeReader Reader, IEmployeeWriter Writer) : IEmployeeProcessor
    {
        public async Task<IEnumerable<Employee>> Process(Stream stream)
        {
            var records = Reader.Read(stream);
            var employees = records.Select(rec => new Employee
            {
                Personnel_Records_Payroll_Number = rec.Personnel_Records_Payroll_Number,
                Personnel_Records_Forenames = rec.Personnel_Records_Forenames,
                Personnel_Records_Surname = rec.Personnel_Records_Surname,
                Personnel_Records_Date_of_Birth = rec.Personnel_Records_Date_of_Birth,
                Personnel_Records_Telephone = rec.Personnel_Records_Telephone,
                Personnel_Records_Mobile = rec.Personnel_Records_Mobile,
                Personnel_Records_Address = rec.Personnel_Records_Address,
                Personnel_Records_Address_2 = rec.Personnel_Records_Address_2,
                Personnel_Records_Postcode = rec.Personnel_Records_Postcode,
                Personnel_Records_EMail_Home = rec.Personnel_Records_EMail_Home,
                Personnel_Records_Start_Date = rec.Personnel_Records_Start_Date
            })
                .ToArray();
            //var mappedRecords = Mapper.Map<IEnumerable<Employee>>(records);
            var writtenRecords = await Writer.Write(employees);
            return writtenRecords.OrderBy(x => x.Personnel_Records_Surname);
        }
    }
}