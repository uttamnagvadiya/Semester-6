using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeFinder.Areas.INS_College.Models
{
    public class INS_CollegeModel
    {
        public int? CollegeID { get; set; }

        [Required]
        [DisplayName("Logo Link")]
        public string CollegeLogo { get; set; } = string.Empty;

        [Required]
        [DisplayName("Name")]
        public string CollegeName { get; set; } = string.Empty;

        [Required]
        [DisplayName("Short Name")]
        public string CollegeShortName { get; set; } = string.Empty;

        [Required]
        [DisplayName("Description")]
        public string CollegeDescription { get; set; } = string.Empty;

        [Required]
        [DisplayName("College Type")]
        public int CollegeTypeID { get; set; }

        public string CollegeTypeName { get; set; } = string.Empty;

        [Required]
        [DisplayName("About Courses")]
        public string AboutCourses { get; set; } = string.Empty;

        [Required]
        [DisplayName("About Placement")]
        public string AboutPlacement { get; set; } = string.Empty;

        [Required]
        [DisplayName("Appr. Organization Name")]
        public int ApprovalID { get; set; }

        public string ApprovalName { get; set; } = string.Empty;

        public string ApprovalShortName { get; set; } = string.Empty;

        public int? Established { get; set; }

        [Required(ErrorMessage = "Checked If it is University or not")]
        public bool IsUniversity { get; set; } = false;

        public string? CampusType { get; set; }

        public string? CampusArea { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DisplayName("Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [DisplayName("Website Name")]
        public string Website { get; set; } = string.Empty;

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [DisplayName("City Name")]
        public int CityID { get; set; }

        public string CityName { get; set; } = string.Empty;

        public int StateID { get; set; }

        public string StateName { get; set; } = string.Empty;

        public int CountryID { get; set; }

        public string CountryName { get; set; } = string.Empty;
    }
}
