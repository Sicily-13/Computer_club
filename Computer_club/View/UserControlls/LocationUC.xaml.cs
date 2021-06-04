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

namespace Computer_club.View.UserControlls
{
    /// <summary>
    /// Логика взаимодействия для LocationUC.xaml
    /// </summary>
    public partial class LocationUC : UserControl
    {
        public LocationUC()
        {
            InitializeComponent();
            point.Source = new Uri(@"C:\Users\sveta\source\repos\Computer_club\Computer_club\Animations\loc.gif");


        }

        private void point_MediaEnded(object sender, RoutedEventArgs e)
        {
            point.Position = new TimeSpan(0, 0, 1);
            point.Play();
        }
    }
}
