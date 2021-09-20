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

    public class ResearchCategoryController : Controller
    {
        private readonly IResearchCategory _researchCategory;

        public ResearchCategoryController(IResearchCategory researchCategory)
        {
            _researchCategory = researchCategory;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "ResearchCategory";
            List<ResearchCategory> researchcategory1 = _researchCategory.GetResearchCategorys();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(researchcategory1.Count / dataPage);

            List<ResearchCategory> researchcategory2 = researchcategory1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = researchcategory1.Count;
            return View(researchcategory2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ResearchCategory model)
        {
            if (ModelState.IsValid)
            {
                _researchCategory.CreateResearchCategory(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? researchCategoryId)
        {
            if (researchCategoryId == null && researchCategoryId <= 0)
            {
                return NotFound();
            }
            ResearchCategory researchCategory = _researchCategory.GetResearchCategory(researchCategoryId);
            return View(researchCategory);
        }
        [HttpPost]
        public IActionResult Update(ResearchCategory model)
        {
            if (ModelState.IsValid)
            {
                _researchCategory.UpdateResearchCategory(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }
        public IActionResult Delete(int researchcategoryId)
        {
            _researchCategory.DeleteResearchCategory(researchcategoryId);

            return RedirectToAction("Index");
        }
    }
}
