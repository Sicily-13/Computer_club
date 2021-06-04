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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class ProfileUC : UserControl
    {
        private Users _user;
        private IRequest _request;
        public ProfileUC(Users user)
        {
            InitializeComponent();
            _user = user;
            this.DataContext = new ProfileViewModel(_user);
            _request = new RequestIm("https://localhost:44383");
            listOfOrders.ItemsSource = GetOrders(_request.GetUsersOrder(_user.ID));
        }

        private List<Orders> GetOrders(ArrayOfOrders arrayOfOrders)
        {
            List<Orders> orders = new List<Orders>();
            if (arrayOfOrders.Orders == null)
            {
                return orders;
            }
            foreach (ArrayOfOrdersOrders o in arrayOfOrders.Orders)
            {
                orders.Add(new Orders
                {
                    ID = "UID "+ o.ID.ToString(),
                    ComputersID = "CID " + o.ComputersID.ToString(),
                    Time = o.Time.ToString() + " Minutes"
                });
            }
            return orders;
        }

        class Orders
        {
            public string ID { get; set; }
            public string Time { get; set; }
            public string ComputersID { get; set; }
        }
    }
}
