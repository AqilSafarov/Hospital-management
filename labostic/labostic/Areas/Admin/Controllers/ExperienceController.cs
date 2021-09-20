using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class ExperienceController : Controller
    {
        private readonly IExperience _experiance;

        public ExperienceController(IExperience experiance)
        {
            _experiance = experiance;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Experience";

            List<Experience> experience1 = _experiance.GetExperiences();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(experience1.Count / dataPage);

            List<Experience> experience2 = experience1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = experience1.Count;
            return View(experience2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience model)
        {
            if (ModelState.IsValid)
            {
                _experiance.CreateExperience(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? experienceId)
        {
            if (experienceId == null && experienceId <= 0)
            {
                return NotFound();
            }
            Experience experience = _experiance.GetExperience(experienceId);
            return View(experience);
        }
        [HttpPost]
        public IActionResult Update(Experience model)
        {
            if (ModelState.IsValid)
            {
                _experiance.UpdateExperience(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int experienceId)
        {
            _experiance.DeleteExperience(experienceId);

            return RedirectToAction("Index");
        }
    }
}
