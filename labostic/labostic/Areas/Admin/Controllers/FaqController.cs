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

    public class FaqController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IFaq _faq;

        public FaqController(AppDbContext context, IFaq faq)
        {
            _context = context;
            _faq = faq;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Faq";

            List<Faq> message1 = _faq.GetFaqs();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(message1.Count / dataPage);

            List<Faq> message2 = message1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = message1.Count;
            return View(message2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Faq model)
        {
            if (ModelState.IsValid)
            {
                _faq.CreateFaq(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? faqId)
        {
            if (faqId == null && faqId <= 0)
            {
                return NotFound();
            }
            Faq faq = _faq.FinFaq(faqId);
            return View(faq);
        }
        [HttpPost]
        public IActionResult Update(Faq model)
        {
            if (ModelState.IsValid)
            {
                _faq.UpdateFaq(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int faqId)
        {
            _faq.DeleteFaq(faqId);

            return RedirectToAction("Index");
        }
    }
}
