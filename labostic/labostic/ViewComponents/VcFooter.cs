using labostic.ViewModels;
using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewComponents
{
    public class VcFooter: ViewComponent
    {
        private readonly ISocial _social;
        private readonly IResearch _research;
        private readonly ISetting _setting;

        public VcFooter(ISocial social, IResearch research,ISetting setting)
        {
            _social = social;
            _setting = setting;
            _research = research;
        }
        public IViewComponentResult Invoke()
        {
            VmFooter model = new VmFooter()
            {
                Setting = _setting.GetSetting(),
                Social = _social.GetSocialSing(),
                Research = _research.GetResearchs()

            };

            return View(model);
        }

    }
}
