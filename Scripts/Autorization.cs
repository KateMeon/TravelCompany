using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using TravelCompany.Forms;
using System.IO;

namespace TravelCompany.Scripts
{
    class Autorization
    {
        private User user;
        private AuthorizationForm form;
       
        public Autorization(AuthorizationForm formA, string login, string password)
        {
            user = new User(login, password);
            form = formA;
        }
        public int AutorizationCheck()
        {
            ConnectionBD connect = new ConnectionBD();
            connect.OpenConnect();
            OleDbCommand myCommand = connect.connection.CreateCommand();
            myCommand.CommandText = $"select ID, Password, Login from Пользователи WHERE StrComp('{user.Login}', Login, 0) = 0;";

            OleDbDataReader myReader = myCommand.ExecuteReader();

            int resultConnect = 1;
            try
            {
                myReader.Read();
                string passwordBD = myReader["Password"] as string;

                if (passwordBD == user.Password)
                {
                    MainForm mainForm;
                    WorkBD work = new WorkBD();
                    if (work.CheckClient(Convert.ToInt32(myReader["ID"])))
                    {
                        Client client = work.TakeClient(Convert.ToInt32(myReader["ID"]));
                        mainForm = new MainForm(form, Convert.ToInt32(myReader["ID"]), client, user);
                    }
                    else
                    {
                       mainForm = new MainForm(form, Convert.ToInt32(myReader["ID"]), user);
                    }
                    mainForm.Show();
                }
                else
                {
                    resultConnect = 0;
                }
            }
            catch (Exception ex)
            {
                resultConnect = 0;
            }
            connect.CloseConnect();
            return resultConnect;
        }
        
    }
}
