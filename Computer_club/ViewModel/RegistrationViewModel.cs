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
    public class RegistrationViewModel : ViewModelBase
    {
        #region Properties
        private IRequest _request;

        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChange(nameof(Surname));
            }
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChange(nameof(UserName));
            }
        }

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

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }

        private int _balance;
        public int Balance
        {
            get => _balance;
            set
            {
                _balance = value;
            }
        }

        private Commander _signUp;
        public Commander SignUp
        {
            get => _signUp ?? (new Commander(obj =>
            {

                var pass = obj as PasswordBox;
                Password = pass.Password;
                if (UserName == "" || Surname == "" || Login == "" || Password == "")
                {
                    MessageBox.Show("Есть незаполненные поля","Ошибка регистрации");
                    return;
                }
                Users user = _request.AddUser(new Users
                {
                    Name = UserName,
                    Surname = Surname,
                    Login = Login,
                    Password = Password
                });
                var window = new MenuView(user);
                ControllOpenWindows.CloseAllWindows();
                window.Show();
            }));
        }

        private Commander _back;
        public Commander Back
        {
            get => _back ?? (new Commander(obj =>
            {
                 var window = new MainWindow();
                 ControllOpenWindows.CloseAllWindows();
                 window.Show();
             }));
        }

        #endregion

        #region Constructor

        public RegistrationViewModel()
        {
            _request = new RequestIm("https://localhost:44383");
        }
        #endregion
    }
}

