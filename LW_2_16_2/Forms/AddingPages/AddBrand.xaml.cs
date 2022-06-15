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
    /// Логика взаимодействия для AddBrand.xaml
    /// </summary>
    public partial class AddBrand : Page
    {
        public AddBrand()
        {
            InitializeComponent();
        }

        private void CreateBrand_Click(object sender, RoutedEventArgs e)
        {
            if (NewBrand_tb.Text != "" && NewCountry_tb.Text != "")
            {
                Brand brand = new Brand()
                {
                    BrandTitle = NewBrand_tb.Text,
                    BrandCountry = NewCountry_tb.Text
                };

                using (BrandRepository rep = new BrandRepository())
                {
                    rep.Create(brand);
                    rep.Save();
                }

                NavigationService.Navigate(new Forms.AdminWind());
            }
        }
    }
}
