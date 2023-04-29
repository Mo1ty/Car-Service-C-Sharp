using CarServiceApp.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace CarServiceApp.Pages
{
    /// <summary>
    /// Interaction logic for CSVPage.xaml
    /// </summary>
    public partial class CSVPage : Page
    {
        AddressRepository addressRepository = new AddressRepository();
        CarRepository carRepository = new CarRepository();
        ClientRepository clientRepository = new ClientRepository();
        ConditionRepository conditionRepository = new ConditionRepository();
        DealRepository dealRepository = new DealRepository();
        public CSVPage()
        {
            InitializeComponent();
        }

        private void ImportCSV(object sender, RoutedEventArgs e)
        {
            conditionRepository.importCSV(Path.Text);
            /*
            addressRepository.importCSV(Path.Text);
            carRepository.importCSV(Path.Text);
            clientRepository.importCSV(Path.Text);
            dealRepository.importCSV(Path.Text);
            */
            MessageBox.Show($"Data was imported from {Path.Text}");
        }

        private void ExportCSV(object sender, RoutedEventArgs e)
        {
            
            dealRepository.exportToCSV(Path.Text);
            addressRepository.exportToCSV(Path.Text);
            carRepository.exportToCSV(Path.Text);
            clientRepository.exportToCSV(Path.Text);
            conditionRepository.exportToCSV(Path.Text);
            MessageBox.Show($"Data was exported to {Path.Text}");
        }

    }
}
