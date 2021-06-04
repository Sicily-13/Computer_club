using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_club.ViewModel
{
    public class InformationViewModel : ViewModelBase
    {
        #region Properties
        private Users _user;
        private IRequest _request;
        private int _countOfPeople;
        public int CountOfPeople
        {
            get => _countOfPeople;
            set
            {
                _countOfPeople = value;
                OnPropertyChange(nameof(CountOfPeople));
            }
        }
        #endregion
        #region Constructor
        public InformationViewModel(Users user)
        {
            _user = user;
            _request = new RequestIm("https://localhost:44383");
            CountOfPeople = _request.CountUsers();
        }
        #endregion
    }
}
