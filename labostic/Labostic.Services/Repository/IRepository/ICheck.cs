using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface ICheck
    {
        Models.Check GetCheck(string fin);
        Models.Check GetCheckSing();
        List<Models.Check> GetChecks(string finCode);
        Models.Check CreateCheck(Models.Check model);
        Models.Check UpdateCheck(Models.Check model);
        bool DeleteCheck(int id);
    }
}
