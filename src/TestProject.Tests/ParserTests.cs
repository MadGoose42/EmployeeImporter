using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.WebSockets;
using TestProject.Core.Impl;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;
using TestProject.Database;

namespace TestProject.Tests
{
    public class ParserTests
    {
        [Fact]
        public void TypeParseTest()
        {
            //Arrange
            var reader = new CSVReader();
            var content = """
                Personnel_Records.Payroll_Number,Personnel_Records.Forenames,Personnel_Records.Surname,Personnel_Records.Date_of_Birth,Personnel_Records.Telephone,Personnel_Records.Mobile,Personnel_Records.Address,Personnel_Records.Address_2,Personnel_Records.Postcode,Personnel_Records.EMail_Home,Personnel_Records.Start_Date
                COOP08,John ,William,26/01/1955,12345678,987654231,12 Foreman road,London,GU12 6JW,nomadic20@hotmail.co.uk,18/04/2013
                JACK13,Jerry,Jackson,11/5/1974,2050508,6987457,115 Spinney Road,Luton,LU33DF,gerry.jackson@bt.com,18/04/2013
                """;
            var mockedReader = MockReader(content);


            //Act
            var parsed = reader.ReadInternal(mockedReader).ToArray();

            //Assert
            var expected = new EmployeeRecords[]
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
            parsed.Should().BeEquivalentTo(expected);
        }
        private TextReader MockReader(string content) => new StringReader(content);
    }

    public class ProcessorTests
    {
        [Fact]
        public async Task ProcessorWorks()
        {


            //var options = new DbContextOptionsBuilder<TestProjectDbContext>()
            //    .UseInMemoryDatabase("Test")
            //    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            //    .Options;
            //var context = new TestProjectDbContext(options);


            //Arrange
            var streamMock = Stream.Null;
            var reader = new ReaderMock();
            var writer = new WriterMock();
            var processor = new Processor(reader, writer);


            //Act

            var result = await processor.Process(streamMock);

            //Assert
            result.Should().BeEquivalentTo(
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
    
    public class WriterMock : IWriter
    {
        public async Task<IEnumerable<Employee>> Write(IEnumerable<Employee> records)
        {
            int k = 1;
            foreach (var employee in records)
            {
                employee.Id = k++;
            }
            return records;
        }

    }
    public class ReaderMock : IReader
    {
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