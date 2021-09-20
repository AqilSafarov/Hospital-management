using Labostic.Models;
using Labostic.Services;
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

    public class WorkProcessController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWorkProcess _workProcess;

        public WorkProcessController(AppDbContext context,IWorkProcess workProcess)
        {
            _context = context;
            _workProcess = workProcess;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "WorkProcess";

            List<WorkProcess> workprocess1 = _workProcess.GetWorkProcesss();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(workprocess1.Count / dataPage);

            List<WorkProcess> workprocess2 = workprocess1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = workprocess1.Count;
            return View(workprocess2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WorkProcess model)
        {
            if (ModelState.IsValid)
            {
                _workProcess.CreateWorkProcess(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? workprocessId)
        {
            if (workprocessId == null && workprocessId <= 0)
            {
                return NotFound();
            }
            WorkProcess workProcess = _workProcess.GetWorkProcess(workprocessId);
            return View(workProcess);
        }
        [HttpPost]
        public IActionResult Update(WorkProcess model)
        {
            if (ModelState.IsValid)
            {
                _workProcess.UpdateWorkProcess(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int workprocessId)
        {
            _workProcess.DeleteWorkProcess(workprocessId);

            return RedirectToAction("Index");
        }

    }


}
