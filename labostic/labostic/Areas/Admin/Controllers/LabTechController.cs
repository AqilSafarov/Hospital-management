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

    public class LabTechController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILabTech _labTech;

        public LabTechController(AppDbContext context,ILabTech labTech)
        {
            _context = context;
            _labTech = labTech;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "LabTech";

            List<LabTech> labTech1 = _labTech.GetLabTechs();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(labTech1.Count / dataPage);

            List<LabTech> labTech2 = labTech1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = labTech1.Count;
            return View(labTech2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LabTech model)
        {
            if (ModelState.IsValid)
            {
                _labTech.CreateLabTech(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? labtechId)
        {
            if (labtechId == null && labtechId <= 0)
            {
                return NotFound();
            }
            LabTech labTech = _labTech.GetLabTech(labtechId);
            return View(labTech);
        }
        [HttpPost]
        public IActionResult Update(LabTech model)
        {
            if (ModelState.IsValid)
            {
                _labTech.UpdateLabTech(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int labtechId)
        {
            _labTech.DeleteLabTech(labtechId);

            return RedirectToAction("Index");
        }

    }
}
