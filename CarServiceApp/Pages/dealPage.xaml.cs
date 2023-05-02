using CarServiceApp.EFCore;
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
    /// Interaction logic for dealPage.xaml
    /// </summary>
    public partial class dealPage : Page
    {
        public dealPage()
        {
            InitializeComponent();
            updatecardadagrid();
        }

        private void Add_Customer(object sender, RoutedEventArgs e)
        {
            CreateDeal createDeal = new CreateDeal();
            createDeal.Show();
        }

        private void Refresh_list(object sender, RoutedEventArgs e)
        {
            updatecardadagrid();
        }
        public void updatecardadagrid()
        {
            using (var context = new CarServiceContext())
            {

                var cars = context.Cars.ToList();
                var clients = context.Clients.ToList();
                var deals = context.Deals.ToList();

                var combinedTable = deals
                    .Join(
                        clients,
                        deal => deal.ClientId,
                        client => client.Id,
                        (deal, client) => new { Deal = deal, Client = client }
                    )
                    .Join(
                        cars,
                        dealClient => dealClient.Deal.CarId,
                        car => car.Id,
                        (dealClient, car) => new
                        {
                            Car = $"{car.Brand} {car.Model}",
                            Client= $"{dealClient.Client.Name} {dealClient.Client.Surname}",
                            DealDateTime = dealClient.Deal.DealDateTime.ToString("dd-MM-yyyy"),
                            PaymentAccount = dealClient.Deal.PaymentAccount,
                            PaymentCode = dealClient.Deal.PaymentCode
                        }
                    ).ToList();
                DealDataGrid.ItemsSource = combinedTable;
                

            }
        }
    }
}
