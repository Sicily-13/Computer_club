using Computer_club.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_club.ViewModel
{
    public class ComputersViewModel : ViewModelBase
    {
        private IRequest _request;
        private List<CorrectMessage> _allMessages;
        private Users _user;

        #region Properties
        private List<CorrectMessage> _messages;
        public List<CorrectMessage> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChange(nameof(Messages));
            }
        }

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChange(nameof(Comment));
            }
        }

        private Commander _sendComment;
        public Commander SendComment
        {
            get => _sendComment ?? (new Commander(obj => 
            {
                if (Comment == null)
                {
                    return;
                }
                _request.SendMessage(_user.ID, SelectedComputer.ID, Comment);
                _allMessages = GetТormalizedMessages(_request.GetAllMessages());
                Messages = _allMessages.Where(c => c.CID == SelectedComputer.ID).ToList();
                Comment = "";
            }));
        }

        /// <summary>
        /// Text field with information about computer
        /// </summary>
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

        /// <summary>
        /// All computers in UC
        /// </summary>
        private ArrayOfComputersComputers[] _computers;
        public ArrayOfComputersComputers[] Computers
        {
            get => _computers;
            set
            {
                _computers = value;
                OnPropertyChange(nameof(Computers));
            }
        }

        /// <summary>
        /// Selected computer in UC
        /// </summary>
        private ArrayOfComputersComputers _selectedComputer;
        public ArrayOfComputersComputers SelectedComputer
        {
            get => _selectedComputer;
            set
            {
                _selectedComputer = value;
                About = _selectedComputer.About;
                Messages = _allMessages.Where(c => c.CID == SelectedComputer.ID).ToList();
                OnPropertyChange(nameof(SelectedComputer));
            }
        }

        #endregion

        #region Methods
        private List<CorrectMessage> GetТormalizedMessages(ArrayOfMessages arrayOfMessages)
        {
            List<CorrectMessage> correctMessages = new List<CorrectMessage>();
            if (arrayOfMessages.Messages == null)
            {
                return correctMessages;
            }
            foreach (ArrayOfMessagesMessages m in arrayOfMessages.Messages)
            {
                var user = _request.GetUserByID(m.UsersID);
                correctMessages.Add(new CorrectMessage
                {
                    User = user.Surname + " " + user.Name,
                    Message = m.Content,
                    Date = m.Date.ToString(),
                    CID = m.ComputersID
                });
            }
            return correctMessages;
        }

        #endregion

        #region Constructor
        public ComputersViewModel(ArrayOfComputers computers, Users user)
        {  
            _request = new RequestIm("https://localhost:44383");
            Computers = computers.Computers;
            _user = user;
            _allMessages = GetТormalizedMessages(_request.GetAllMessages());
            Messages = _allMessages.Where(c=>c.CID == Computers[0].ID).ToList();
            SelectedComputer = Computers[0];
        }
        #endregion
    }
}
