using LW_2_16_2.Data.Repository;
using LW_2_16_2.Forms.AdminWindow;
using LW_2_16_2.Forms.AdminWindow.TableItems;
using LW_2_16_2.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LW_2_16_2.Forms
{
    /// <summary>
    /// Логика взаимодействия для Adding.xaml
    /// </summary>
    public partial class AdminWind : Page
    {
        public DataGrid genTable;

        private object _editingObject;

        public AdminWind()
        {
            InitializeComponent();
            genTable = GeneralTable;
        }

        enum CurrentTable
        {
            Vehicles,
            Brands,
            Bodies
        }

        private CurrentTable _currentTable;

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Название марки";
            textColumn2.Binding = new Binding("Column2");
            if (genTable.Columns.Count == 4)
            {
                ShowVehicles(sender, e);
            }
            else if (genTable.Columns.Contains(textColumn2))
            {
                ShowBrands(sender, e);
            }
            else
            {
                ShowBodies(sender, e);
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            switch (_currentTable)
            {
                case CurrentTable.Vehicles: NavigationService.Navigate(new Forms.AddingPages.AddVehicle()); break;
                case CurrentTable.Brands: NavigationService.Navigate(new Forms.AddingPages.AddBrand()); break;
                case CurrentTable.Bodies: NavigationService.Navigate(new Forms.AddingPages.AddBody()); break;
                default: throw new Exception("No table selected");
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (genTable.SelectedIndex != -1)
            {
                switch (_currentTable)
                {
                    case CurrentTable.Vehicles:
                        {
                            int id1 = NonGenericToGeneric(genTable.ItemsSource).Select(x => (VehicleTableItem)x).ToList()[genTable.SelectedIndex].ID;
                            NavigationService.Navigate(new Forms.AddingPages.AddVehicle(id1));
                            break;
                        }
                        /*
                    case CurrentTable.Brands:
                        {
                            int id2 = NonGenericToGeneric(genTable.ItemsSource).Select(x => (BrandTableItem)x).ToList()[genTable.SelectedIndex].ID;
                            NavigationService.Navigate(new Forms.AddingPages.AddBrand(id2)); 
                            break;
                        }
                    case CurrentTable.Bodies:
                        {
                            int id3 = NonGenericToGeneric(genTable.ItemsSource).Select(x => (BodyTableItem)x).ToList()[genTable.SelectedIndex].ID;
                            NavigationService.Navigate(new Forms.AddingPages.AddBody(id3)); 
                            break;
                        }
                        */
                    default: throw new Exception("No table selected");
                }
            }
        }

        private void ShowVehicles(object sender, RoutedEventArgs e)
        {
            _currentTable = CurrentTable.Vehicles;

            using (VehicleRepository rep = new VehicleRepository())
            {
                genTable.ItemsSource = rep.GetList().Select(x => new VehicleTableItem(x)).ToList();
            }

            if (genTable.Columns.Count > 0)
            {
                genTable.Columns[0].Visibility = Visibility.Hidden;
                genTable.Columns[1].Header = "Модель";
                genTable.Columns[2].Header = "Марка";
                genTable.Columns[3].Header = "Кузов";

                SetColumnsWidth(4);
            }
        }

        private void ShowBodies(object sender, RoutedEventArgs e)
        {
            _currentTable = CurrentTable.Bodies;

            using (BodyRepository rep = new BodyRepository())
            {
                genTable.ItemsSource = rep.GetList().Select(x => new BodyTableItem(x)).ToList();
            }

            if (genTable.Columns.Count > 0)
            {
                genTable.Columns[0].Visibility = Visibility.Hidden;
                genTable.Columns[1].Header = "Название";
                genTable.Columns[2].Header = "Площадь кузова";

                SetColumnsWidth(3);
            }
        }

        private void ShowBrands(object sender, RoutedEventArgs e)
        {
            _currentTable = CurrentTable.Brands;

            using (BrandRepository rep = new BrandRepository())
            {
                genTable.ItemsSource = rep.GetList().Select(x => new BrandTableItem(x)).ToList();
            }

            if (genTable.Columns.Count > 0)
            {
                genTable.Columns[0].Visibility = Visibility.Hidden;
                genTable.Columns[1].Header = "Название";
                genTable.Columns[2].Header = "Страна";

                SetColumnsWidth(3);
            }
        }

        private void SetColumnsWidth(int columnsNumber)
        {
            // costil!
            int width = ((int)this.Width) - 150;

            if (columnsNumber == 3)
            {
                genTable.Columns[0].Width = width * 0.2;
                genTable.Columns[1].Width = width * 0.4;
                genTable.Columns[2].Width = width * 0.4;
            }
            else if (columnsNumber == 4)
            {
                genTable.Columns[0].Width = width * 0.1;
                genTable.Columns[1].Width = width * 0.3;
                genTable.Columns[2].Width = width * 0.3;
                genTable.Columns[3].Width = width * 0.3;
            }
        }

        private IEnumerable<object> NonGenericToGeneric(IEnumerable coll)
        {
            List<object> result = new List<object>();

            foreach (var i in coll)
            {
                result.Add(i);
            }

            return result;
        }
    }
}
