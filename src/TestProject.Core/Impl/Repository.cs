using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;
using TestProject.Database;

namespace TestProject.Core.Impl
{
    public record Repository(TestProjectDbContext DbContext) : IWriter
    {
        public async Task<IEnumerable<Employee>> Write(IEnumerable<Employee> records)
        {
            var recievedRecords = records.ToArray();
            await DbContext.Employees.AddRangeAsync(recievedRecords);
            await DbContext.SaveChangesAsync();
            return recievedRecords;
        }
    }
}
