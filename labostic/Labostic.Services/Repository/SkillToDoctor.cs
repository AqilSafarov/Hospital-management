using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class SkillToDoctor : ISkillToDoctor
    {
        private readonly AppDbContext _context;

        public SkillToDoctor(AppDbContext context)
        {
            _context = context;
        }
        public Models.SkillToDoctor CreateSkillToDoctor(Models.SkillToDoctor model)
        {
            _context.SkillToDoctor.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSkillToDoctor(int id)
        {
            Models.SkillToDoctor skillToDoctor = _context.SkillToDoctor.Find(id);
            _context.SkillToDoctor.Remove(skillToDoctor);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Models.SkillToDoctor GetSkillToDoctor(int id)
        {
            return _context.SkillToDoctor.Find(id);

        }

        public List<Models.SkillToDoctor> GetSkillToDoctors()
        {
            return _context.SkillToDoctor.Include(s=>s.Skill).ToList();

        }

        public Models.SkillToDoctor GetSkillToDoctorSing()
        {
            return _context.SkillToDoctor.FirstOrDefault();
        }

        public Models.SkillToDoctor UpdateSkillToDoctor(Models.SkillToDoctor model)
        {
            _context.SkillToDoctor.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
