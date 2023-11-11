using FluentAssertions;
using TestProject.Core.Impl;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;
using TestProject.Database;

namespace TestProject.Tests
{
    public class ProcessorTests
    {
        [Fact]
        public async Task ProcessorWorks()
        {
            //Arrange
            var streamMock = Stream.Null;
            var reader = new ReaderMock();
            var writer = new WriterMock();
            var processor = new EmployeeProcessor(reader, writer);


            //Act
            var result = await processor.Process(streamMock);

            //Assert
            result.Should().BeEquivalentTo(
                // exprcted result ( unsorted, because sorting after writing)
                new Employee[]
                {
                    new Employee
                    {
                        Id = 1,
                        Personnel_Records_Payroll_Number = "COOP08",
                        Personnel_Records_Forenames = "John ",
                        Personnel_Records_Surname = "William",
                        Personnel_Records_Date_of_Birth = new DateTime(1955, 01, 26),
                        Personnel_Records_Telephone = "12345678",
                        Personnel_Records_Mobile = "987654231",
                        Personnel_Records_Address = "12 Foreman road",
                        Personnel_Records_Address_2 = "London",
                        Personnel_Records_Postcode = "GU12 6JW",
                        Personnel_Records_EMail_Home = "nomadic20@hotmail.co.uk",
                        Personnel_Records_Start_Date = new DateTime(2013, 04, 18),
                    },
                    new Employee()
                    {
                        Id = 2,
                        Personnel_Records_Payroll_Number = "JACK13",
                        Personnel_Records_Forenames = "Jerry",
                        Personnel_Records_Surname = "Jackson",
                        Personnel_Records_Date_of_Birth = new DateTime(1974, 05, 11),
                        Personnel_Records_Telephone = "2050508",
                        Personnel_Records_Mobile = "6987457",
                        Personnel_Records_Address = "115 Spinney Road",
                        Personnel_Records_Address_2 = "Luton",
                        Personnel_Records_Postcode = "LU33DF",
                        Personnel_Records_EMail_Home = "gerry.jackson@bt.com",
                        Personnel_Records_Start_Date = new DateTime(2013, 04, 18),
                    }
                });
        }
    }

    public class WriterMock : IEmployeeWriter
    {
        public async Task<IEnumerable<Employee>> Write(IEnumerable<Employee> records)
        {
            return WriteInternal(records);
        }
        // Imitates Id autogen
        public IEnumerable<Employee> WriteInternal(IEnumerable<Employee> records)
        {
            int k = 1;
            foreach (var employee in records)
            {
                employee.Id = k++;
                yield return employee;
            }
        }

    }
    public class ReaderMock : IEmployeeReader
    {
        // imitates reading unsorted rows
        public IEnumerable<EmployeeRecords> Read(Stream stream)
        {
            return new EmployeeRecords[]
            {
                    new EmployeeRecords
                    {
                        Personnel_Records_Payroll_Number = "COOP08",
                        Personnel_Records_Forenames = "John ",
                        Personnel_Records_Surname = "William",
                        Personnel_Records_Date_of_Birth = new DateTime(1955, 01, 26),
                        Personnel_Records_Telephone = "12345678",
                        Personnel_Records_Mobile = "987654231",
                        Personnel_Records_Address = "12 Foreman road",
                        Personnel_Records_Address_2 = "London",
                        Personnel_Records_Postcode = "GU12 6JW",
                        Personnel_Records_EMail_Home = "nomadic20@hotmail.co.uk",
                        Personnel_Records_Start_Date = new DateTime(2013, 04, 18),
                    },
                    new EmployeeRecords()
                    {
                        Personnel_Records_Payroll_Number = "JACK13",
                        Personnel_Records_Forenames = "Jerry",
                        Personnel_Records_Surname = "Jackson",
                        Personnel_Records_Date_of_Birth = new DateTime(1974, 05, 11),
                        Personnel_Records_Telephone = "2050508",
                        Personnel_Records_Mobile = "6987457",
                        Personnel_Records_Address = "115 Spinney Road",
                        Personnel_Records_Address_2 = "Luton",
                        Personnel_Records_Postcode = "LU33DF",
                        Personnel_Records_EMail_Home = "gerry.jackson@bt.com",
                        Personnel_Records_Start_Date = new DateTime(2013, 04, 18),
                    }
            };
        }
    }
}