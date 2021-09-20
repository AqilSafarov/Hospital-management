using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface ISlider
    {
       List< Models.Slider> GetSliders();
        Models.Slider GetSlider(int? id);
        Models.Slider CreateSlider(Models.Slider model);
        Models.Slider UpdateSlider(Models.Slider model);
        bool DeleteSlider(int id);
    }
}
