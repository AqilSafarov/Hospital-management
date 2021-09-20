using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface ISubscribe
    {
        List<Models.Subscribe> GetSubscribe();
        Models.Subscribe GetSubscribe(int id);
        bool GetSubscribe(string email);

        Models.Subscribe CreateSubscribe(Models.Subscribe model);
        Models.Subscribe UpdateSubscribe(Models.Subscribe model);
        bool DeleteSubscribe(int id);
    }
}
