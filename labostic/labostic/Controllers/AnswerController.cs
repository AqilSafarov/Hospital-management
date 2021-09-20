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
    public class AnswerController : Controller
    {
        private readonly IAnswer _answer;
        private readonly ICheck _check;

        public AnswerController(IAnswer answer,ICheck check)
        {
            _answer = answer;
            _check = check;
        }
        public IActionResult Index(string finCode)
        {
            Check check = _check.GetCheck(finCode);
            if (check == null)
            {
                ModelState.AddModelError("", "fdsfsdfsf");
                return View();
            }
            return View(check);
        }
    }
}
