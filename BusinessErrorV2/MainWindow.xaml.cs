﻿using BusinessErrorV2.Business_logic;
using BusinessErrorV2.Databases;
using BusinessErrorV2.Models;
using BusinessErrorV2.Repository;
using BussinesErrorDashboard.Models;
using BussinesErrorDashboard.Repository;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusinessErrorV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<QueueItems> QueueItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            QueueItems  = new ObservableCollection<QueueItems>();
            EnvironmentRepository repo = new EnvironmentRepository();
            ProcessName.ItemsSource = repo.getProcessNames();

        }      

        private async void ButtonClick_Click(object sender, RoutedEventArgs e)
        {
            CheckValidations validate = new CheckValidations();
            bool vallidation =  validate.CheckValidation(SearchBox,FromDate,ToDate);
            if (vallidation)
            {
                DateTime? from = null;
                DateTime? to = null;
                QueueItemsRepository repo = new QueueItemsRepository();

                Spinner.Spin = true;
                var query = SearchBox.Text;
              
                try
                {
                    from = DateTime.Parse(FromDate.Text).Date;
                    to = DateTime.Parse(ToDate.Text).Date;
                }
                catch(Exception)
                {

                }
                //Get data from db
                IQueryable<QueueItems> data = await Task.Run(() => repo.getData(from, to, query));

                //Add to observable collection
                QueueItems = await Task.Run(() => addToList(data));

                //Set datagrid source
                DG.ItemsSource = QueueItems;

                Spinner.Spin = false;
            }
        }

        private void ButtonLog_Click(object sender, RoutedEventArgs e)
        {
            ElasticSearchRepository es = new ElasticSearchRepository();
            QueueItems item = (QueueItems)DG.SelectedItem;
            IReadOnlyCollection<LogModel> esData = es.getData(item.Key.ToString(),(DateTime)item.StartProcessing);

            string esDataString = "Process Name: " + esData.ElementAt(0).processName + "\n" +
               "Robot name: " + esData.ElementAt(0).robotName + "\n" +
               "Timestamp: " + esData.ElementAt(0).timeStamp + "\n" +
               "Transaction ID: " + esData.ElementAt(0).TransactionId + "\n" +
               "Message: " + esData.ElementAt(0).message;


            Popup1.IsOpen = true;
            text.Text = esDataString;

        }

        

        public void ClosePopup(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
        }

        private void ButtonExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Text documents (.xlsx)|*.xlsx"; // Filter files by extension
            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process save file dialog box results
            string fileName = "";
            if (result == true)
            {
                // Get document name and path
                fileName = dlg.FileName;
            }
            
            ConvertToExcel conv = new ConvertToExcel();
            conv.ConvertData(fileName, QueueItems);

        }

        private ObservableCollection<QueueItems> addToList(IQueryable<QueueItems> data1)
        {
            ObservableCollection<QueueItems> test = new ObservableCollection<QueueItems>();

            foreach (var row in data1)
            {
                test.Add(row);
            }
            
            return test;
        }

        //private void ProcessName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    EnvironmentRepository repo = new EnvironmentRepository();
        //    ProcessName.ItemsSource = repo.getProcessNames();
        //}
    }

}
