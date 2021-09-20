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

    public class HomeCircleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHomeCircle _homeCircle;

        public HomeCircleController(AppDbContext context,IHomeCircle homeCircle)
        {
            _context = context;
            _homeCircle = homeCircle;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "HomeCircle";

            List<HomeCircle> homeCircle1 = _homeCircle.GetHomeCircles();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(homeCircle1.Count / dataPage);

            List<HomeCircle> homeCircle2 = homeCircle1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = homeCircle1.Count;
            return View(homeCircle2);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(HomeCircle model)
        {
            if (ModelState.IsValid)
            {
                _homeCircle.CreateHomeCircle(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? homecircleId)
        {
            if (homecircleId == null && homecircleId <= 0)
            {
                return NotFound();
            }
            HomeCircle homeCircle = _homeCircle.GetHomeCircle(homecircleId);
            return View(homeCircle);
        }
        [HttpPost]
        public IActionResult Update(HomeCircle model)
        {
            if (ModelState.IsValid)
            {
                _homeCircle.UpdateHomeCircle(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int homecircleId)
        {
            _homeCircle.DeleteHomeCircle(homecircleId);

            return RedirectToAction("Index");
        }
    }
}
