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

            foreach (var row in qI)
            {
                dr = dt.NewRow();

                for (int i = 0; i < 38; i++)
                {
                    dr[i] = qI[i];

                }
            }
            
            dt.Rows.Add(dr);



            //Save to excel workbook
            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];
            sheet.InsertDataTable(dt, true, 1, 1);
            book.SaveToFile(fileName);
        }
    }

    
}
