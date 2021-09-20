using Labostic.Models;
using Labostic.Services;
using Labostic.Services.Repository.IRepository;
using Labostic.Skill.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISocial _social;
        private readonly IDoctor _doctor;
        private readonly IPosition _position;
        private readonly IAwards _awards;
        private readonly ISkill _skill;
        private readonly ISkillToDoctor _skillToDoctor;
        private readonly IExperience _experience;
        private readonly ISocialToDoctor _socialToDoctor;

        public TeamController(AppDbContext context, IWebHostEnvironment webHostEnvironment, ISocial social, IDoctor doctor, IPosition position, IAwards awards,ISkill skill,ISocialToDoctor socialToDoctor,ISkillToDoctor skillToDoctor,IExperience experience)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _social = social;
            _doctor = doctor;
            _position = position;
            _awards = awards;
            _skill = skill;
            _skillToDoctor = skillToDoctor;
            _experience = experience;
            _socialToDoctor = socialToDoctor;
        }
        public IActionResult Index(int page = 1)
        {

            ViewBag.Active = "Team";
            List<Doctor> doctor1 = _doctor.GetDoctorses();

            decimal dataPage = 5;
            decimal pageCount = Math.Ceiling(doctor1.Count / dataPage);

            List<Doctor> doctor = doctor1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = doctor1.Count;

            return View(doctor);
        }

        public IActionResult Create()
        {
            ViewBag.Social = _social.GetSocials();
            ViewBag.Position = _position.GetPositions();
            ViewBag.Skill = _skill.GetSkills();
            ViewBag.Awards = _awards.GetAwardses();
            ViewBag.Experience = _experience.GetExperience();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Doctor model)
        {
            if (ModelState.IsValid)
            {

                List<SocialToDoctor> newSocialToDoctor = model.SocialToDoctor;
                List<SkillToDoctor> newSkillToDoctor = model.SkillToDoctor;
                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        ViewBag.Social = _social.GetSocials();
                        ViewBag.Position = _position.GetPositions();
                        ViewBag.Skill = _skill.GetSkills();
                        ViewBag.Awards = _awards.GetAwardses();
                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152 )
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        ViewBag.Social = _social.GetSocials();
                        ViewBag.Position = _position.GetPositions();
                        ViewBag.Skill = _skill.GetSkills();
                        ViewBag.Awards = _awards.GetAwardses();
                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    model.Image = fileName;
                }

                model.SocialToDoctor = null;
                model.SkillToDoctor = null;
                _doctor.CreateDoctor(model);
                await _context.SaveChangesAsync();
                foreach (var item in newSocialToDoctor)
                {
                    if (item.SocialId > 0 && item.Link != null)
                    {
                        SocialToDoctor socialToDoctor = new SocialToDoctor()
                        {
                            DoctorId = model.Id,
                            SocialId = item.SocialId,
                            Link = item.Link

                        };
                        _socialToDoctor.CreateSocialToDoctor(socialToDoctor);
                    }
                }

                foreach (var item in newSkillToDoctor)
                {
                    if (item.SkillId > 0)
                    {
                        SkillToDoctor skillToDoctor = new SkillToDoctor()
                        {
                            DoctorId = model.Id,
                            SkillId = item.SkillId,
                            Percent = item.Percent,

                        };
                        _skillToDoctor.CreateSkillToDoctor(skillToDoctor);
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.Social = _social.GetSocials();
            ViewBag.Position = _position.GetPositions();
            ViewBag.Skill = _skill.GetSkills();
            ViewBag.Awards = _awards.GetAwardses();
            return View(model);
        }
        public IActionResult Update(int? doctorId)
        {
            if (doctorId == null && doctorId <= 0)
            {
                return NotFound();
            }

            ViewBag.Social = _social.GetSocials();
            ViewBag.Position = _position.GetPositions();
            ViewBag.Skill = _skill.GetSkills();
            ViewBag.Awards = _awards.GetAwardses();

            Doctor doctor = _doctor.GetDoctor(doctorId);


            return View(doctor);
        }
        [HttpPost]
        public IActionResult Update(Doctor model)
        {
            if (ModelState.IsValid)
            {
                List<SocialToDoctor> newSocial = model.SocialToDoctor;
                List<SocialToDoctor> oldSocial = _context.SocialToDoctor.Where(s => s.DoctorId == model.Id).ToList();

                List<SkillToDoctor> newSkill = model.SkillToDoctor;
                List<SkillToDoctor> oldSkill = _context.SkillToDoctor.Where(s => s.DoctorId == model.Id).ToList();

                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        ViewBag.Social = _social.GetSocials();
                        ViewBag.Position = _position.GetPositions();
                        ViewBag.Skill = _skill.GetSkills();
                        ViewBag.Awards = _awards.GetAwardses();
                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        ViewBag.Social = _social.GetSocials();
                        ViewBag.Position = _position.GetPositions();
                        ViewBag.Skill = _skill.GetSkills();
                        ViewBag.Awards = _awards.GetAwardses();
                        return View(model);
                    }

                    string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Images", model.Image);
                    System.IO.File.Delete(oldFilePath);

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    model.Image = fileName;
                }


                model.SocialToDoctor = null;
                _context.Doctor.Update(model);
                _context.SaveChanges();

                _context.SocialToDoctor.RemoveRange(oldSocial);


               

                foreach (var item in newSocial)
                {
                    if (item.SocialId > 0 && item.Link != null)
                    {
                        SocialToDoctor social = new SocialToDoctor()
                        {
                            DoctorId = model.Id,
                            SocialId = item.SocialId,
                            Link = item.Link
                        };
                        _context.SocialToDoctor.Add(social);
                    }
                }
                // model.SkillToDoctor = null;
                //_context.Doctor.Update(model);
                //_context.SaveChanges();

                _context.SkillToDoctor.RemoveRange(oldSkill);

                //foreach (var item in newSkill)
                //{
                //    if (item.SkillId > 0 )
                //    {
                //        SkillToDoctor skill = new SkillToDoctor()
                //        {
                //            DoctorId = model.Id,
                //            SkillId = item.SkillId,
                //            Percent = item.Percent
                //        };
                //        _context.SkillToDoctor.Add(skill);
                //    }
                //}

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Social = _social.GetSocials();
            ViewBag.Position = _position.GetPositions();
            ViewBag.Skill = _skill.GetSkills();
            ViewBag.Awards = _awards.GetAwardses();
            return View(model);
        }

        public IActionResult Delete(int doctorId)
        {
            _doctor.DeleteDoctor(doctorId);

            return RedirectToAction("Index");
        }
        public JsonResult GetSocials()
        {
            List<Social> socials = _context.Social.ToList();
            return Json(socials);
        }
        public JsonResult GetSkils()
        {
            List<Skill> skills = _context.Skill.ToList();
            return Json(skills);
        }
    }
}
