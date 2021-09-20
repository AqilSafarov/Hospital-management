using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Answer : IAnswer
    {
        private readonly AppDbContext _context;

        public Answer(AppDbContext context)
        {
            _context = context;
        }
        public Models.Answer CreateAnswer(Models.Answer model)
        {
            _context.Answer.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteAnswer(int id)
        {
            Models.Answer answer = _context.Answer.Find(id);
            _context.Answer.Remove(answer);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Answer GetAnswer(int? id)
        {
            return _context.Answer.FirstOrDefault(n => n.Id == id);
        }

        public List<Models.Answer> GetAnswers(int? patientId)
        {
            return _context.Answer.Where(n => n.CheckId == patientId).ToList();

        }

        public Models.Answer UpdateAnswer(Models.Answer model)
        {
            _context.Answer.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
