using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Grades.Models;

namespace Grades.Controllers
{
    public class ActivitiesController : Controller
    {
        private static List<Activity> _activities => Activity.DefaultActivities;
        private static List<Subject> _subjects => Subject.DefaultSubjects;

        // GET: Activities/Index
        public IActionResult Index()
        {
            return View(_activities);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            PopulateSubjectsDropdown();
            return View();
        }

        // POST: Activities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.Id = _activities.Any() ? _activities.Max(a => a.Id) + 1 : 1;
                _activities.Add(activity);
                return RedirectToAction("Index", "Home");
            }

            PopulateSubjectsDropdown();
            return View(activity);
        }

        // GET: Activities/Edit
        public IActionResult Edit(int id)
        {
            var activity = _activities.FirstOrDefault(a => a.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            PopulateSubjectsDropdown();
            return View(activity);
        }

        // POST: Activities/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingActivity = _activities.FirstOrDefault(a => a.Id == id);
                if (existingActivity == null)
                {
                    return NotFound();
                }

                existingActivity.SubjectId = activity.SubjectId;
                existingActivity.Type = activity.Type;
                existingActivity.Grade = activity.Grade;
                existingActivity.Date = activity.Date;

                return RedirectToAction("Index", "Home");
            }

            PopulateSubjectsDropdown();
            return View(activity);
        }

        // GET: Activities/Delete
        public IActionResult Delete(int id)
        {
            var activity = _activities.FirstOrDefault(a => a.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var activity = _activities.FirstOrDefault(a => a.Id == id);
            if (activity != null)
            {
                _activities.Remove(activity);
            }

            return RedirectToAction("Index", "Home");
        }

        private void PopulateSubjectsDropdown()
        {
            ViewBag.Subjects = _subjects.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
        }
    }
}