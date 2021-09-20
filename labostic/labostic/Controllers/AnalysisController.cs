using labostic.ViewModels;
using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace labostic.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly ICheck _check;
        private readonly IAnswer _answer;

        public AnalysisController(ICheck check, IAnswer answer)
        {
            _check = check;
            _answer = answer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string finCode)
        {
            Check check = _check.GetCheck(finCode);
            if (check == null)
            {
                ModelState.AddModelError("", "fdsfsdfsf");
                return View();
            }
            return RedirectToAction("Index","Answer", new { finCode });
        }
    }
}
