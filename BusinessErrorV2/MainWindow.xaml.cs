using BusinessErrorV2.Databases;
using BussinesErrorDashboard.Models;
using BussinesErrorDashboard.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<QueueItems> UIpathData { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            UIpathData  = new ObservableCollection<QueueItems>();
            
        }

        

        private async void ButtonClick_Click(object sender, RoutedEventArgs e)
        {
            DateTime? from = null;
            DateTime? to = null;
            QueueItemsRepository repo = new QueueItemsRepository();

            Spinner.Spin = true;
            var query = SearchBox.Text;

            try
            {
                from = DateTime.Parse(FromDate.Text).Date;
            }
            catch(Exception exc)
            {

            }
            try
            {
                to = DateTime.Parse(ToDate.Text).Date;
            }
            catch (Exception exc)
            {

            }
            
            IQueryable<QueueItems> data = await Task.Run(() => repo.getData(from, to, query));

            UIpathData = await Task.Run(() => addToList(data));         
            DG.ItemsSource = UIpathData;
            Spinner.Spin = false;
            

            //elasticSearchRepository elastic = new elasticSearchRepository();
            //elastic.getData();
        }

        private void ButtonLog_Click(object sender, RoutedEventArgs e)
        {
            ElasticSearchRepository es = new ElasticSearchRepository();
            QueueItems item = (QueueItems)DG.SelectedItem;
            IReadOnlyCollection<LogModel> esData = es.getData(item.Key.ToString());

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


        private ObservableCollection<QueueItems> addToList(IQueryable<QueueItems> data1)
        {
            ObservableCollection<QueueItems> test = new ObservableCollection<QueueItems>();

            foreach (var row in data1)
            {
                test.Add(row);
            }
            
            return test;
        }


    }

}
