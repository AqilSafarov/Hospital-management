using labostic.Models;
using labostic.ViewModels;
using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISetting _setting;
        private readonly IHomeCircle _homeCircle;
        private readonly ILabTech _labTech;
        private readonly ITrustedExp _trustedExp;
        private readonly ITestimonial _testimonial;
        private readonly IPartner _partner;
        private readonly ISlider _slider;
        private readonly ISubscribe _subscribe;
        private readonly IAppointment _appointment;
        private readonly IResearch _research;
        private readonly IServices _services;

        public HomeController(ILogger<HomeController> logger,ISetting setting,IHomeCircle homeCircle,ILabTech labTech,ITrustedExp trustedExp,ITestimonial testimonial,IPartner partner,ISlider slider, ISubscribe subscribe,IAppointment appointment,IResearch research,IServices services)
        {
            _logger = logger;
            _setting = setting;
            _homeCircle = homeCircle;
            _labTech = labTech;
            _trustedExp = trustedExp;
            _testimonial = testimonial;
            _partner = partner;
            _slider = slider;
            _subscribe = subscribe;
            _appointment = appointment;
            _research = research;
            _services = services;
        }

        public IActionResult Index()
        {
            ViewBag.Active = "Home";

            VmHome model = new VmHome()
            {
                Setting = _setting.GetSetting(),
                HomeCircle = _homeCircle.GetHomeCircles(),
                LabTech = _labTech.GetLabTechs(),
                TrustedExp = _trustedExp.GetTrustedExps(),
                Testimonial = _testimonial.GetTestimonials(),
                Partner = _partner.GetPartners(),
                Slider=_slider.GetSliders(),
                Researche=_research.GetResearchs(),
                Services=_services.GetServiceses(),
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Subscribe(Subscribe model)
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
        [HttpPost]
        public IActionResult Appointment(VmNavbar model1)
        {
            if (ModelState.IsValid)
            {
                model1.Appointment.CreatedDate = DateTime.Now;
                _appointment.CreateAppointment(model1.Appointment);
            }
            return RedirectToAction("Index", "Contact");

        }


    }
}
