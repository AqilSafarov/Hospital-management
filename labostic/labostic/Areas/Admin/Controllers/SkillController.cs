using Labostic.Models;
using Labostic.Skill.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class SkillController : Controller
    {
        private readonly ISkill _skill;

        public SkillController(ISkill skill)
        {
            _skill = skill;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Skill";

            List<Skill> skill1 = _skill.GetSkills();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(skill1.Count / dataPage);

            List<Skill> skill2 = skill1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = skill1.Count;
            return View(skill2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skill model)
        {
            if (ModelState.IsValid)
            {
                _skill.CreateSkill(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? skillId)
        {
            if (skillId == null && skillId <= 0)
            {
                return NotFound();
            }
            Skill skill = _skill.GetSkillsParm(skillId);
            return View(skill);
        }
        [HttpPost]
        public IActionResult Update(Skill model)
        {
            if (ModelState.IsValid)
            {
                _skill.UpdateSkill(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int skillId)
        {
            _skill.DeleteSkill(skillId);

            return RedirectToAction("Index");
        }
    }
}
