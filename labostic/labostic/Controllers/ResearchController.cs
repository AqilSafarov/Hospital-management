using labostic.ViewModels;
using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Controllers
{
    public class ResearchController : Controller
    {
        private readonly IResearch _research;
        private readonly IResearchSquar _researchSquar;
        private readonly IResearchCategory _researchCategory;
        private readonly ISocial _socail;
        private readonly IWriter _writer;
        private readonly IWriterToResearch _writerToResearch;
        private readonly ISubscribe _subscribe;

        public ResearchController(IResearch research, IResearchSquar researchSquar,IResearchCategory researchCategory,ISocial socail,IWriter writer,IWriterToResearch writerToResearch,ISubscribe subscribe)
        {
            _research = research;
            _researchSquar = researchSquar;
            _researchCategory = researchCategory;
            _socail = socail;
           _writer = writer;
            _writerToResearch = writerToResearch;
            _subscribe = subscribe;
        }
        public IActionResult Index(string searchData)
        {

            ViewBag.Active = "Research";

            List<Research> researche = _research.GetResearchesPrm(searchData);



            return View(researche);
        }
        [Route("Research/Details/{researchId}")]

        public IActionResult Details(int? researchId)
        {

            VmResearchTwo model = new VmResearchTwo()
            {
                Research = _research.GetResearch(researchId),
                ResearchSquar = _researchSquar.GetResearchSquars(),
                Social = _socail.GetSocials(),
                Researches = _research.GetResearchs(),
                //ResearchCategory = _researchCategory.GetResearchCategory(categoryId),
                Writer = _writer.GetWriter(),
                WriterToResearche = _writerToResearch.GetWriterToResearchs(),
            };
            //return Json(model);
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
