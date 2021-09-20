using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Testimonial: ITestimonial
    {

        private readonly AppDbContext _context;

        public Testimonial(AppDbContext context)
        {
            _context = context;
        }
        public Models.Testimonial CreateTestimonial(Models.Testimonial model)
        {
            _context.Testimonial.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteTestimonial(int id)
        {
            Models.Testimonial Testimonial = _context.Testimonial.Find(id);
            _context.Testimonial.Remove(Testimonial);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Testimonial> GetTestimonials()
        {
            return _context.Testimonial.ToList();

        }

        public Models.Testimonial GetTestimonial(int? id)
        {
            return _context.Testimonial.Find(id);
        }

        public Models.Testimonial UpdateTestimonial(Models.Testimonial model)
        {
            _context.Testimonial.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
