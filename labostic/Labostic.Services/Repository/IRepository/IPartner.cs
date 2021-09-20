using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
  public  interface IPartner
    {
        List<Models.Partner> GetPartners();
        Models.Partner GetPartner(int? id);
        Models.Partner CreatePartner(Models.Partner model);
        Models.Partner UpdatePartner(Models.Partner model);
        bool DeletePartner(int id);
    }
}
