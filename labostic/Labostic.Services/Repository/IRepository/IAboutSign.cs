using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IAboutSign
    {
       List< Models.AboutSign> GetAboutSigns();
        Models.AboutSign GetAboutSign(int? aboutsignId);
        Models.AboutSign CreateAboutSign(Models.AboutSign model);
        Models.AboutSign UpdateAboutSign(Models.AboutSign model);
        bool DeleteAboutSign(int id);
    }
}
