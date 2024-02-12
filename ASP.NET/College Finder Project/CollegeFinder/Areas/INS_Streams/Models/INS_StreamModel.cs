namespace CollegeFinder.Areas.INS_Streams.Models
{
    public class INS_StreamModel
    {
        public int StreamID { get; set; }

        public string StreamName { get; set; } = string.Empty;

        public string StreamDescription { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set;}
    }
}
