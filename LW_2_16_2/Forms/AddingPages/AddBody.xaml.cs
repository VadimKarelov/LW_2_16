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
    /// Логика взаимодействия для AddBody.xaml
    /// </summary>
    public partial class AddBody : Page
    {
        public AddBody()
        {
            InitializeComponent();
        }

        private void CreateBody_Click(object sender, RoutedEventArgs e)
        {
            if (NewBody_tb.Text != "" && float.TryParse(NewSquare_tb.Text, out float res))
            {
                Body body = new Body()
                {
                    BodyTitle = NewBody_tb.Text,
                    BodySquare = res
                };

                using (BodyRepository rep = new BodyRepository())
                {
                    rep.Create(body);
                    rep.Save();
                }
            }
        }
    }
}
