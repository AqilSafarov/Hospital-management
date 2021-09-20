using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
   
    public class Question : IQuestion
    {
        private readonly AppDbContext _context;

        public Question(AppDbContext context)
        {
            _context = context;
        }
        public Models.Question CreateQuestion(Models.Question model)
        {
            _context.Question.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteQuestion(int id)
        {
            Models.Question question = _context.Question.Find(id);
            _context.Question.Remove(question);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Question GetQuestion()
        {
            return _context.Question.FirstOrDefault();
        }

        public List<Models.Question> GetQuestions()
        {
            return _context.Question.ToList();

        }

        public Models.Question UpdateQuestion(Models.Question model)
        {
            _context.Question.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
