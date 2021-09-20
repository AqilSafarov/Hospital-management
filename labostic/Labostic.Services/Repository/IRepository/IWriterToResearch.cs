using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
   public interface IWriterToResearch
    {
         Models.WriterToResearch GetWriterToResearch();
         List<Models.WriterToResearch> GetWriterToResearchs();
        Models.WriterToResearch CreateWriterToResearch(Models.WriterToResearch model);
        Models.WriterToResearch UpdateWriterToResearch(Models.WriterToResearch model);
        bool DeleteWriterToResearch(int id);
    }
}
