using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
   public interface IQuestion
    {
        Models.Question GetQuestion();
       List <Models.Question >GetQuestions();
        Models.Question CreateQuestion(Models.Question model);
        Models.Question UpdateQuestion(Models.Question model);
        bool DeleteQuestion(int id);
    }
}
