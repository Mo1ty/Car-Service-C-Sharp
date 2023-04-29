using CarServiceApp.EFCore;
using CarServiceApp.repository;
using CarServiceApp.service;
using CarServiceApp.service.impl;
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
using System.Windows.Shapes;

namespace CarServiceApp.Pages
{
    /// <summary>
    /// Interaction logic for CreateDeal.xaml
    /// </summary>
    public partial class CreateDeal : Window

    {
        private DealService dealService = new DealServiceImpl();
        public CreateDeal()
        {
            InitializeComponent();
        }
        private void Close_app(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private ClientRepository clientRepository = new ClientRepository();
        private AddressRepository addressRepository = new AddressRepository();

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



            DateTime DT = string.IsNullOrEmpty(DealDateTime.Text) || !DealDateTime.Text.All(char.IsDigit) ? DateTime.Now : DateTime.Parse(DealDateTime.Text);
            if (
                !string.IsNullOrEmpty(CarId.Text) &&
                !string.IsNullOrEmpty(ClientId.Text) &&
                !string.IsNullOrEmpty(PaymentAccount.Text) &&
                !string.IsNullOrEmpty(CarId.Text) &&
                !string.IsNullOrEmpty(PaymentCode.Text) &&
                !string.IsNullOrEmpty(PaymentCode.Text) &&
                PaymentAccount.Text.All(char.IsDigit) &&
                PaymentCode.Text.All(char.IsDigit)
                )
            {
                Deal deal = new Deal()
                {
                    CarId = Guid.Parse(CarId.Text),
                    ClientId = Guid.Parse(ClientId.Text),
                    DealDateTime = DT,
                    PaymentAccount = long.Parse(PaymentAccount.Text),
                    PaymentCode = long.Parse(PaymentCode.Text)

                };
                dealService.addDeal(deal);
                this.Close();
            }
            else
            {
                Amination.Animation.AnimateLabel(BlinkingLabel);
            }
            


        }
    }
}
