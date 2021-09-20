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

    public class AboutSignController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAboutSign _aboutSign;

        public AboutSignController(AppDbContext context,IAboutSign aboutSign)
        {
            _context = context;
            _aboutSign = aboutSign;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "AboutSign";

            List<AboutSign> aboutSign1 = _aboutSign.GetAboutSigns();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(aboutSign1.Count / dataPage);

            List<AboutSign> aboutSign2 = aboutSign1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = aboutSign1.Count;
            return View(aboutSign2);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(AboutSign model)
        {
            if (ModelState.IsValid)
            {
                _aboutSign.CreateAboutSign(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? aboutsignId)
        {
            if (aboutsignId == null && aboutsignId <= 0)
            {
                return NotFound();
            }
            AboutSign aboutSign = _aboutSign.GetAboutSign(aboutsignId);
            return View(aboutSign);
        }
        [HttpPost]
        public IActionResult Update(AboutSign model)
        {
            if (ModelState.IsValid)
            {
                _aboutSign.UpdateAboutSign(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int aboutsignId)
        {
            _aboutSign.DeleteAboutSign(aboutsignId);

            return RedirectToAction("Index");
        }

    }
}
