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

    public class PartnerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPartner _partner;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PartnerController(AppDbContext context, IPartner partner, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _partner = partner;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Partner";

            List<Partner> partner1 = _partner.GetPartners();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(partner1.Count / dataPage);

            List<Partner> partner2 = partner1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = partner1.Count;
            return View(partner2);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Partner model)
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



                _partner.CreatePartner(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? partnerId)
        {
            if (partnerId == null && partnerId <= 0)
            {
                return NotFound();
            }


            Partner partner = _partner.GetPartner(partnerId);

            return View(partner);
        }

        [HttpPost]
        public IActionResult Update(Partner model)
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
                _partner.UpdatePartner(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int partnerId)
        {
            _partner.DeletePartner(partnerId);

            return RedirectToAction("Index");
        }
    }
}
