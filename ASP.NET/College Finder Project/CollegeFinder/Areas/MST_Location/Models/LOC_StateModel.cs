using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeFinder.Areas.MST_Location.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }

        [Required]
        [DisplayName("State Name")]
        public string StateName { get; set; } = string.Empty;

        [DisplayName("State Code")]
        public string? StateCode { get; set; }

        [Required]
        [DisplayName("Country Name")]
        public int CountryID { get; set; }

        public string CountryName { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
