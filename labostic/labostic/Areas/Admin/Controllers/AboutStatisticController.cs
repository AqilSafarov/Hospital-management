using Labostic.Models;
using Labostic.Services;
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

    public class AboutStatisticController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAboutStatistic _aboutStatistic;

        public AboutStatisticController(AppDbContext context, IAboutStatistic aboutStatistic)
        {
            _context = context;
            _aboutStatistic = aboutStatistic;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "AboutStatistic";

            List<AboutStatistic> aboutStatistic1 = _aboutStatistic.GetAboutStatistics();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(aboutStatistic1.Count / dataPage);

            List<AboutStatistic> aboutStatistic2 = aboutStatistic1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = aboutStatistic1.Count;
            return View(aboutStatistic2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AboutStatistic model)
        {
            if (ModelState.IsValid)
            {
                _aboutStatistic.CreateAboutStatistic(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? aboutstatisticId)
        {
            if (aboutstatisticId == null && aboutstatisticId <= 0)
            {
                return NotFound();
            }
            AboutStatistic aboutStatistic = _aboutStatistic.GetAboutStatistic(aboutstatisticId);
            return View(aboutStatistic);
        }
        [HttpPost]
        public IActionResult Update(AboutStatistic model)
        {
            if (ModelState.IsValid)
            {
                _aboutStatistic.UpdateAboutStatistic(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int aboutstatisticId)
        {
            _aboutStatistic.DeleteAboutStatistic(aboutstatisticId);

            return RedirectToAction("Index");
        }
    }
}
