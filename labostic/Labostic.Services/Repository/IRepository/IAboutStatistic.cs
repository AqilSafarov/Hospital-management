using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
   public interface IAboutStatistic
    {
        List<Models.AboutStatistic> GetAboutStatistics();
        Models.AboutStatistic GetAboutStatistic(int? id);
        Models.AboutStatistic CreateAboutStatistic(Models.AboutStatistic model);
        Models.AboutStatistic UpdateAboutStatistic(Models.AboutStatistic model);
        bool DeleteAboutStatistic(int id);
    }
}
