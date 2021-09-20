using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Faq : IFaq
    {
        private readonly AppDbContext _context;

        public Faq(AppDbContext context)
        {
            _context = context;
        }
        public Models.Faq CreateFaq(Models.Faq model)
        {
            _context.Faq.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteFaq(int id)
        {
            Models.Faq faq = _context.Faq.Find(id);
            _context.Faq.Remove(faq);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Faq FinFaq(int? faqId)
        {
            return _context.Faq.Find(faqId);

        }

        public List<Models.Faq> GetFaqs()
        {
            return _context.Faq.ToList();
        }

        public Models.Faq UpdateFaq(Models.Faq model)
        {
            _context.Faq.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
