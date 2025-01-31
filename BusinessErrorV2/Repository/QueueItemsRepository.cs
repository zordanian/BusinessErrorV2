﻿using BusinessErrorV2.Database2;
using BusinessErrorV2.Models;
using BusinessErrorV2.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessErrorV2.Repository
{
    public class QueueItemsRepository
    {
        private LinqToSQLDataContext db;
        private IQueryable<QueueItem> tQuery;
        private LinqToSQLRepository lqRepo;

        public QueueItemsRepository()
        {
            this.db = new LinqToSQLDataContext();
           
            
        }

        public IQueryable<QueueItem> getData(DateTime? from, DateTime? to,String query, string pName)
        {
            if (query != "" && from == null && to == null)
            {
                try
                {
                    tQuery = db.QueueItems.Where(c => c.Reference == query || c.SpecificData.Contains(query)).Take(5);
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
        public IList<string> getItem(string transactionId)
        {

            QueueItem qe = db.QueueItems.Single(c => c.Key.ToString() == transactionId);

            IList<string> str = new List<string>();

            str.Add(qe.Id.ToString());
            str.Add(qe.Priority.ToString());
            str.Add(qe.QueueDefinitionId.ToString());
            str.Add(qe.Key.ToString());
            str.Add(qe.Status.ToString());
            str.Add(qe.ReviewStatus.ToString());
            str.Add(qe.RobotId.ToString());
            str.Add(qe.StartProcessing.ToString());
            str.Add(qe.EndProcessing.ToString());
            str.Add(qe.SecondsInPreviousAttempts.ToString());
            str.Add(qe.AncestorId.ToString());
            str.Add(qe.RetryNumber.ToString());
            str.Add(qe.SpecificData);
            str.Add(qe.TenantId.ToString());
            str.Add(qe.LastModificationTime.ToString());
            str.Add(qe.LastModifierUserId.ToString());
            str.Add(qe.CreationTime.ToString());
            str.Add(qe.CreatorUserId.ToString());
            str.Add(qe.DeferDate.ToString());
            str.Add(qe.DueDate.ToString());
            str.Add(qe.Progress);
            str.Add(qe.Output);
            str.Add(qe.OrganizationUnitId.ToString());
            str.Add(qe.RowVersion.ToString());
            str.Add(qe.ProcessingExceptionType.ToString());
            str.Add(qe.HasDueDate.ToString());
            str.Add(qe.Reference);
            str.Add(qe.ReviewerUserId.ToString());
            str.Add(qe.ProcessingExceptionReason);
            str.Add(qe.ProcessingExceptionDetails);
            str.Add(qe.ProcessingExceptionAssociatedImageFilePath);
            str.Add(qe.ProcessingExceptionCreationTime.ToString());
            str.Add(qe.CreatorJobId.ToString());           
            str.Add(qe.ExecutorJobId.ToString());
            //str.Add(qe.QueueDefinitions.ToString());
            //str.Add(qe.QueueItemComments.ToString());
            //str.Add(qe.QueueItemEvents.ToString());
            //str.Add(qe.Robots.ToString());
            //str.Add(qe.Users.ToString());

            return str;
        }

        public IEnumerable<string> getColumns()
        {
            var names = typeof(QueueItem).GetProperties()
                        .Select(property => property.Name)
                        .ToArray();
            return names;
        }


    }
}
