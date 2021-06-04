using Computer_club.Controllers;
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

namespace Computer_club.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Registrate window after load view
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ControllOpenWindows.RegistrationWindow(this);
        }

    }
}
