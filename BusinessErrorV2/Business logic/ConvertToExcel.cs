using BusinessErrorV2.Databases;
using BussinesErrorDashboard.Repository;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessErrorV2.Business_logic
{
    class ConvertToExcel
    {
        public void ConvertData(string fileName, ObservableCollection<QueueItems> qI)
        {
            QueueItemsRepository repo = new QueueItemsRepository();
            
            
            DataTable dt = new DataTable();
            IEnumerable<string> columns = repo.getColumns();

            foreach (var column in columns)
            {
                dt.Columns.Add(column);
            }

            qI.ToArray();

            //Create rows
            DataRow dr = null;

           
            

            for (int j = 0; j < qI.Count(); j++)
            {
                dr = dt.NewRow();

                for (int i = 0; i < 36; i++)
                {
                    dr[i] = qI[j].Id.ToString();
                    i++;
                    dr[i] = qI[j].Priority.ToString();
                    i++;
                    dr[i] = qI[j].QueueDefinitionId.ToString();
                    i++;
                    dr[i] = qI[j].Key.ToString();
                    i++;
                    dr[i] = qI[j].Status.ToString();
                    i++;
                    dr[i] = qI[j].ReviewStatus.ToString();
                    i++;
                    dr[i] = qI[j].RobotId.ToString();
                    i++;
                    dr[i] = qI[j].StartProcessing.ToString();
                    i++;
                    dr[i] = qI[j].EndProcessing.ToString();
                    i++;
                    dr[i] = qI[j].SecondsInPreviousAttempts.ToString();
                    i++;
                    dr[i] = qI[j].AncestorId.ToString();
                    i++;
                    dr[i] = qI[j].RetryNumber.ToString();
                    i++;
                    dr[i] = qI[j].SpecificData;
                    i++;
                    dr[i] = qI[j].TenantId.ToString();
                    i++;
                    dr[i] = qI[j].LastModificationTime.ToString();
                    i++;
                    dr[i] = qI[j].LastModifierUserId.ToString();
                    i++;
                    dr[i] = qI[j].CreationTime.ToString();
                    i++;
                    dr[i] = qI[j].CreatorUserId.ToString();
                    i++;
                    dr[i] = qI[j].DeferDate.ToString();
                    i++;
                    dr[i] = qI[j].DueDate.ToString();
                    i++;
                    dr[i] = qI[j].Progress;
                    i++;
                    dr[i] = qI[j].Output;
                    i++;
                    dr[i] = qI[j].OrganizationUnitId.ToString();
                    i++;
                    dr[i] = qI[j].RowVersion.ToString();
                    i++;
                    dr[i] = qI[j].ProcessingExceptionType.ToString();
                    i++;
                    dr[i] = qI[j].HasDueDate.ToString();
                    i++;
                    dr[i] = qI[j].Reference;
                    i++;
                    dr[i] = qI[j].ReviewerUserId.ToString();
                    i++;
                    dr[i] = qI[j].ProcessingExceptionReason;
                    i++;
                    dr[i] = qI[j].ProcessingExceptionDetails;
                    i++;
                    dr[i] = qI[j].ProcessingExceptionAssociatedImageFilePath;
                    i++;
                    dr[i] = qI[j].ProcessingExceptionCreationTime.ToString();
                    i++;
                    dr[i] = qI[j].CreatorJobId.ToString();
                    i++;
                    dr[i] = qI[j].ExecutorJobId.ToString();
                    i++;
                    dr[i] = qI[j].QueueDefinitions.ToString();
                    i++;
                    dr[i] = qI[j].QueueItemComments.ToString();
                    i++;
                    dr[i] = qI[j].QueueItemEvents.ToString();
                    //dr[i] = qI[j].Robots.ToString();     
                    dt.Rows.Add(dr);
                }

                
            } 
                   

               
               
            
           

            //Save to excel workbook
            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];
            sheet.InsertDataTable(dt, true, 1, 1);
            book.SaveToFile(fileName);
        }
    }

    
}
