using BusinessErrorV2.Database2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessErrorV2.Models
{
    class LinqToSQLRepository
    {
        public IQueryable<QueueItem> GetData(string dropdown)
        {

            LinqToSQLDataContext ldb = new LinqToSQLDataContext();
            IQueryable<QueueItem> rs = from a in ldb.QueueItems
                                    join b in ldb.Robots on a.RobotId equals b.Id
                                    join c in ldb.RobotsXEnvironments on b.Id equals c.RobotId
                                    join d in ldb.Environments on c.EnvironmentId equals d.Id
                                    join e in ldb.Releases on d.Id equals e.EnvironmentId
                                    where d.Name.Equals(dropdown)            

                                    select a;

            return rs;













        }


    }
}






