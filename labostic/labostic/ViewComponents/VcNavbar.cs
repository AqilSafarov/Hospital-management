using labostic.ViewModels;
using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewComponents
{
    public class VcNavbar: ViewComponent
    {
        private readonly IAppointment _appointment;
        private readonly IDoctor _doctor;
        private readonly ISocial _social;

        public VcNavbar(IAppointment appointment,IDoctor doctor,ISocial social)
        {
            _appointment = appointment;
            _doctor = doctor;
            _social = social;
        }
        public IViewComponentResult Invoke()
        {
            VmNavbar model = new VmNavbar()
            {
                Appointment = _appointment.GetAppointment(),
                Doctor = _doctor.GetDoctorses(),
                //Social = _social.GetSocials(),
                Doctors = _doctor.GetDoctorSingle(),

            };

            return View(model);
        }
       
    }
}
