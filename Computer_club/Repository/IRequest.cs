using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_club
{
    public interface IRequest
    {
        ArrayOfComputers GetAllComputers();

        Users GetUserByLoginAndPassword(string login, string password);

        Users AddUser(Users user);

        double MakeAnOrder(int userID, int computerID, double timeInMunute);

        int CountUsers();

        void DeleteUser(int userID);

        Users UpToBalance(int userID, double money);

        ArrayOfOrders GetUsersOrder(int userID);

        ArrayOfMessages GetAllMessages();

        void SendMessage(int userID, int computerID, string message);

        Users GetUserByID(int userID);
    }
}
