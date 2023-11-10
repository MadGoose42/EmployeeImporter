using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Web.Models
{
    public class UploadModel
    {
        [Required]
        [DisplayName(".csv file to import")]
        public IFormFile CsvFile { get; set; }
    }
}
