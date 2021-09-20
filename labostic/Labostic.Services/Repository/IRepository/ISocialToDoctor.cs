using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
   public interface ISocialToDoctor
    {
        List<Models.SocialToDoctor> GetSocialToDoctors();
        Models.SocialToDoctor GetSocialToDoctor(int id);
        Models.SocialToDoctor GetSocialToDoctorSing();
        Models.SocialToDoctor CreateSocialToDoctor(Models.SocialToDoctor model);
        Models.SocialToDoctor UpdateSocialToDoctor(Models.SocialToDoctor model);
        bool DeleteSocialToDoctor(int id);
    }
}
