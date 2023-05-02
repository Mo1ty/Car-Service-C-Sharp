using CarServiceApp.EFCore;
using CarServiceApp.service;
using System;
using System.Collections;
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
    /// Логика взаимодействия для CstPage.xaml
    /// </summary>
    public partial class CstPage : Page
    {
        public CstPage()
        {
            InitializeComponent();
            updatecustomerdadagrid();
            
        }

        private void Add_Customer(object sender, RoutedEventArgs e)
        {
            CustomerAddInfo addCustomerInfoWindow = new CustomerAddInfo();
            addCustomerInfoWindow.ShowDialog();
        }
        public void updatecustomerdadagrid()
        {
            using (var context = new CarServiceContext())
            {
                var clients = context.Clients.ToList();
                var addresses = context.Addresses.ToList();

                var completetable = clients.Join(
                    addresses,
                    client => client.AddressId,
                    address => address.Id,
                    (client, address) => new
                    {
                        ID = client.Id,
                        FullName = $"{client.Name} {client.Surname}",
                        Email = client.Email,
                        BirthDate = client.BirthDate.ToString("dd-MM-yyyy"), 
                        DriverLicense = client.DriverLicense,
                        Address = $"{address.City} {address.Street} {address.HouseNumber} {address.PostalCode}",
                    }).ToList();


                CustomerDataGrid.ItemsSource = completetable;
            }


        }

        private void Refresh_list(object sender, RoutedEventArgs e)
        {
            updatecustomerdadagrid();
            parse.Pars.parseID();
        }
        private void ExecuteCopy(object sender, ExecutedRoutedEventArgs e)
        {
            parse.Pars.parseID();
        }
    }
}
