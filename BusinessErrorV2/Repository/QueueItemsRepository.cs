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

            
        }

        public IQueryable<QueueItems> getData(DateTime? from, DateTime? to,String query)
        {

            if (query != "" && from == null && to == null)
            {
                try
                {
                    tQuery = db.QueueItems.Where(c => c.Reference == query || c.SpecificData.Contains(query));
                }
                catch
                {

                }
                return tQuery;
            }
            
            try
            {
                
                tQuery = db.QueueItems.Where(c => c.Reference == query && c.StartProcessing >= from && c.EndProcessing <= to
                || c.SpecificData.Contains(query) && c.StartProcessing >= from && c.EndProcessing <= to).Take(5);

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
        public QueueItems getItem(string transactionId)
        {

            return db.QueueItems.Single(c => c.Key.ToString() == transactionId);
        }

        public IEnumerable<string> getColumns()
        {
            var names = typeof(QueueItems).GetProperties()
                        .Select(property => property.Name)
                        .ToArray();
            return names;
        }


    }
}
