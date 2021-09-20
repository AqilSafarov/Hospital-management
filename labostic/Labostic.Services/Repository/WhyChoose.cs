using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class WhyChoose : IWhyChoose
    {
        private readonly AppDbContext _context;

        public WhyChoose(AppDbContext context)
        {
            _context = context;
        }
        public Models.WhyChoose CreateWhyChoose(Models.WhyChoose model)
        {
            _context.WhyChoose.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteWhyChoose(int id)
        {
            Models.WhyChoose whyChoose = _context.WhyChoose.Find(id);
            _context.WhyChoose.Remove(whyChoose);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Models.WhyChoose GetWhyChoose(int? whyid)
        {
            return _context.WhyChoose.Find(whyid);
        }

        public List<Models.WhyChoose> GetWhyChooses()
        {
            return _context.WhyChoose.ToList();

        }

        public Models.WhyChoose UpdateWhyChoose(Models.WhyChoose model)
        {
            _context.WhyChoose.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
