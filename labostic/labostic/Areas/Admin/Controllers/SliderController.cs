using Labostic.Models;
using Labostic.Services;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ISlider _slider;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(AppDbContext context,ISlider slider, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _slider = slider;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Slider";

            List<Slider> slider1 = _slider.GetSliders();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(slider1.Count / dataPage);

            List<Slider> slider2 = slider1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = slider1.Count;
            return View(slider2);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider model)
        {

            if (ModelState.IsValid)
            {

                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");

                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");

                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.Image = fileName;
                }



                _slider.CreateSlider(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? sliderId)
        {
            if (sliderId == null && sliderId <= 0)
            {
                return NotFound();
            }


            Slider slider = _slider.GetSlider(sliderId);

            return View(slider);
        }

        [HttpPost]
        public IActionResult Update(Slider model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.Image = fileName;
                }
                _slider.UpdateSlider(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int sliderId)
        {
            _slider.DeleteSlider(sliderId);

            return RedirectToAction("Index");
        }
    }
}
