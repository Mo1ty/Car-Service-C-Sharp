﻿using System;
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
        }

        private void Add_Customer(object sender, RoutedEventArgs e)
        {
            CustomerAddInfo addCustomerInfoWindow = new CustomerAddInfo();
            addCustomerInfoWindow.ShowDialog();
        }
    }
}
