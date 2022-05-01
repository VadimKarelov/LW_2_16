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

namespace LW_2_16_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyNewStack<Organization> currentCollection;

        public MainWindow()
        {
            InitializeComponent();

            currentCollection = new MyNewStack<Organization>();
            currentCollection.CollectionCountChanged += UpdateListBox;

            cb_Type.SelectedIndex = 0;
        }

        private void UpdateListBox(object sender, MyStackHandlerEventArgs<Organization> args)
        {
            lb_Collection.Items.Clear();
            foreach (var item in currentCollection)
            {
                lb_Collection.Items.Add(item);
            }
        }

        private void AddElement_Click(object sender, RoutedEventArgs e)
        {
            switch (cb_Type.SelectedIndex)
            {
                case 0: AddOrganization(); break;
                case 1: AddLibary(); break;
                case 2: AddFactory(); break;
                case 3: AddInsuranceCompany(); break;
                case 4: AddShipConstructingCompany(); break;
            }
        }

        private void AddOrganization()
        {
            if (double.TryParse(tb_Salary.Text, out double sal))
            {
                currentCollection.Push(new Organization(tb_Name.Text, tb_City.Text, sal));
            }
            else
            {
                MessageBox.Show("Не удалось добавить элемент");
            }
        }

        private void AddLibary()
        {
            if (double.TryParse(tb_Salary.Text, out double sal) && int.TryParse(tb_Books.Text, out int books))
            {
                currentCollection.Push(new Library(tb_Name.Text, tb_City.Text, books, sal));
            }
            else
            {
                MessageBox.Show("Не удалось добавить элемент");
            }
        }

        private void AddFactory()
        {
            if (double.TryParse(tb_Salary.Text, out double sal))
            {
                currentCollection.Push(new Factory(tb_Name.Text, tb_City.Text, tb_Production.Text, sal));
            }
            else
            {
                MessageBox.Show("Не удалось добавить элемент");
            }
        }

        private void AddInsuranceCompany()
        {
            if (double.TryParse(tb_Salary.Text, out double sal) && int.TryParse(tb_Clients.Text, out int clients))
            {
                currentCollection.Push(new InsuranceCompany(tb_Name.Text, tb_City.Text, clients, sal));
            }
            else
            {
                MessageBox.Show("Не удалось добавить элемент");
            }
        }

        private void AddShipConstructingCompany()
        {
            if (double.TryParse(tb_Salary.Text, out double sal) && int.TryParse(tb_Ships.Text, out int ships))
            {
                currentCollection.Push(new ShipConstructingCompany(tb_Name.Text, tb_City.Text, sal) { ShipConstructed = ships });
            }
            else
            {
                MessageBox.Show("Не удалось добавить элемент");
            }
        }

        private void TypeChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb_Type.SelectedIndex)
            {
                case 0:
                    {
                        // organization
                        tb_Books.IsEnabled = false;
                        tb_Production.IsEnabled = false;
                        tb_Clients.IsEnabled = false;
                        tb_Ships.IsEnabled = false;
                        break;
                    }
                case 1:
                    {
                        // library
                        tb_Books.IsEnabled = true;
                        tb_Production.IsEnabled = false;
                        tb_Clients.IsEnabled = false;
                        tb_Ships.IsEnabled = false;
                        break;
                    }
                case 2:
                    {
                        // factory
                        tb_Books.IsEnabled = false;
                        tb_Production.IsEnabled = true;
                        tb_Clients.IsEnabled = false;
                        tb_Ships.IsEnabled = false;
                        break;
                    }
                case 3:
                    {
                        // insurance
                        tb_Books.IsEnabled = false;
                        tb_Production.IsEnabled = false;
                        tb_Clients.IsEnabled = true;
                        tb_Ships.IsEnabled = false;
                        break;
                    }
                case 4:
                    {
                        // ship
                        tb_Books.IsEnabled = false;
                        tb_Production.IsEnabled = false;
                        tb_Clients.IsEnabled = false;
                        tb_Ships.IsEnabled = true;
                        break;
                    }
            }
        }

        private void EnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.IsEnabled)
                {
                    //tb.Background = Brushes.White;
                    tb.Background = new SolidColorBrush(Colors.White);
                    //tb.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0, 0));
                    //tb.Background = System.Windows.SystemColors.MenuHighlightBrush;
                }
                else
                {
                    tb.Background = new SolidColorBrush(Colors.DarkOrange);
                }
            }
        }
    }
}
