using LW_2_16_2.Data.Repository;
using LW_2_16_2.Models;
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

namespace LW_2_16_2.Forms.AddingPages
{
    /// <summary>
    /// Логика взаимодействия для AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Page
    {
        public AddVehicle()
        {
            InitializeComponent();
            LoadBodiesToComboBox();
            LoadBrandsToComboBox();
        }

        private void LoadBrandsToComboBox()
        {
            using (BrandRepository rep = new BrandRepository())
            {
                NewBrand_cb.ItemsSource = rep.GetList().Select(x => x.ToString());                
            }
        }

        private void LoadBodiesToComboBox()
        {
            using (BodyRepository rep = new BodyRepository())
            {
                NewBody_cb.ItemsSource = rep.GetList().Select(x => x.ToString());
            }
        }

        private void CreateVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (NewBrand_cb.SelectedIndex != -1 && NewModel_tb.Text != "" && NewBody_cb.SelectedIndex != -1)
            {
                int brandId, bodyId;

                using (BrandRepository rep = new BrandRepository())
                {
                    brandId = rep.GetList().First(x => x.BrandTitle == NewBrand_cb.SelectedValue.ToString()).Id;
                }

                using (BodyRepository rep = new BodyRepository())
                {
                    bodyId = rep.GetList().First(x => x.BodyTitle == NewBody_cb.SelectedValue.ToString()).Id;
                }

                Vehicle veh = new Vehicle()
                {
                    VehicleTitle = NewModel_tb.Text,
                    VehicleBodyId = bodyId,
                    VehicleBrandId = brandId
                };

                using (VehicleRepository rep = new VehicleRepository())
                {
                    rep.Create(veh);
                    rep.Save();
                }

                NavigationService.Navigate(new Forms.AdminWind());
            }
        }
    }
}
