using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TestProject.Core.Impl;
using TestProject.Database;

namespace TestProject.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public async Task ImportWorks()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TestProjectDbContext>()
                .UseInMemoryDatabase("Test")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var context = new TestProjectDbContext(options);
            var repo = new Repository(context);
            //var employees = ;

            //Act

            var writtenData = await repo.Write(
                new Employee[]
                {
                    new Employee
                    {
                        Id = 0,
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
                    }
                });

            //Assert
            writtenData.Should().BeEquivalentTo(
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
                    }
                });
        }
    }
}