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

    public class SocialController : Controller
    {
        private readonly ISocial _social;

        public SocialController(ISocial social)
        {
            _social = social;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Social";

            List<Social> social1 = _social.GetSocials();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(social1.Count / dataPage);

            List<Social> social2 = social1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = social1.Count;
            return View(social2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Social model)
        {
            if (ModelState.IsValid)
            {
                _social.CreateSocial(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? socialId)
        {
            if (socialId == null && socialId <= 0)
            {
                return NotFound();
            }
            Social social = _social.GetSocial(socialId);
            return View(social);
        }
        [HttpPost]
        public IActionResult Update(Social model)
        {
            if (ModelState.IsValid)
            {
                _social.UpdateSocial(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int socialId)
        {
            _social.DeleteSocial(socialId);

            return RedirectToAction("Index");
        }
    }
}
