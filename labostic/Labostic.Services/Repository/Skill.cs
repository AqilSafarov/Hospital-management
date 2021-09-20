using Labostic.Skill.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Skill : ISkill
    {
        private readonly AppDbContext _context;

        public Skill(AppDbContext context)
        {
            _context = context;
        }
        public Models.Skill CreateSkill(Models.Skill model)
        {
            _context.Skill.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSkill(int id)
        {
            Models.Skill skill = _context.Skill.Find(id);
            _context.Skill.Remove(skill);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public List<Models.Skill> GetSkills()
        {
            return _context.Skill.Include(s=>s.SkillToDoctor).ToList();
        }

        public Models.Skill GetSkillsParm(int? sid)
        {
            return _context.Skill.Find(sid);
        }

        public List<Models.Skill> GetSkillsPm(int? sid)
        {
            return _context.Skill.Include(s=>s.SkillToDoctor.Where(x => x.DoctorId == sid)).ToList();

        }

        public Models.Skill UpdateSkill(Models.Skill model)
        {
            _context.Skill.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
