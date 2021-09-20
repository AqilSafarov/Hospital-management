using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
   public interface IAppointment
    {
        List<Models.Appointment> GetAppointments();
        Models.Appointment GetAppointment();
        Models.Appointment CreateAppointment(Models.Appointment model);
        Models.Appointment UpdateAppointment(Models.Appointment model);
        bool DeleteAppointment(int id);

    }
}
