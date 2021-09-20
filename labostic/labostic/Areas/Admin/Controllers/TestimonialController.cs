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

    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITestimonial _testimonial;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TestimonialController(AppDbContext context,ITestimonial testimonial, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _testimonial = testimonial;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Testimonial";

            List<Testimonial> testimonial1 = _testimonial.GetTestimonials();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(testimonial1.Count / dataPage);

            List<Testimonial> testimonial2 = testimonial1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = testimonial1.Count;
            return View(testimonial2);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Testimonial model)
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



                _testimonial.CreateTestimonial(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? testimonialId)
        {
            if (testimonialId == null && testimonialId <= 0)
            {
                return NotFound();
            }


            Testimonial testimonial = _testimonial.GetTestimonial(testimonialId);

            return View(testimonial);
        }

        [HttpPost]
        public IActionResult Update(Testimonial model)
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
                _testimonial.UpdateTestimonial(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int testimonialId)
        {
            _testimonial.DeleteTestimonial(testimonialId);

            return RedirectToAction("Index");
        }
    }
}
