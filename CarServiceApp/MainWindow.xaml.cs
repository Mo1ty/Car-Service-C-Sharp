﻿using CarServiceApp.EFCore;
using Microsoft.EntityFrameworkCore;
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
        CarServiceContext context = new CarServiceContext();

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
            InitializeComponent();
        }
    }
}
