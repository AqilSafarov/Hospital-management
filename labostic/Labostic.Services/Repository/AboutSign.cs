using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class AboutSign : IAboutSign
    {
        private readonly AppDbContext _context;

        public AboutSign(AppDbContext context)
        {
            _context = context;
        }
        public Models.AboutSign CreateAboutSign(Models.AboutSign model)
        {
            _context.AboutSign.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteAboutSign(int id)
        {
            Models.AboutSign aboutSign = _context.AboutSign.Find(id);
            _context.AboutSign.Remove(aboutSign);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.AboutSign GetAboutSign(int? aboutsignId)
        {
            return _context.AboutSign.Find(aboutsignId);
        }

        public List<Models.AboutSign> GetAboutSigns()
        {
            return _context.AboutSign.ToList();
        }

        public Models.AboutSign UpdateAboutSign(Models.AboutSign model)
        {
            _context.AboutSign.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
