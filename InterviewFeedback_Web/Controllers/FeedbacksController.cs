using InterviewFeedback_Web.HelperUtilities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace InterviewFeedback_Web.Controllers
{
    public class FeedbacksController : Controller
    {
        private FeedBackContext db = new FeedBackContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PerformFeedBackResultUpdate(string[] FeedbackResults)
        {
            HelperUtilities.HelperUtilities.PerformFeedBackResultUpdate(db, FeedbackResults);
            List<FeedbackSummary> feedbackSummary = HelperUtilities.HelperUtilities.GetFeedbackSummary(db);
            return Json(feedbackSummary);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
