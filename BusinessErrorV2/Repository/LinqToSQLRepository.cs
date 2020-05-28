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
        public IList<Databases.QueueItems> GetData(string dropdown)
        {

            LinqToSQLDataContext ldb = new LinqToSQLDataContext();
            IQueryable<QueueItem> rs = from a in ldb.QueueItems
                                    join b in ldb.Robots on a.RobotId equals b.Id
                                    join c in ldb.RobotsXEnvironments on b.Id equals c.RobotId
                                    join d in ldb.Environments on c.EnvironmentId equals d.Id
                                    join e in ldb.Releases on d.Id equals e.EnvironmentId       
                                    where e.ProcessKey.Equals(dropdown)                            
                                    select a;

            IList<Databases.QueueItems> test = MapToOtherModel(rs);
            return test;
        }

        public IList<Databases.QueueItems> MapToOtherModel(IQueryable<QueueItem> rs)
        {
            List<Database2.QueueItem> rsList = rs.ToList();
            Databases.QueueItems qi = new Databases.QueueItems();
            List<Databases.QueueItems> qiList = new List<Databases.QueueItems>();

            for(int i = 0; i < rs.Count(); i ++)
            {
                qi.Id = rsList[i].Id;
                qi.Priority = rsList[i].Priority;
                qi.QueueDefinitionId = rsList[i].QueueDefinitionId;
                qi.Key = rsList[i].Key;
                qi.Status = rsList[i].Status;
                qi.ReviewStatus = rsList[i].ReviewStatus;
                qi.RobotId = rsList[i].RobotId;
                qi.StartProcessing = rsList[i].StartProcessing;
                qi.EndProcessing = rsList[i].EndProcessing;
                qi.SecondsInPreviousAttempts = rsList[i].SecondsInPreviousAttempts;
                qi.AncestorId = rsList[i].AncestorId;
                qi.RetryNumber = rsList[i].RetryNumber;
                qi.SpecificData = rsList[i].SpecificData;
                qi.TenantId = rsList[i].TenantId;
                qi.LastModificationTime = rsList[i].LastModificationTime;
                qi.LastModifierUserId = rsList[i].LastModifierUserId;
                qi.CreationTime = rsList[i].CreationTime;
                qi.CreatorUserId = rsList[i].CreatorUserId;
                qi.DeferDate = rsList[i].DeferDate;
                qi.DueDate = rsList[i].DueDate;
                qi.Progress = rsList[i].Progress;
                qi.Output = rsList[i].Output;
                qi.OrganizationUnitId = rsList[i].OrganizationUnitId;
                //qi.RowVersion = rsList[i].Rowersion;
                qi.ProcessingExceptionType = rsList[i].ProcessingExceptionType;
                qi.HasDueDate = rsList[i].HasDueDate;
                qi.Reference = rsList[i].Reference;
                qi.ReviewerUserId = rsList[i].ReviewerUserId;
                qi.ProcessingExceptionReason = rsList[i].ProcessingExceptionReason;
                qi.ProcessingExceptionDetails = rsList[i].ProcessingExceptionDetails;
                qi.ProcessingExceptionAssociatedImageFilePath = rsList[i].ProcessingExceptionAssociatedImageFilePath;
                qi.ProcessingExceptionCreationTime = rsList[i].ProcessingExceptionCreationTime;
                qi.CreatorJobId = rsList[i].CreatorJobId;
                qi.ExecutorJobId = rsList[i].ExecutorJobId;
                qi.AnalyticsData = rsList[i].AnalyticsData;
                qi.RiskSlaDate = rsList[i].RiskSlaDate;
                qi.HasRiskSlaDate = rsList[i].HasRiskSlaDate;

                qiList.Add(qi);


            }


         return qiList;
        }
    }
}






