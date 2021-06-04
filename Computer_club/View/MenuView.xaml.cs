using Computer_club.Controllers;
using Computer_club.View.UserControlls;
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
using System.Windows.Shapes;

namespace Computer_club.View
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class MenuView : Window
    {
        private Users _user;
        private ArrayOfComputers _computers;
        private ArrayOfMessages _messages;
        private IRequest _request;

        public MenuView(Users user)
        {
            InitializeComponent();
            _user = user;
            _request = new RequestIm("https://localhost:44383");
            _computers = _request.GetAllComputers();
            _messages = _request.GetAllMessages();
            stkTest.Children.Add(new InformationUC(_user));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ControllOpenWindows.RegistrationWindow(this);
        }

        /// <summary>
        /// Radiobuttons handler
        /// </summary>
        private void bt1_Checked(object sender, RoutedEventArgs e)
        {
            var btn = sender as RadioButton;
            stkTest.Children.Clear();
            _user = _request.GetUserByID(_user.ID);
            switch (btn.Name)
            {
                case "profBtn":
                    stkTest.Children.Add(new ProfileUC(_user));
                    break;
                case "compBtn":
                    stkTest.Children.Add(new ComputersUC(_computers, _user));
                    break;
                case "reservBtn":
                    stkTest.Children.Add(new ReservationUC(_user, _computers));
                    break;
                case "infoBtn":
                    stkTest.Children.Add(new InformationUC(_user));
                    break;
                case "locBtn":
                    stkTest.Children.Add(new LocationUC());
                    break;
                default:
                    break;
            }
        }

    }
}
