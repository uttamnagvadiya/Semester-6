namespace CollegeFinder.Areas.INS_Course.Models
{
    public class INS_CourseModel
    {
        public int? CourseID { get; set; }

        public string? CourseLogo { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public string CourseShortName { get; set; } = string.Empty;

        public string CourseDefinition { get; set; } = string.Empty;    

        public string CourseDescription { get; set; } = string.Empty;

        public bool IsYearly { get; set; }

        public string CourseDuration { get; set; } = string.Empty;

        public string CourseFees { get; set; } = string.Empty;

        public int? StreamID { get; set; }

        public string StreamName { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
