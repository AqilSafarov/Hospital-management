using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class TrustedExp : ITrustedExp
    {
        private readonly AppDbContext _context;

        public TrustedExp(AppDbContext context)
        {
            _context = context;
        }
        public Models.TrustedExp CreateTrustedExp(Models.TrustedExp model)
        {
            _context.TrustedExp.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteTrustedExp(int id)
        {
            Models.TrustedExp trustedExp = _context.TrustedExp.Find(id);
            _context.TrustedExp.Remove(trustedExp);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Models.TrustedExp GetTrustedExp(int? trustedid)
        {
            return _context.TrustedExp.Find(trustedid);
        }

        public List<Models.TrustedExp> GetTrustedExps()
        {
            return _context.TrustedExp.ToList();

        }

        public Models.TrustedExp UpdateTrustedExp(Models.TrustedExp model)
        {
            _context.TrustedExp.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
