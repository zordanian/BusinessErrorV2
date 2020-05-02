using BusinessErrorV2.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesErrorDashboard.Models
{
    class DataAccess
    {
        public IEnumerable<QueueItems> GetSQLData()
        {
            List<QueueItems> output = new List<QueueItems>();

            QueueItems sql = new QueueItems();

            UiPathEntities db = new UiPathEntities();

            sql = db.QueueItems.SingleOrDefault(c => c.Id == 3337724);
            

            output.Add(sql);

            return output;


        }
    }
}
