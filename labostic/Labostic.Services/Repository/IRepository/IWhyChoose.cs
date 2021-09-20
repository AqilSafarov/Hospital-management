using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
   public interface IWhyChoose
    {
        List<Models.WhyChoose> GetWhyChooses();
        Models.WhyChoose GetWhyChoose(int? whyid);
        Models.WhyChoose CreateWhyChoose(Models.WhyChoose model);
        Models.WhyChoose UpdateWhyChoose(Models.WhyChoose model);
        bool DeleteWhyChoose(int id);
    }
}
