using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Computer_club
{
    public class RequestIm : IRequest
    {
        #region implementation

        public Users AddUser(Users user)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(
                $"{_baseUrl}/api/v1/AddUser/" +
                $"login={user.Login}&" +
                $"password={user.Password}&" +
                $"name={user.Name}&" +
                $"surname={user.Surname}" +
                $".xml");
            var httpresponse = (HttpWebResponse) httpRequest.GetResponse();
            string result = "";
            Users _user = new Users();
            using (Stream stream = httpresponse.GetResponseStream())
            {
                using (StreamReader streamreader = new StreamReader(stream))
                {
                    result = streamreader.ReadToEnd();
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(Users));
                    using (var reader = new StringReader(result))
                    {
                        _user = ((Users)xmlserializer.Deserialize(reader));
                    }
                }
            }
            return _user;
        }

        public int CountUsers()
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(
                $"{_baseUrl}/api/v1/Count/get.json");
            var httpResponce = (HttpWebResponse) httpRequest.GetResponse();
            string result = "";
            using (Stream stream = httpResponce.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    result =  streamReader.ReadToEnd();
                }
            }
            return int.Parse(result);
        }

        public void DeleteUser(int userID)
        {
            var httpRequest = (HttpWebRequest)HttpWebRequest.Create(
                $"{_baseUrl}/api/v1/DeleteUser/userID={userID}.json");
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Ошибка при удалении пользователя");
            }
        }

        public ArrayOfComputers GetAllComputers()
        {
            var httpRequest = (HttpWebRequest)HttpWebRequest.Create(
               $"{_baseUrl}/api/v1/Computers/get.xml");
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string result = "";
            ArrayOfComputers arrayOfComputers = new ArrayOfComputers();
            using (Stream stream = httpResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ArrayOfComputers));
                    using (var stringReader = new StringReader(result))
                    {
                        arrayOfComputers = (ArrayOfComputers)xmlSerializer.Deserialize(stringReader);
                    }
                }
            }
            return arrayOfComputers;
        }

        public Users GetUserByLoginAndPassword(string login, string password)
        {
           var httpRequest = (HttpWebRequest)WebRequest.Create(
               $"{_baseUrl}/api/v1/User/" +
               $"login={login}&" +
               $"password={password}" +
               $".xml");
            var httpresponse = (HttpWebResponse)httpRequest.GetResponse();
            string result = "";
            Users _user = new Users();
            using (Stream stream = httpresponse.GetResponseStream())
            {
                using (StreamReader streamreader = new StreamReader(stream))
                {
                    result = streamreader.ReadToEnd();
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(Users));
                    using (var reader = new StringReader(result))
                    {
                        _user = ((Users)xmlserializer.Deserialize(reader));
                    }
                }
            }
            return _user;
        }

        public double MakeAnOrder(int userID, int computerID, double timeInMunute)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(
               $"{_baseUrl}/api/v1/AddOrder/" +
               $"userID={userID}&" +
               $"computerID={computerID}&" +
               $"time={timeInMunute}" +
               $".json");
            var httpresponse = (HttpWebResponse) httpRequest.GetResponse();
            string result = "";
            Users _user = new Users();
            using (Stream stream = httpresponse.GetResponseStream())
            {
                using (StreamReader streamreader = new StreamReader(stream))
                {
                    result = streamreader.ReadToEnd();
                    Console.WriteLine();
                }
            }
            return double.Parse(result, new NumberFormatInfo { NumberDecimalSeparator = "." });
        }

        public Users UpToBalance(int userID, double money)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(
               $"{_baseUrl}/api/v1/UpToBalance/" +
               $"userID={userID}&" +
               $"money={money}" +
               $".xml");
            var httpresponse = (HttpWebResponse)httpRequest.GetResponse();
            string result = "";
            Users _user = new Users();
            using (Stream stream = httpresponse.GetResponseStream())
            {
                using (StreamReader streamreader = new StreamReader(stream))
                {
                    result = streamreader.ReadToEnd();
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(Users));
                    using (var reader = new StringReader(result))
                    {
                        _user = ((Users)xmlserializer.Deserialize(reader));
                    }
                }
            }
            return _user;
        }

        public ArrayOfOrders GetUsersOrder(int userID)
        {
            var httpRequest = (HttpWebRequest)HttpWebRequest.Create(
              $"{_baseUrl}/api/v1/Orders/userID={userID}.xml");
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string result = "";
            ArrayOfOrders arrayOfOrders = new ArrayOfOrders();
            using (Stream stream = httpResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ArrayOfOrders));
                    using (var stringReader = new StringReader(result))
                    {
                        arrayOfOrders = (ArrayOfOrders)xmlSerializer.Deserialize(stringReader);
                    }
                }
            }
            return arrayOfOrders;
        }

        public ArrayOfMessages GetAllMessages()
        {
            var httpRequest = HttpWebRequest.Create(
                $"{_baseUrl}/api/v1/GetMessages/get.xml");
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string result = "";
            ArrayOfMessages arrayOfMessages = new ArrayOfMessages();
            using (Stream stream = httpResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ArrayOfMessages));
                    using (var stringReader = new StringReader(result))
                    {
                        arrayOfMessages = (ArrayOfMessages)xmlSerializer.Deserialize(stringReader);
                    }
                }
            }
            return arrayOfMessages;
        }

        public void SendMessage(int userID, int computerID, string message)
        {
            var httpRequest = (HttpWebRequest)HttpWebRequest.Create(
              $"{_baseUrl}/api/v1/SendMessage/" +
              $"content={message.Replace(" ","(spc)").Replace("?","(qtn)")}&" +
              $"userID={userID}&"+
              $"computerID={computerID}.json");
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Ошибка при отправке сообщения");
            }
        }

        public Users GetUserByID(int userID)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(
               $"{_baseUrl}/api/v1/UserByID/" +
               $"userID={userID}" +
               $".xml");
            var httpresponse = (HttpWebResponse)httpRequest.GetResponse();
            string result = "";
            Users _user = new Users();
            using (Stream stream = httpresponse.GetResponseStream())
            {
                using (StreamReader streamreader = new StreamReader(stream))
                {
                    result = streamreader.ReadToEnd();
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(Users));
                    using (var reader = new StringReader(result))
                    {
                        _user = ((Users)xmlserializer.Deserialize(reader));
                    }
                }
            }
            return _user;
        }

        #endregion

        #region Constuctor and Varibles

        private string _baseUrl;

        public RequestIm(string url)
        {
            _baseUrl = url;
        }

        #endregion

    }
}
