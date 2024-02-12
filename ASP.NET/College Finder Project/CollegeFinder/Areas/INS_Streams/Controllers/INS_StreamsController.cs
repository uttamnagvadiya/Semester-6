using CollegeFinder.Areas.INS_Streams.Models;
using CollegeFinder.BAL.INS_Streams;
using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Areas.INS_Streams.Controllers
{
    [Area("INS_Streams")]
    public class INS_StreamsController : Controller
    {
        INS_Streams_BAL streams_BAL = new INS_Streams_BAL();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutStream(int StreamID)
        {
            INS_StreamModel streamModel = streams_BAL.PR_SELECT_RECORD_BY_PK_INS_STREAMS(StreamID: StreamID);
            return View("AboutStream", streamModel);
        }
    }
}
