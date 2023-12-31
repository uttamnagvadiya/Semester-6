using System.ComponentModel.DataAnnotations;

namespace College_Finder.Areas.MST_User_Registration.Models
{
    public class MST_User_RegistratioModel
    {
        public int? UserID { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public bool IsAdmin { get; set; } = false;

        [Required]
        public bool IsActive { get; set;} = false;

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set;}

    }

    public class MST_User_LoginModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
