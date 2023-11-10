using System.Text.Json.Serialization;

namespace TestProject.Database
{
    public class Employee
    {
        public int Id { get; set; }
        [JsonPropertyName("payroll_Number")]
        public string Personnel_Records_Payroll_Number { get; set; }
        [JsonPropertyName("forenames")]
        public string Personnel_Records_Forenames { get; set; }
        [JsonPropertyName("surname")]
        public string Personnel_Records_Surname { get; set; }
        [JsonPropertyName("date_of_Birth")]
        public DateTimeOffset Personnel_Records_Date_of_Birth { get; set; }
        [JsonPropertyName("telephone")]
        public string Personnel_Records_Telephone { get; set; }
        [JsonPropertyName("mobile")]
        public string Personnel_Records_Mobile { get; set; }
        [JsonPropertyName("address")]
        public string Personnel_Records_Address { get; set; }
        [JsonPropertyName("address_2")]
        public string Personnel_Records_Address_2 { get; set; }
        [JsonPropertyName("postcode")]
        public string Personnel_Records_Postcode { get; set; }
        [JsonPropertyName("eMail_Home")]
        public string Personnel_Records_EMail_Home { get; set; }
        [JsonPropertyName("start_Date")]
        public DateTimeOffset Personnel_Records_Start_Date { get; set; }
    }
}