using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public class oneUser
    {
        public string username;
        public string password;
        public string name;
        public string surname;
        public string city;
        public string status;
        public string block;
    }

    static class Program
    {
        public static List<oneUser> myList = new List<oneUser>();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
