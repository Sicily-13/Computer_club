using Computer_club.Controllers;
using Computer_club.Repository;
using Computer_club.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_club.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        private Commander _exit;
        public Commander Exit
        {
            get => _exit ?? (new Commander(obj => 
            {
                var window = new MainWindow();
                ControllOpenWindows.CloseAllWindows();
                window.Show();
            }));
        }

        private Commander _close;
        public Commander Close
        {
            get => _close ?? ( new Commander(obj =>
            {
                ControllOpenWindows.CloseAllWindows();
            }));
        } 

        
    }

}
