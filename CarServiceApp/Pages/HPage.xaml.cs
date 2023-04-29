using CarServiceApp.EFCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    /// Логика взаимодействия для HPage.xaml
    /// </summary>
    public partial class HPage : Page
    {
        public HPage()
        {
            InitializeComponent();

            updatecardadagrid();
        }

        private void Add_Car(object sender, RoutedEventArgs e)
        {
            CarAddInfo addCarInfoWindow = new CarAddInfo();
            addCarInfoWindow.ShowDialog();
        }



        public void updatecardadagrid()
        {
            using (var context = new CarServiceContext())
            {
                var car = context.Cars.ToList();
                var conditions = context.Conditions.ToList();
                var completetable = car.Join(
                    conditions,
                    car => car.ConditionId,
                    conditions => conditions.Id,
                    (car, conditions) => new
                    {
                        ID = car.Id,
                        Brand = car.Brand,
                        Model = car.Model,
                        IdentificationNumber = car.IdentificationNumber,
                        CarNumber = car.CarNumber,
                        ProductionTime = car.ProductionTime.ToString("dd-MM-yyyy"),
                        TestDriveable = car.TestDriveable,
                        ConditionState = conditions.ConditionState,
                        Description = conditions.Description
                    }).ToList();

                CarDataGrid.ItemsSource = completetable;

            }
        }

        private void Refresh_list(object sender, RoutedEventArgs e)
        {
            updatecardadagrid();
        }
    }
}
