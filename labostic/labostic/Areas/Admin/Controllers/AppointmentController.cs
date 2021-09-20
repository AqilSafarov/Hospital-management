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

    public class AppointmentController : Controller
    {
        private readonly IDoctor _doctor;
        private readonly IAppointment _appointment;

        public  AppointmentController(IDoctor doctor,IAppointment appointment)
        {
            _doctor = doctor;
            _appointment = appointment;
        }

        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Appointment";

            List<Appointment> appointment1 = _appointment.GetAppointments();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(appointment1.Count / dataPage);

            List<Appointment> appointment2 = appointment1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = appointment1.Count;
            return View(appointment2);
        }

        public IActionResult Delete(int appointmentId)
        {
            _appointment.DeleteAppointment(appointmentId);

            return RedirectToAction("Index");
        }
    }
}
