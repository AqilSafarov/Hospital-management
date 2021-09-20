using labostic.ViewModels;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISetting _setting;
        private readonly IMessage _message;
        private readonly ISocial _social;
        private readonly ISubscribe _subscribe;

        public ContactController(ISetting setting,IMessage message,ISocial social,ISubscribe subscribe)
        {
            _setting = setting;
            _message = message;
            _social = social;
            _subscribe = subscribe;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "Contact";

            VmFooter model = new VmFooter()
            {
                Setting = _setting.GetSetting(),
                Message = _message.GetMessage(),
                Social = _social.GetSocialSing()

            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Message(VmFooter model)
        {
            if (ModelState.IsValid)
            {
                model.Message.CreatedDate = DateTime.Now;
                _message.CreateMessage(model.Message);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Message");
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
