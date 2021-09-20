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
    public class WhyChooseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWhyChoose _whyChoose;

        public WhyChooseController(AppDbContext context, IWhyChoose whyChoose)
        {
            _context = context;
            _whyChoose = whyChoose;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "WhyChoose";

            List<WhyChoose> whyChoose1 = _whyChoose.GetWhyChooses();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(whyChoose1.Count / dataPage);

            List<WhyChoose> whyChoose2 = whyChoose1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = whyChoose1.Count;
            return View(whyChoose2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WhyChoose model)
        {
            if (ModelState.IsValid)
            {
                _whyChoose.CreateWhyChoose(model);


                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? whychooseId)
        {
            if (whychooseId == null && whychooseId <= 0)
            {
                return NotFound();
            }
            WhyChoose whyChoose = _whyChoose.GetWhyChoose(whychooseId);
            return View(whyChoose);
        }
        [HttpPost]
        public IActionResult Update(WhyChoose model)
        {
            if (ModelState.IsValid)
            {
                _whyChoose.UpdateWhyChoose(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }
        public IActionResult Delete(int whychooseId)
        {
            _whyChoose.DeleteWhyChoose(whychooseId);

            return RedirectToAction("Index");
        }

    }
}
