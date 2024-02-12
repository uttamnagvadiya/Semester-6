using CollegeFinder.Areas.INS_College.Models;
using CollegeFinder.Areas.INS_Streams.Models;

namespace CollegeFinder.Models
{
    public class ViewModel
    {
        public IEnumerable<INS_StreamModel> streamModelsList { get; set; }

        public IEnumerable<INS_CollegeModel> collegeModelsList { get; set; }
    }
}
