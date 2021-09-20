using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Social: ISocial
    {

        private readonly AppDbContext _context;

        public Social(AppDbContext context)
        {
            _context = context;
        }
        public Models.Social CreateSocial(Models.Social model)
        {
            _context.Social.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSocial(int id)
        {
            Models.Social social = _context.Social.Find(id);
            _context.Social.Remove(social);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Social GetSocial()
        {
            return _context.Social.Include(a => a.SocialToDoctor).ThenInclude(s => s.Social).FirstOrDefault();
        }

        public Models.Social GetSocial(int? id)
        {
            return _context.Social.Find(id);
        }

        public List<Models.Social> GetSocials()
        {
            return _context.Social.Include(a=>a.SocialToDoctor).ThenInclude(s=>s.Social).ToList();
        }

        public List<Models.Social> GetSocials(int? doctorId)
        {
            return _context.Social.Include(a => a.SocialToDoctor.Where(x => x.DoctorId == doctorId)).ThenInclude(s => s.Social).ToList();
        }

        public Models.Social GetSocialSing()
        {
            return _context.Social.Include(q=>q.SocialToDoctor).ThenInclude(s => s.Social).FirstOrDefault();
        }

        public Models.Social UpdateSocial(Models.Social model)
        {
            _context.Social.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
