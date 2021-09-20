using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IFaq
    {
        List<Models.Faq> GetFaqs();
        Models.Faq CreateFaq(Models.Faq model);
        Models.Faq UpdateFaq(Models.Faq model);
        Models.Faq FinFaq(int? faqId);

        bool DeleteFaq(int id);
    }
}
