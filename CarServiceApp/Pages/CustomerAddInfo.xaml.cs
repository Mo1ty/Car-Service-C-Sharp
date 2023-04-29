using CarServiceApp.EFCore;
using CarServiceApp.service;
using CarServiceApp.service.impl;
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
using System.Windows.Shapes;

namespace CarServiceApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CustomerAddInfo.xaml
    /// </summary>
    public partial class CustomerAddInfo : Window
    {
        private AddressService addressService = new AddressServiceImpl();
        private ClientService clientService = new ClientServiceImpl();

        public CustomerAddInfo()
        {
            InitializeComponent();
        }
        private void Close_app(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Collapse_app(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Address newAddress = new Address
            {
                City = City.Text,
                Street = Street.Text,
                HouseNumber = House.Text,
                PostalCode = PostalCode.Text
            };

            addressService.addAddress(newAddress);
            
            Client newClient = new Client
            {
                Name = FirstName.Text,
                Surname = LastName.Text,
                Email = Email.Text,
                BirthDate = DateTime.Parse(BirthDate.Text),
                DriverLicense = DriverLicense.Text,
                AddressId = newAddress.Id
        };
            clientService.addClient(newClient);

            this.Close();

        }
    }
}
