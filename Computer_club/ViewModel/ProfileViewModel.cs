using Computer_club.Controllers;
using Computer_club.Repository;
using Computer_club.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Computer_club.ViewModel
{
    class ProfileViewModel : ViewModelBase
    {
        #region Properties
        private Users _user;
        private Border _bottomPanel;
        private IRequest _request;

        private Commander _openBalanceField;
        public Commander OpenBalanceField
        {
            get => _openBalanceField ?? (new Commander(obj =>
            {
                _bottomPanel = obj as Border;
                _bottomPanel.Visibility =
                _bottomPanel.Visibility == Visibility.Visible
                ? Visibility.Hidden
                : Visibility.Visible;
            }));
        }

        /// <summary>
        /// Event on button delete 
        /// </summary>
        private Commander _deleteUser;
        public Commander DeleteUser
        {
            get => _deleteUser ?? (new Commander(obj =>
             {
                 MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить " +
                     "аккаунт? (Все данные будут удалены)",
                     "Предупреждение",MessageBoxButton.YesNo);
                 if (res == MessageBoxResult.Yes)
                 {
                     _request.DeleteUser(_user.ID);
                     MessageBox.Show("Аккаунт удален. Это окно закроется через 5 секунд","Предупреждение");
                     Thread.Sleep(5000);
                     var window = new MainWindow();
                     ControllOpenWindows.CloseAllWindows();
                     window.Show();
                 }
                 else
                 {
                     return;
                 } 
             }));
            
        }

        /// <summary>
        /// event on button UpToBalance
        /// </summary>
        private Commander _upToBalance;
        public Commander UpToBalance
        {
            get=> _upToBalance ?? (new Commander(obj =>
            {
                if (NewBalance < 0)
                {
                    return;
                }
                _user = _request.UpToBalance(_user.ID, NewBalance);
                Balance = _user.Balance;
                NewBalance = 0;
                _bottomPanel.Visibility = Visibility.Hidden;
            }));
        }

        /// <summary>
        /// Field Name in UC
        /// </summary>
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
        /// <summary>
        /// Field Surname in UC
        /// </summary>
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

        /// <summary>
        /// Field Surname in UC
        /// </summary>
        private double? _balance;
        public double? Balance
        {
            get => Math.Round((double)_balance,2);
            set
            {
                _balance = value;
                OnPropertyChange(nameof(Balance));
            }
        }

        /// <summary>
        /// Textbox in UC
        /// </summary>
        private double _newBalance;
        public double NewBalance
        {
            get => _newBalance;
            set
            {
                _newBalance = value;
                OnPropertyChange(nameof(NewBalance));
            }
        }

        #endregion

        #region Constructor
        public ProfileViewModel(Users user)
        {
            _request = new RequestIm("https://localhost:44383");
            _user = user;
            UserName = _user.Name;
            Surname = _user.Surname;
            Balance = _user.Balance;
            Login = _user.Login;
            //Order = _request.GetUsersOrder(_user.ID);
        }
        #endregion

    }
}
