using Computer_club.ViewModel;
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
    /// Логика взаимодействия для ReservationUC.xaml
    /// </summary>
    public partial class ReservationUC : UserControl
    {
        private Users _user;
        private ArrayOfComputers _computers;

        public ReservationUC(Users user, ArrayOfComputers computers)
        {
            InitializeComponent();
            _user = user;
            _computers = computers;
            this.DataContext = new ReservationViewModel(_user,_computers);
            
        }
    }
}
