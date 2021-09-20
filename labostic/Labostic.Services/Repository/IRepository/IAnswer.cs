using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IAnswer
    {
        List<Models.Answer> GetAnswers(int? patientId);
        Models.Answer GetAnswer(int? id);
        //Models.Answer GetAnswer();
        Models.Answer CreateAnswer(Models.Answer model);
        Models.Answer UpdateAnswer(Models.Answer model);
        bool DeleteAnswer(int id);
    }
}
