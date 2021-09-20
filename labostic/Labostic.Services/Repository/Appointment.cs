using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Appointment : IAppointment
    {
        private readonly AppDbContext _context;

        public Appointment(AppDbContext context)
        {
            _context = context;
        }
        public Models.Appointment CreateAppointment(Models.Appointment model)
        {
            _context.Appointment.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteAppointment(int id)
        {
            Models.Appointment appointment = _context.Appointment.Find(id);
            _context.Appointment.Remove(appointment);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Appointment GetAppointment()
        {
            return _context.Appointment.Include(d=>d.Doctor).FirstOrDefault();
        }

      

        public List<Models.Appointment> GetAppointments()
        {
            return _context.Appointment.Include(a=>a.Doctor).ToList();
        }

        public Models.Appointment UpdateAppointment(Models.Appointment model)
        {
            _context.Appointment.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
