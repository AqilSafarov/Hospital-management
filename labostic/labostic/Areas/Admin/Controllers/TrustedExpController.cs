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

    public class TrustedExpController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITrustedExp _trustedExp;

        public TrustedExpController(AppDbContext context, ITrustedExp trustedExp)
        {
            _context = context;
            _trustedExp = trustedExp;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "TrustedExp";

            List<TrustedExp> trustedExp1 = _trustedExp.GetTrustedExps();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(trustedExp1.Count / dataPage);

            List<TrustedExp> trustedExp2 = trustedExp1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = trustedExp1.Count;
            return View(trustedExp2);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrustedExp model)
        {
            if (ModelState.IsValid)
            {
                _trustedExp.CreateTrustedExp(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? trustedId)
        {
            if (trustedId == null && trustedId <= 0)
            {
                return NotFound();
            }
            TrustedExp trustedExp = _trustedExp.GetTrustedExp(trustedId);
            return View(trustedExp);
        }
        [HttpPost]
        public IActionResult Update(TrustedExp model)
        {
            if (ModelState.IsValid)
            {
                _trustedExp.UpdateTrustedExp(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int trustedId)
        {
            _trustedExp.DeleteTrustedExp(trustedId);

            return RedirectToAction("Index");
        }
    }
}
