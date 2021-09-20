using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Doctor : IDoctor
    {
        private readonly AppDbContext _context;

        public Doctor(AppDbContext context)
        {
            _context = context;
        }
        public Models.Doctor CreateDoctor(Models.Doctor model)
        {
            _context.Doctor.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteDoctor(int id)
        {
            Models.Doctor doctor = _context.Doctor.Find(id);
            _context.Doctor.Remove(doctor);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Doctor GetDoctor(int? id)
        {
            return _context.Doctor.Include(s => s.SocialToDoctor.Where(x => x.DoctorId == id)).ThenInclude(d => d.Social).Include(s => s.SkillToDoctor).ThenInclude(b => b.Skill).Include(y => y.Position).Include(a => a.Appointment).Include(p=>p.Position).FirstOrDefault(p => p.Id == id); ;


        }

        public List<Models.Doctor> GetDoctors(int? id)
        {
            return _context.Doctor.Include(s=>s.SocialToDoctor.Where(x => x.DoctorId == id)).ThenInclude(d=>d.Social).Include(s=>s.SkillToDoctor).ThenInclude(b=>b.Skill).Include(y=>y.Position).Include(a=>a.Appointment).Include(p => p.Position).ToList();

        }

        public List<Models.Doctor> GetDoctorses()
        {
            return _context.Doctor.Include(s => s.SocialToDoctor).ThenInclude(d => d.Social).Include(s => s.SkillToDoctor).ThenInclude(b => b.Skill).Include(y => y.Position).Include(a => a.Appointment).Include(p => p.Position).ToList();

        }

        public Models.Doctor GetDoctorSingle()
        {
            return _context.Doctor.Include(a=>a.Appointment).Include(s=>s.SkillToDoctor).ThenInclude(t=>t.Skill).FirstOrDefault();
        }

        public Models.Doctor UpdateDoctor(Models.Doctor model)
        {
            _context.Doctor.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
