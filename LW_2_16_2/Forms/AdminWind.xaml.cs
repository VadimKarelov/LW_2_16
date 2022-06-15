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

namespace LW_2_16_2.Forms
{
    /// <summary>
    /// Логика взаимодействия для Adding.xaml
    /// </summary>
    public partial class AdminWind : Page
    {
        public DataGrid genTable = new DataGrid();
        public class DataItem
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
        }

        public class DataItem2
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public Button Column4 { get; set; }
            public Button Column5 { get; set; }
        }

        public AdminWind()
        {
            InitializeComponent();
            genTable = GeneralTable;
        }

        private void vehicle_brands_Click(object sender, RoutedEventArgs e)
        {
            genTable.Columns.Clear();
            genTable.Items.Clear();

            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "ID";
            textColumn.Binding = new Binding("Column1");
            genTable.Columns.Add(textColumn);

            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Название марки";
            textColumn2.Binding = new Binding("Column2");
            genTable.Columns.Add(textColumn2);

            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "Страна производства";
            textColumn3.Binding = new Binding("Column3");
            genTable.Columns.Add(textColumn3);

            for (int i = 0; i < 3; i++)
            {
                genTable.Items.Add(new DataItem { Column1 = "a.1", Column2 = "a.2", Column3 = "a.3" });
            }

            //genTable.Width = title.Width;
            int width = ((int)this.Width) - 150;
            genTable.VerticalAlignment = VerticalAlignment.Center;
            genTable.Columns[0].Width = width * 0.2;
            genTable.Columns[1].Width = width * 0.4;
            genTable.Columns[2].Width = width * 0.4;
        }
        private void vehicle_bodies_Click(object sender, RoutedEventArgs e)
        {
            genTable.Columns.Clear();
            genTable.Items.Clear();

            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "ID";
            textColumn.Binding = new Binding("Column1");
            genTable.Columns.Add(textColumn);

            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Тип кузова";
            textColumn2.Binding = new Binding("Column2");
            genTable.Columns.Add(textColumn2);

            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "Средняя площадь";
            textColumn3.Binding = new Binding("Column3");
            genTable.Columns.Add(textColumn3);

            for (int i = 0; i < 3; i++)
            {
                genTable.Items.Add(new DataItem2 { Column1 = "a.1", Column2 = "a.2", Column3 = "a.3" });
            }

            int width = ((int)this.Width) - 150;
            genTable.VerticalAlignment = VerticalAlignment.Center;
            genTable.Columns[0].Width = width * 0.2;
            genTable.Columns[1].Width = width * 0.4;
            genTable.Columns[2].Width = width * 0.4;
        }
        private void vehicle_Click(object sender, RoutedEventArgs e)
        {
            genTable.Columns.Clear();
            genTable.Items.Clear();

            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "ID";
            textColumn.Binding = new Binding("Column1");
            genTable.Columns.Add(textColumn);

            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Название автомобиля";
            textColumn2.Binding = new Binding("Column2");
            genTable.Columns.Add(textColumn2);

            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "Марка автомобиля";
            textColumn3.Binding = new Binding("Column3");
            genTable.Columns.Add(textColumn3);

            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Header = "Тип кузова";
            textColumn4.Binding = new Binding("Column4");
            genTable.Columns.Add(textColumn4);

            for (int i = 0; i < 3; i++)
            {
                genTable.Items.Add(new DataItem { Column1 = "a.1", Column2 = "a.2", Column3 = "a.3", Column4 = "a.4" });
            }

            //genTable.Width = title.Width;
            int width = ((int)this.Width) - 150;
            genTable.VerticalAlignment = VerticalAlignment.Center;
            genTable.Columns[0].Width = width * 0.1;
            genTable.Columns[1].Width = width * 0.3;
            genTable.Columns[2].Width = width * 0.3;
            genTable.Columns[3].Width = width * 0.3;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Название марки";
            textColumn2.Binding = new Binding("Column2");
            if (genTable.Columns.Count == 4)
            {
                vehicle_Click(sender, e);
            }
            else if (genTable.Columns.Contains(textColumn2))
            {
                vehicle_brands_Click(sender, e);
            }
            else
            {
                vehicle_bodies_Click(sender, e);
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Название марки";
            textColumn2.Binding = new Binding("Column2");
            if (genTable.Columns.Count == 4)
            {
                NavigationService.Navigate(new Forms.AddingPages.AddVehicle());
            }
            else if (genTable.Columns.Contains(textColumn2))
            {
                NavigationService.Navigate(new Forms.AddingPages.AddBrand());
            }
            else
            {
                NavigationService.Navigate(new Forms.AddingPages.AddBody());
            }
        }
    }
}
