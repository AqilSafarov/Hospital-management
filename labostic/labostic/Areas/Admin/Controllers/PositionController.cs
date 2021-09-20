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

    public class PositionController : Controller
    {
        private readonly IPosition _position;

        public PositionController(IPosition position)
        {
            _position = position;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Position";
            List<Position> position1 = _position.GetPositions();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(position1.Count / dataPage);

            List<Position> position2 = position1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = position1.Count;
            return View(position2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position model)
        {
            if (ModelState.IsValid)
            {
                _position.CreatePosition(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? positionId)
        {
            if (positionId == null && positionId <= 0)
            {
                return NotFound();
            }
            Position position = _position.GetPosition(positionId);
            return View(position);
        }
        [HttpPost]
        public IActionResult Update(Position model)
        {
            if (ModelState.IsValid)
            {
                _position.UpdatePosition(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();


        }

        public IActionResult Delete(int positionId)
        {
            _position.DeletePosition(positionId);

            return RedirectToAction("Index");
        }
    }
}
