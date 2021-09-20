using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class SocialToDoctor : ISocialToDoctor
    {
        private readonly AppDbContext _context;

        public SocialToDoctor(AppDbContext context)
        {
            _context = context;
        }
        public Models.SocialToDoctor CreateSocialToDoctor(Models.SocialToDoctor model)
        {
            _context.SocialToDoctor.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSocialToDoctor(int id)
        {
            Models.SocialToDoctor socialToDoctor = _context.SocialToDoctor.Find(id);
            _context.SocialToDoctor.Remove(socialToDoctor);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Models.SocialToDoctor GetSocialToDoctor(int id)
        {
            return _context.SocialToDoctor.Find(id);

        }

        public List<Models.SocialToDoctor> GetSocialToDoctors()
        {
            return _context.SocialToDoctor.Include(d => d.Doctor).Include(s=>s.Social).ToList();

        }

        public Models.SocialToDoctor GetSocialToDoctorSing()
        {
            return _context.SocialToDoctor.FirstOrDefault();
        }

        public Models.SocialToDoctor UpdateSocialToDoctor(Models.SocialToDoctor model)
        {
            _context.SocialToDoctor.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
