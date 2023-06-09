﻿using CarServiceApp.EFCore;
using CarServiceApp.EFCore.Context;
using CarServiceApp.Pages;
using CarServiceApp.test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
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

namespace CarServiceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isContextMigrated = false;
        private CarServiceContext context = ContextConfiguration.Context;
        private Prototype testValues = new Prototype();
        List<Page> Pagelist;
        private void MigrateContext()
        {
            context.Database.Migrate();
            _isContextMigrated = true;
        }

        public MainWindow()
        {
            if (!_isContextMigrated)
            {
                MigrateContext();
            }
            if(context.Conditions.IsNullOrEmpty())
            {
                testValues.addAll();
            }

            InitializeComponent();
            this.Pagelist = new List<Page>();
            Pagelist.Add(new HPage());
            Pagelist.Add(new CstPage());
            Pagelist.Add(new dealPage());
            Pagelist.Add(new CSVPage());
            Pagelist.Add(new about());
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

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ManeFrame.Content = Pagelist[0]; 
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            ManeFrame.Content = Pagelist[1];
        }

        private void Deals_Click(object sender, RoutedEventArgs e)
        {
            ManeFrame.Content = Pagelist[2];
        }

        private void CSV_Click(object sender, RoutedEventArgs e)
        {
            ManeFrame.Content = Pagelist[3];
        }

        private void About(object sender, RoutedEventArgs e)
        {
            ManeFrame.Content = Pagelist[4];
        }
    }
}
