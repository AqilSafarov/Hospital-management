using labostic.ViewModels;
using Labostic.Models;
using Labostic.Services.Repository;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Controllers
{
    public class AboutController : Controller
    {
        private readonly ISetting _setting;
        private readonly IAboutSign _aboutSign;
        private readonly IWorkProcess _workProcess;
        private readonly IAboutStatistic _aboutStatistic;
        private readonly IWhyChoose _whyChoose;
        private readonly ISubscribe _subscribe;
        private readonly IDoctor _doctor;
        private readonly ISocial _social;

        public AboutController(ISetting setting, IAboutSign aboutSign, IWorkProcess workProcess, IAboutStatistic aboutStatistic, IWhyChoose whyChoose,ISubscribe subscribe,IDoctor doctor,ISocial social)
        {
            _setting = setting;
            _aboutSign = aboutSign;
            _workProcess = workProcess;
            _aboutStatistic = aboutStatistic;
            _whyChoose = whyChoose;
            _subscribe = subscribe;
            _doctor = doctor;
            _social = social;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "About";

            VmAbout model = new VmAbout()
            {

                Setting=_setting.GetSetting(),
                AboutSign = _aboutSign.GetAboutSigns(),
                WorkProcess=_workProcess.GetWorkProcesss(),
                AboutStatistic=_aboutStatistic.GetAboutStatistics(),
                WhyChoose=_whyChoose.GetWhyChooses(),
                Doctor=_doctor.GetDoctorses(),
                Social = _social.GetSocials(),


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
