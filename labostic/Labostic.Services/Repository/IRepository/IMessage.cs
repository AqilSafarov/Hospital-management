using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IMessage
    {
        Models.Message GetMessage();
        List<Models.Message> GetMessages();
        Models.Message CreateMessage(Models.Message model);
        Models.Message UpdateMessage(Models.Message model);
        bool DeleteMessage(int id);
    }
}
