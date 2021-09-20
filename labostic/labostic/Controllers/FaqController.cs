using labostic.ViewModels;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Controllers
{
    public class FaqController : Controller
    {
        private readonly IQuestion _question;
        private readonly IFaq _faq;
        private readonly ISubscribe _subscribe;

        public FaqController(IQuestion question,IFaq faq,ISubscribe subscribe)
        {
            _question = question;
            _faq = faq;
            _subscribe = subscribe;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "Faq";

            VmFaq model = new VmFaq()
            {
                Question = _question.GetQuestion(),
                Faq = _faq.GetFaqs()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Question(VmFaq model)
        {
            if (ModelState.IsValid)
            {

                model.Question.CreatedDate = DateTime.Now;
                _question.CreateQuestion(model.Question);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Faq");
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
