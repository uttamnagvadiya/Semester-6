using System.ComponentModel.DataAnnotations;

namespace CollegeFinder.Areas.MST_Users.Models
{
    public class MST_UserLoginModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
