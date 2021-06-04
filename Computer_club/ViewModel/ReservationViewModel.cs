using Computer_club.Controllers;
using Computer_club.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Computer_club.ViewModel
{
    class ReservationViewModel: ViewModelBase
    {
        #region Properties
        private Users _user;
        private ArrayOfComputers _computers;
        private IRequest _request;
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
        /// Field UserName in UC
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

        private double _time;
        public double Time
        {
            get => _time;
            set
            {
                _time = value;
                Price = Math.Round((Time / 60.0) * (double)SelectedItem.PricePerHour, 2);
                OnPropertyChange(nameof(Time));
            }
        }

        private double _price;
        public double Price
        {
            get => Math.Round((Time / 60.0) * (double)SelectedItem.PricePerHour, 2);
            set
            {
                _price = value;
                OnPropertyChange(nameof(Price));
            }
        }

        private ArrayOfComputersComputers[] _computersID;
        public ArrayOfComputersComputers[] ComputersID
        {
            get => _computersID;
            set
            {
                _computersID = value;
                OnPropertyChange(nameof(ComputersID));
            }
        }

        private ArrayOfComputersComputers _selectedItem;
        public ArrayOfComputersComputers SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                ComputerImage = _selectedItem.Image.ToBitmapImage();
                About = _selectedItem.About;
                OnPropertyChange(nameof(Price));
                OnPropertyChange(nameof(SelectedItem));
            }
        }

        private Commander _payment;
        public Commander Payment
        {
            get => _payment ?? (new Commander(obj =>
            {
                if (Time == 0)
                {
                    MessageBox.Show("Время не может быть равно 0","Ошибка");
                    return;
                }
                if (_user.Balance < (Time / 60.0) * SelectedItem.PricePerHour)
                {
                    MessageBox.Show($"У вас не достаточно средств", "Уведомление");
                    return;
                }
                else
                {
                    _user.Balance = _request.MakeAnOrder(_user.ID, SelectedItem.ID, Time);
                    MessageBox.Show($"Заказ на {Time} минут оформлен", "Уведомление");
                    Time = 0;
                    SelectedItem = ComputersID[0];
                }
            }));
        }

        private BitmapImage _computerImage;
        public BitmapImage ComputerImage
        {
            get => _computerImage;
            set
            {
                _computerImage = value;
                OnPropertyChange(nameof(ComputerImage));
            }
        }

        private string _about;
        public string About
        {
            get => _about;
            set
            {
                _about = value;
                OnPropertyChange(nameof(About));
            }
        }

        #endregion

        #region Constructor
        public ReservationViewModel(Users user, ArrayOfComputers computers)
        {
            _computers = computers;
            _user = user;
            _request = new RequestIm("https://localhost:44383");
            ComputersID = _computers.Computers;
            SelectedItem = ComputersID[0];
            UserName = _user.Name;
            Surname = _user.Surname;
        }
        #endregion

    }
}
