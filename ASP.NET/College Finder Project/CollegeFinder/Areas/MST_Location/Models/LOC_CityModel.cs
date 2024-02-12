using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeFinder.Areas.MST_Location.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }

        [Required]
        [DisplayName("City Name")]
        public string CityName { get; set; } = string.Empty;

        [DisplayName("City Code")]
        public string? CityCode { get; set; }

        [Required]
        [DisplayName("State Name")]
        public int StateID { get; set; }

        public string StateName { get; set; } = string.Empty;

        public string? StateCode { get; set; }

        [Required]
        [DisplayName("Country Name")]
        public int? CountryID { get; set; }

        public string CountryName { get; set; } = string.Empty;

        public string? CountryCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set;}
    }
}
