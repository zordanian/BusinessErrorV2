using BusinessErrorV2.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesErrorDashboard.Repository
{
    class QueueItemsRepository
    {
        private UiPathEntities db;
        private IQueryable<QueueItems> tQuery;

        public QueueItemsRepository()
        {
            this.db = new UiPathEntities();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public IQueryable<QueueItems> getData(DateTime? from, DateTime? to,String query)
        {
            try
            {
                tQuery = db.QueueItems.Where(c => c.Reference == query && c.StartProcessing >= from && to <= c.EndProcessing
                || c.SpecificData.Contains(query) && c.StartProcessing >= from && to <= c.EndProcessing);
             
            }
            catch (Exception)
            {
            }
       
            if(tQuery != null)
            {
                return tQuery;
            }
            else{
                return null;
            }
        }

        
    }
}
