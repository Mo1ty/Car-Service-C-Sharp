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
        DateTime BD;
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
            
            
            if(DateTime.TryParse(BirthDate.Text, out BD))
            {
                if (
                !string.IsNullOrEmpty(FirstName.Text) &&
                !string.IsNullOrEmpty(LastName.Text) &&
                !string.IsNullOrEmpty(Email.Text) &&
                !string.IsNullOrEmpty(DriverLicense.Text) &&
                !string.IsNullOrEmpty(City.Text) &&
                !string.IsNullOrEmpty(Street.Text) &&
                !string.IsNullOrEmpty(House.Text) &&
                !string.IsNullOrEmpty(PostalCode.Text)
                )
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
                        BirthDate = BD,
                        DriverLicense = DriverLicense.Text,
                        AddressId = newAddress.Id
                    };
                    clientService.addClient(newClient);

                    this.Close();
                }
                else
                {
                    Amination.Animation.AnimateLabel(BlinkingLabel);
                }
            }
            else
            {
                Amination.Animation.AnimateLabel(BlinkingLabelBD);
            }            
            

        }
    }
}
