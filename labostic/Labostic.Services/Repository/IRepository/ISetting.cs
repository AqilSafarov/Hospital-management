using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface ISetting
    {
        Models.Setting GetSetting();
        Models.Setting GetSettingPrm(int? id);
        List<Models.Setting> GetSettings();
        Models.Setting CreateSetting(Models.Setting model);
        Models.Setting UpdateSetting(Models.Setting model);
        bool DeleteSetting(int id);
    }
}
