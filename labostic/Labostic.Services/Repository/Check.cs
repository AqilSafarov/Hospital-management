using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Check : ICheck
    {
        private readonly AppDbContext _context;

        public Check(AppDbContext context)
        {
            _context = context;
        }
        public Models.Check CreateCheck(Models.Check model)
        {
            _context.Check.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteCheck(int id)
        {
            Models.Check check = _context.Check.Find(id);
            _context.Check.Remove(check);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Check GetCheck(string fin)
        {
            return _context.Check.Where(n => n.FinCode == fin).Include(n => n.Answers).FirstOrDefault();
        }

       
        public List<Models.Check> GetChecks(string finCode)
        {
            return _context.Check.Where(c=>c.FinCode==finCode).ToList();
        }

        public Models.Check GetCheckSing()
        {
            return _context.Check.FirstOrDefault();
        }

        public Models.Check UpdateCheck(Models.Check model)
        {
            _context.Check.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
