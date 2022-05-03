using Microsoft.Win32;
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
    [Serializable]
    public partial class MainWindow : Window
    {
        private MyNewStack<Organization> currentCollection;

        public MainWindow()
        {
            InitializeComponent();

            currentCollection = new MyNewStack<Organization>();
            currentCollection.CollectionCountChanged += UpdateListBox;
            currentCollection.CollectionReferenceChanged += UpdateListBox;

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

        private void UpdateListBox()
        {
            lb_Collection.Items.Clear();
            foreach (var item in currentCollection)
            {
                lb_Collection.Items.Add(item);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_Collection.SelectedIndex > -1)
            {
                Organization obj = currentCollection[lb_Collection.SelectedIndex];
                tb_Name.Text = obj.Name;
                tb_City.Text = obj.City;
                tb_Salary.Text = obj.AverageSalary.ToString();
                cb_Type.SelectedIndex = 0;

                if (obj is Library lib)
                {
                    tb_Books.Text = lib.NumberOfBooks.ToString();
                    cb_Type.SelectedIndex = 1;
                }
                else if (obj is Factory f)
                {
                    tb_Production.Text = f.Production;
                    cb_Type.SelectedIndex = 2;
                }
                else if (obj is InsuranceCompany ic)
                {
                    tb_Clients.Text = ic.NumberOfClients.ToString();
                    cb_Type.SelectedIndex = 3;
                }
                else if (obj is ShipConstructingCompany scc)
                {
                    tb_Ships.Text = scc.ShipConstructed.ToString();
                    cb_Type.SelectedIndex = 4;
                }
            }
        }

        private void AddElement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (cb_Type.SelectedIndex)
                {
                    case 0: 
                        currentCollection.Push(new Organization(tb_Name.Text, tb_City.Text, double.Parse(tb_Salary.Text))); break;
                    case 1: 
                        currentCollection.Push(new Library(tb_Name.Text, tb_City.Text, int.Parse(tb_Books.Text), double.Parse(tb_Salary.Text))); break;
                    case 2: 
                        currentCollection.Push(new Factory(tb_Name.Text, tb_City.Text, tb_Production.Text, double.Parse(tb_Salary.Text))); break;
                    case 3: 
                        currentCollection.Push(new InsuranceCompany(tb_Name.Text, tb_City.Text, int.Parse(tb_Clients.Text), double.Parse(tb_Salary.Text))); break;
                    case 4: 
                        currentCollection.Push(new ShipConstructingCompany(tb_Name.Text, tb_City.Text, double.Parse(tb_Salary.Text)) { ShipConstructed = int.Parse(tb_Ships.Text) }); break;
                }
            }
            catch
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

        private void DeleteElement_Click(object sender, RoutedEventArgs e)
        {
            if (lb_Collection.SelectedIndex > -1)
            {
                currentCollection.Remove(lb_Collection.SelectedIndex);
            }
        }

        private void EditElement_Click(object sender, RoutedEventArgs e)
        {
            int index = lb_Collection.SelectedIndex;
            if (index > -1)
            {
                try
                {
                    switch (cb_Type.SelectedIndex)
                    {
                        case 0:
                            currentCollection[index] = new Organization(tb_Name.Text, tb_City.Text, double.Parse(tb_Salary.Text)); break;
                        case 1:
                            currentCollection[index] = new Library(tb_Name.Text, tb_City.Text, int.Parse(tb_Books.Text), double.Parse(tb_Salary.Text)); break;
                        case 2:
                            currentCollection[index] = new Factory(tb_Name.Text, tb_City.Text, tb_Production.Text, double.Parse(tb_Salary.Text)); break;
                        case 3:
                            currentCollection[index] = new InsuranceCompany(tb_Name.Text, tb_City.Text, int.Parse(tb_Clients.Text), double.Parse(tb_Salary.Text)); break;
                        case 4:
                            currentCollection[index] = new ShipConstructingCompany(tb_Name.Text, tb_City.Text, double.Parse(tb_Salary.Text)) { ShipConstructed = int.Parse(tb_Ships.Text) }; break;
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось отредакировать элемент");
                }
            }
        }

        private void SaveToBinaryFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "(*.dat)|*.dat"
            };

            if (dialog.ShowDialog() == true)
            {
                using (FileHandler fh = new FileHandler())
                {
                    fh.WriteBinary(dialog.FileName, currentCollection);
                }
            }
        }

        private void SaveToJSONFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "(*.json)|*.json"
            };

            if (dialog.ShowDialog() == true)
            {
                using (FileHandler fh = new FileHandler())
                {
                    fh.WriteJSON(dialog.FileName, currentCollection);
                }
            }
        }

        private void SaveToXMLFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "(*.xml)|*.xml"
            };

            if (dialog.ShowDialog() == true)
            {
                using (FileHandler fh = new FileHandler())
                {
                    fh.WriteXML(dialog.FileName, currentCollection);
                }
            }
        }

        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog()
                {
                    Filter = "*.dat,*.json,*.xml|*.dat;*.json;*.xml"
                };

                if (dialog.ShowDialog() == true)
                {
                    using (FileHandler fh = new FileHandler())
                    {
                        currentCollection = fh.ReadFile<Organization>(dialog.FileName);
                        currentCollection.CollectionCountChanged += UpdateListBox;
                        currentCollection.CollectionReferenceChanged += UpdateListBox;
                        UpdateListBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть файл");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
