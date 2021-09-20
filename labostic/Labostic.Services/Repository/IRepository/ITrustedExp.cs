using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface ITrustedExp
    {
        List<Models.TrustedExp> GetTrustedExps();
        Models.TrustedExp GetTrustedExp(int? trustedid);
        Models.TrustedExp CreateTrustedExp(Models.TrustedExp model);
        Models.TrustedExp UpdateTrustedExp(Models.TrustedExp model);
        bool DeleteTrustedExp(int id);
    }
}
