using labostic.ViewModels;
using Labostic.Services.Repository.IRepository;
using Labostic.Skill.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Controllers
{
    public class TeamController : Controller
    {
        private readonly ISocial _social;
        private readonly IDoctor _doctor;
        private readonly IPosition _position;
        private readonly IAwards _awards;
        private readonly ISkill _skill;
        private readonly ISkillToDoctor _skillToDoctor;
        private readonly IExperience _experiencec;
        private readonly ISocialToDoctor _socialToDoctor;
        private readonly ISubscribe _subscribe;

        public TeamController(ISocial social, IDoctor doctor, IPosition position,IAwards awards,ISkill skill,ISkillToDoctor skillToDoctor,IExperience experiencec,ISocialToDoctor socialToDoctor,ISubscribe subscribe)
        {
            _social = social;
            _doctor = doctor;
            _position = position;
            _awards = awards;
            _skill = skill;
            _skillToDoctor = skillToDoctor;
            _experiencec = experiencec;
            _socialToDoctor = socialToDoctor;
            _subscribe = subscribe;
        }
        public IActionResult Index(int? doctorId)
        {
            ViewBag.Active = "Team";

            VmTeam model = new VmTeam()
            {
                Doctor = _doctor.GetDoctors(doctorId),
                Position=_position.GetPosition(),
                Social=_social.GetSocials(doctorId),
                SocialToDoctor=_socialToDoctor.GetSocialToDoctors(),

            };

            return View(model);
        }
        [Route("Team/Details/{doctorId}")]

        public IActionResult Details(int? doctorId)
        {
            if (doctorId == null)
                return NotFound();
            VmTeamTwo model = new VmTeamTwo()
            {
                Doctor = _doctor.GetDoctor(doctorId),
                Social=_social.GetSocials(doctorId),
                Awards=_awards.GetAwardses(),
                Skill = _skill.GetSkills(),
                SkillToDoctor=_skillToDoctor.GetSkillToDoctors(),
                Experience=_experiencec.GetExperiences(),




            };
            return View(model);
        }
        public IActionResult Subscribe(Labostic.Models.Subscribe model)
        {
            if (ModelState.IsValid)
            {
                if (!_subscribe.GetSubscribe(model.Email))
                {
                    model.CreatedDate = DateTime.Now;
                    _subscribe.CreateSubscribe(model);
                }
                ModelState.AddModelError("", "Qaqa eyni maildi");

            }

            return RedirectToAction("Index", "About");
        }
    }
}
