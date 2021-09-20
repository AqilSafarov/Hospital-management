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

    public class WriterController : Controller
    {
        private readonly IWriter _writer;

        public WriterController(IWriter writer)
        {
            _writer = writer;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Writer";

            List<Writer> writer1 = _writer.GetWriters();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(writer1.Count / dataPage);

            List<Writer> writer2 = writer1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = writer1.Count;
            return View(writer2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Writer model)
        {
            if (ModelState.IsValid)
            {
                _writer.CreateWriter(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? writerId)
        {
            if (writerId == null && writerId <= 0)
            {
                return NotFound();
            }
            Writer writer = _writer.FindWriter(writerId);
            return View(writer);
        }
        [HttpPost]
        public IActionResult Update(Writer model)
        {
            if (ModelState.IsValid)
            {
                _writer.UpdateWriter(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int writerId)
        {
            _writer.DeleteWriter(writerId);

            return RedirectToAction("Index");
        }
    }
}
