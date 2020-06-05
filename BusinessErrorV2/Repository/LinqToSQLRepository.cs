using BusinessErrorV2.Database2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessErrorV2.Repository
{
    public class LinqToSQLRepository
    {
        ObservableCollection<QueueItem> oc = new ObservableCollection<QueueItem>();

        public ObservableCollection<QueueItem> GetData(string dropdown, string query, DateTime? fromDate, DateTime? toDate )
        {
            if (dropdown != "" || query != "")
            {
                LinqToSQLDataContext ldb = new LinqToSQLDataContext();
                IQueryable<QueueItem> rs = (from a in ldb.QueueItems
                                           join b in ldb.Robots on a.RobotId equals b.Id
                                           join c in ldb.RobotsXEnvironments on b.Id equals c.RobotId
                                           join d in ldb.Environments on c.EnvironmentId equals d.Id
                                           join e in ldb.Releases on d.Id equals e.EnvironmentId
                                           where a.SpecificData.Contains(query) || a.Reference == query || e.ProcessKey == dropdown &&
                                           a.StartProcessing >= fromDate && a.EndProcessing <= toDate
                                           select a).Take(100);

                foreach (var row in rs)
                {
                    oc.Add(row);
                }
                if (!oc.Any())
                {

                    MessageBox.Show("No items was found with the specified search terms", "Confirmation",
                                               MessageBoxButton.OK,
                                               MessageBoxImage.Question);
                }
                return oc;
            }
            return getWithOnlyDate(fromDate,toDate);

        }

        public ObservableCollection<QueueItem> getWithOnlyDate(DateTime? fromDate, DateTime? toDate)
        {
            LinqToSQLDataContext ldb = new LinqToSQLDataContext();
            IQueryable<QueueItem> rs = (from a in ldb.QueueItems
                                       join b in ldb.Robots on a.RobotId equals b.Id
                                       join c in ldb.RobotsXEnvironments on b.Id equals c.RobotId
                                       join d in ldb.Environments on c.EnvironmentId equals d.Id
                                       join e in ldb.Releases on d.Id equals e.EnvironmentId
                                       where a.StartProcessing >= fromDate && a.EndProcessing <= toDate
                                       select a).Take(100);

            foreach (var row in rs)
            {
                oc.Add(row);
            }

            if (!oc.Any())
            {

                MessageBox.Show("No items was found with the specified search terms", "Confirmation",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Question);
            }

            return oc;

        }

    }

   
}






