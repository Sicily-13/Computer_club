using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Computer_club.Controllers
{
    public static class ControllOpenWindows
    {
        private static List<Window> _windows = new List<Window>();

        public static void RegistrationWindow(Window window)
        {
            _windows.Add(window);
        }

        public static void CloseAllWindows()
        {
            foreach (Window win in _windows)
            {
                win.Close();
            }
        }
    }
}
