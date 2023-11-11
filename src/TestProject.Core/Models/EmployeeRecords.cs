using CsvHelper.Configuration.Attributes;

namespace TestProject.Core.Models
{
    public class EmployeeRecords
    {
        // Representation of parsed csv rows

        [Name("Personnel_Records.Payroll_Number")]
        public string Personnel_Records_Payroll_Number { get; set; }
        [Name("Personnel_Records.Forenames")]
        public string Personnel_Records_Forenames { get; set; }
        [Name("Personnel_Records.Surname")]
        public string Personnel_Records_Surname { get; set; }
        [Name("Personnel_Records.Date_of_Birth")]
        public DateTimeOffset Personnel_Records_Date_of_Birth { get; set; }
        [Name("Personnel_Records.Telephone")]
        public string Personnel_Records_Telephone { get; set; }
        [Name("Personnel_Records.Mobile")]
        public string Personnel_Records_Mobile { get; set; }
        [Name("Personnel_Records.Address")]
        public string Personnel_Records_Address { get; set; }
        [Name("Personnel_Records.Address_2")]
        public string Personnel_Records_Address_2 { get; set; }
        [Name("Personnel_Records.Postcode")]
        public string Personnel_Records_Postcode { get; set; }
        [Name("Personnel_Records.EMail_Home")]
        public string Personnel_Records_EMail_Home { get; set; }
        [Name("Personnel_Records.Start_Date")]
        public DateTimeOffset Personnel_Records_Start_Date { get; set; }

    }
}
