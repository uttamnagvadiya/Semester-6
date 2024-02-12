using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeFinder.Areas.MST_Users.Models
{
    public class MST_UserModel
    {
        public int? UserID { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public bool IsAdmin { get; set; } = false;

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
