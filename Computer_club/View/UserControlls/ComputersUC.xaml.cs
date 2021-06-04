using Computer_club.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для ComputersUC.xaml
    /// </summary>
    public partial class ComputersUC : UserControl
    {
        private ArrayOfComputers _arrayOfComputers;
        private Users _user;
        public ComputersUC(ArrayOfComputers arrayOfComputers, Users user)
        {
            InitializeComponent();
            _arrayOfComputers = arrayOfComputers;
            _user = user;
            this.DataContext = new ComputersViewModel(_arrayOfComputers, _user);
        }

        private void colorBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            var b = sender as Border;
            b.BorderBrush = System.Windows.Media.Brushes.Red;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            var b = sender as Border;
            b.BorderBrush = System.Windows.Media.Brushes.White;
        }
    }
}
