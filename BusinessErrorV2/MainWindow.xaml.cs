using BusinessErrorV2.Business_logic;
using BusinessErrorV2.Database2;
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


namespace BusinessErrorV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<QueueItem> QIList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            QIList  = new ObservableCollection<QueueItem>();
            EnvironmentRepository repo = new EnvironmentRepository();
            ProcessName.ItemsSource = repo.getProcessNames();
            
        }      

        private async void ButtonClick_Click(object sender, RoutedEventArgs e)
        {
            CheckValidations validate = new CheckValidations();
            bool vallidation =  validate.CheckValidation(SearchBox,FromDate,ToDate, ProcessName);
            if (vallidation)
            {
                DateTime? from = null;
                DateTime? to = null;
                QueueItemsRepository repo = new QueueItemsRepository();
                Spinner.Spin = true;
                string query = SearchBox.Text;
                String pName = ProcessName.Text;
                try
                {
                    from = DateTime.Parse(FromDate.Text).Date;
                    to = DateTime.Parse(ToDate.Text).Date;
                }
                catch { }

                LinqToSQLRepository LinqRepo = new LinqToSQLRepository();
                QIList = await Task.Run(() => LinqRepo.GetData(pName,query,from,to));
                
                DG.ItemsSource = QIList;
                Spinner.Spin = false;
            }
        }

        private async void ButtonLog_Click(object sender, RoutedEventArgs e)
        {
            ElasticSearchRepository es = new ElasticSearchRepository();
            QueueItem item = (QueueItem)DG.SelectedItem;
            IReadOnlyCollection<LogModel> esData = await Task.Run(() => es.getData(item.Key.ToString(),(DateTime)item.CreationTime));



            if (esData.Any())
            {
 
                DGPopup.ItemsSource = esData;
                Popup1.IsOpen = true;              
            }
            else
            {
                MessageBox.Show("The index from: " + item.CreationTime + " could not be found, or no data in index" , "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
            }

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
            conv.ConvertData(fileName, QIList);

        }

        private ObservableCollection<QueueItem> addToList(IQueryable<QueueItem> data)
        {
            ObservableCollection<QueueItem> oc = new ObservableCollection<QueueItem>();

            foreach (var row in data)
            {
                oc.Add(row);
            }
            
            return oc;
        }

        private void reset(object sender, RoutedEventArgs e)
        {
            FromDate.SelectedDate = null;
            ToDate.SelectedDate = null;
            ProcessName.Text = null;
            QIList.Clear();
            SearchBox.Text = "";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
        }
    }

}
