using CarServiceApp.service.impl;
using CarServiceApp.service;
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
using CarServiceApp.EFCore;
using System.Reflection.Metadata;
using System.Windows.Automation;
using System.Threading;

namespace CarServiceApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarAddInfo.xaml
    /// </summary>
    public partial class CarAddInfo : Window
    {
        private CarsService carsService = new CarsServiceImpl();
        bool TD;
        string ConState;
        private ConditionService conditionService = new ConditionServiceImpl();

        public CarAddInfo()
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
            

            CarServiceApp.EFCore.Condition condition = new CarServiceApp.EFCore.Condition()
            {
                ConditionState = ConState,
                Description = Description.Text
            };
            conditionService.addCondition(condition);
            DateTime DT = string.IsNullOrEmpty(ProductionTime.Text) || !ProductionTime.Text.All(char.IsDigit) ? DateTime.Now : DateTime.Parse(ProductionTime.Text);
            Car car = new Car()
            {
                Brand = Brand.Text,
                Model = Model.Text,
                IdentificationNumber = IdentificationNumber.Text,
                CarNumber = CarNumber.Text,
                ProductionTime = DT,
                TestDriveable = TD,
                ConditionId = condition.Id
            };
            carsService.addCar(car);

            this.Close();
        }

        private void TestDriveable_No(object sender, RoutedEventArgs e)
        {
            TD = false;
        }

        private void TestDriveable_Yes(object sender, RoutedEventArgs e)
        {
            TD = true;
        }

        private void CnStateSold(object sender, RoutedEventArgs e)
        {
            ConState = "Sold";
        }

        private void CnStateGood(object sender, RoutedEventArgs e)
        {
            ConState = "Good";
        }

        private void CnStateBad(object sender, RoutedEventArgs e)
        {
            ConState = "Bad";
        }
    }
}
