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

    public class ResearchSquarController : Controller
    {
        private readonly IResearchSquar _researchSquar;

        public ResearchSquarController(IResearchSquar researchSquar)
        {
            _researchSquar = researchSquar;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "ResearchSquar";

            List<ResearchSquar> researchSquar1 = _researchSquar.GetResearchSquars();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(researchSquar1.Count / dataPage);

            List<ResearchSquar> researchSquar2 = researchSquar1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = researchSquar1.Count;
            return View(researchSquar2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ResearchSquar model)
        {
            if (ModelState.IsValid)
            {
                _researchSquar.CreateResearchSquar(model);

                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? researchsquarId)
        {
            if (researchsquarId == null && researchsquarId <= 0)
            {
                return NotFound();
            }
            ResearchSquar researchSquar = _researchSquar.GetResearchSquar(researchsquarId);
            return View(researchSquar);
        }
        [HttpPost]
        public IActionResult Update(ResearchSquar model)
        {
            if (ModelState.IsValid)
            {
                _researchSquar.UpdateResearchSquar(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int researchsquarId)
        {
            _researchSquar.DeleteResearchSquar(researchsquarId);

            return RedirectToAction("Index");
        }
    }
}

