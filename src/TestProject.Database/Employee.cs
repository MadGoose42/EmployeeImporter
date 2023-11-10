namespace TestProject.Database
{
    public class Employee
    {
        public int Id { get; set; }
        public string Personnel_Records_Payroll_Number { get; set; }
        public string Personnel_Records_Forenames { get; set; }
        public string Personnel_Records_Surname { get; set; }
        public DateTimeOffset Personnel_Records_Date_of_Birth { get; set; }
        public string Personnel_Records_Telephone { get; set; }
        public string Personnel_Records_Mobile { get; set; }
        public string Personnel_Records_Address { get; set; }
        public string Personnel_Records_Address_2 { get; set; }
        public string Personnel_Records_Postcode { get; set; }
        public string Personnel_Records_EMail_Home { get; set; }
        public DateTimeOffset Personnel_Records_Start_Date { get; set; }
    }
}