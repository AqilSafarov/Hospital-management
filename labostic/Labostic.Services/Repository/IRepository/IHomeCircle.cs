using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IHomeCircle
    {
        List<Models.HomeCircle> GetHomeCircles();
        Models.HomeCircle GetHomeCircle(int? id);
        Models.HomeCircle CreateHomeCircle(Models.HomeCircle model);
        Models.HomeCircle UpdateHomeCircle(Models.HomeCircle model);
        bool DeleteHomeCircle(int id);
    }
}
