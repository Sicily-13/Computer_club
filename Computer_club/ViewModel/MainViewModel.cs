using Computer_club.Controllers;
using Computer_club.Repository;
using Computer_club.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Computer_club.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        private IRequest _request;
        /// <summary>
        /// Login on MainWindow
        /// </summary>
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChange(nameof(Login));
            }
        }

        /// <summary>
        /// Password on MainWindow
        /// </summary>
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }

        private Commander _signIn;
        public Commander SignIn
        {
            get => _signIn ?? (new Commander(obj =>
            {
                var pass = obj as PasswordBox;
                Password = pass.Password;
                if ((Login == "") || (Password == ""))
                {
                    MessageBox.Show("Есть незаполненные поля", "Ошибка входа");
                    return;
                }
                Users user = _request.GetUserByLoginAndPassword(Login,Password);
                if (user.Name == "default")
                {
                    MessageBox.Show("Такого пользователя нет","Ошибка входа");
                    return;
                }
                else
                {
                    var window = new MenuView(user);
                    ControllOpenWindows.CloseAllWindows();
                    window.Show();
                }
                
            }));

        }

        private Commander _signUp;
        public Commander SignUp
        {
            get => _signUp ?? (new Commander( obj =>
                {
                    
                    var window = new Registration();
                    ControllOpenWindows.CloseAllWindows();
                    window.Show();
                }));
        }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            _request = new RequestIm("https://localhost:44383");
        }
        #endregion
    }
}
