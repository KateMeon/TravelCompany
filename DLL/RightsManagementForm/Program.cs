using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompany;

namespace RightsManagementForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //проверка формы
            //User user = new User("Admin", "admin");
            //RightsManagement right = new RightsManagement(1, 1, 1, 1, user);

            Application.Run(new Form1());
        }
    }
}
