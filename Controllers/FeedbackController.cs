using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StudentFeedback.Models;

namespace StudentFeedback.Controllers
{
    public class FeedbackController : Controller
    {
        // Temporary storage for submitted feedback.
        private static readonly List<Feedback> feedbackList =
            new List<Feedback>();

        // 1. Home page
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // 2. Display feedback form
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Feedback());
        }

        // 3. Display all feedback
        [HttpGet]
        public ActionResult List()
        {
            return View(feedbackList.ToList());
        }

        // 4. Submit feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);

                return RedirectToAction("List");
            }

            return View(feedback);
        }
    }
}