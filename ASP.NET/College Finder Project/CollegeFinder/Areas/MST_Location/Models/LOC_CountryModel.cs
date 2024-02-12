using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeFinder.Areas.MST_Location.Models
{
    public class LOC_CountryModel
    {
        public int? CountryID { get; set; }

        [Required]
        [DisplayName("Country Name")]
        public string CountryName { get; set; } = string.Empty;

        [DisplayName("Country Code")]
        public string? CountryCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set;}
    }
}
