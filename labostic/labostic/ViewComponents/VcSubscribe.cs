using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewComponents
{
    public class VcSubscribe:ViewComponent
    {
        private readonly ISubscribe _subscribe;

        public VcSubscribe(ISubscribe subscribe)
        {
            _subscribe = subscribe;

        }
        public IViewComponentResult Invoke()
        {
            Subscribe subscribe = new Subscribe();
            return View(subscribe);
        }
    }
}
