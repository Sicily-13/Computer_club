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
    /// Логика взаимодействия для Information.xaml
    /// </summary>
    public partial class InformationUC : UserControl
    {
        private Users _user;
        
        public InformationUC(Users user)
        {
            InitializeComponent();
            _user = user;
            this.DataContext = new InformationViewModel(_user);
            WithUs.Source = new Uri(@"C:\Users\sveta\source\repos\Computer_club\Computer_club\Animations\Count.gif");
        }

        private void WithUs_MediaEnded(object sender, RoutedEventArgs e)
        {
            WithUs.Position = new TimeSpan(0,0,1);
            WithUs.Play();
        }
    }
}
