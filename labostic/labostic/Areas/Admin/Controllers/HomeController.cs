using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class HomeController : Controller
    {
        private readonly ICheck _check;

        public HomeController(ICheck check)
        {
            _check = check;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "Home";

            Check check = _check.GetCheckSing();
            return View(check);
        }
    }
}
