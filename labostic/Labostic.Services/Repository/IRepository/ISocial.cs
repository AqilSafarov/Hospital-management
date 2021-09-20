using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface ISocial
    {
        List<Models.Social> GetSocials();
        List<Models.Social> GetSocials(int? doctorId);
        Models.Social GetSocialSing();
        Models.Social GetSocial(int? id);
        Models.Social CreateSocial(Models.Social model);
        Models.Social UpdateSocial(Models.Social model);
        bool DeleteSocial(int id);
    }
}
