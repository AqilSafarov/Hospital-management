using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IWriter
    {
        Models.Writer GetWriter();
        Models.Writer FindWriter(int? id);
        List<Models.Writer> GetWriters();
        Models.Writer CreateWriter(Models.Writer model);
        Models.Writer UpdateWriter(Models.Writer model);
        bool DeleteWriter(int id);
        Models.Writer Save(Models.Writer model);

    }
}
