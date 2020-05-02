using BusinessErrorV2.Databases;
using BussinesErrorDashboard.Models;
using BussinesErrorDashboard.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            DataAccess da = new DataAccess();
            UIpathData  = new ObservableCollection<QueueItems>();
            
        }

        private async void ButtonClick_Click(object sender, RoutedEventArgs e)
        {
            Spinner.Spin = true;
            var query = SearchBox.Text;
            DateTime from = DateTime.Parse(FromDate.Text).Date;
            DateTime to = DateTime.Parse(ToDate.Text).Date;

            QueueItemsRepository repo = new QueueItemsRepository();
            IQueryable<QueueItems> data = await Task.Run(() => repo.getData(from, to, query));

            UIpathData = await Task.Run(() => addToList(data));         
            DG.ItemsSource = UIpathData;
            Spinner.Spin = false;
            

            //elasticSearchRepository elastic = new elasticSearchRepository();
            //elastic.getData();
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
