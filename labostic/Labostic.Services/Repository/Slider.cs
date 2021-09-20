using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Slider : ISlider
    {
        private readonly AppDbContext _context;

        public Slider(AppDbContext context)
        {
            _context = context;
        }
        public Models.Slider CreateSlider(Models.Slider model)
        {
            _context.Slider.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSlider(int id)
        {
            Models.Slider slider = _context.Slider.Find(id);
            _context.Slider.Remove(slider);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Models.Slider GetSlider(int? id)
        {
            return _context.Slider.Find(id);
        }

        public List<Models.Slider> GetSliders()
        {
            return _context.Slider.ToList();
        }

        public Models.Slider UpdateSlider(Models.Slider model)
        {
            _context.Slider.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
