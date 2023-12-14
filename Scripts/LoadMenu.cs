using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompany.Forms;
using System.Data.OleDb;
using System.Reflection;


namespace TravelCompany.Scripts
{
    class LoadMenu
    {
        private MainForm form;
        private int userID;

        public LoadMenu(MainForm formM, int userid)
        {
            form = formM;
            userID = userid;
        }

        public bool Load()
        {
            bool checkCreate = true;
            try
            {
                ConnectionBD connect = new ConnectionBD();
                connect.OpenConnect();

                OleDbCommand myCommand = connect.connection.CreateCommand();
                myCommand.CommandText = $"select * from Меню WHERE `ID родительского пункта`=0 ORDER BY `Порядок`;";
                OleDbDataReader rd = myCommand.ExecuteReader();
                while (rd.Read())
                {
                    OleDbCommand userRights = connect.connection.CreateCommand();
                    userRights.CommandText = $"select * from `Права пользователя` WHERE `ID пользователя`={userID} AND `ID пункта меню`={rd["ID"]};";
                    OleDbDataReader userReader = userRights.ExecuteReader();
                    userReader.Read();
                    if (Convert.ToInt32(userReader["R"]) == 1 || Convert.ToInt32(userReader["W"]) == 1 || Convert.ToInt32(userReader["E"]) == 1 || Convert.ToInt32(userReader["D"]) == 1)
                    {
                        form.CreateItem(rd["Имя пункта"].ToString());

                        OleDbCommand commandPunkt = connect.connection.CreateCommand();
                        commandPunkt.CommandText = $"select * from Меню WHERE `ID родительского пункта`={rd["ID"]} ORDER BY `Порядок`;";
                        OleDbDataReader reader = commandPunkt.ExecuteReader();
                        while (reader.Read())
                        {
                            OleDbCommand userRights2 = connect.connection.CreateCommand();
                            userRights2.CommandText = $"select * from `Права пользователя` WHERE `ID пользователя`={userID} AND `ID пункта меню`={reader["ID"]};";
                            OleDbDataReader userReader2 = userRights2.ExecuteReader();
                            userReader2.Read();
                            if (Convert.ToInt32(userReader2["R"]) == 1 || Convert.ToInt32(userReader2["W"]) == 1 || Convert.ToInt32(userReader2["E"]) == 1 || Convert.ToInt32(userReader2["D"]) == 1)
                            {
                                form.CreateSecondItem(reader["Имя пункта"].ToString());
                                form.AddClick();
                                form.AddElem();
                            }
                        }
                        form.AddItem();
                    }

                }
                connect.CloseConnect();
            }
            catch
            {
                checkCreate = false;
            }
            return checkCreate;
        }

        public void LoadForm(string item)
        {
            ConnectionBD connect = new ConnectionBD();
            connect.OpenConnect();

            OleDbCommand myCommand = connect.connection.CreateCommand();
            myCommand.CommandText = $"select ID, `Имя DLL`, `Имя функции` from Меню WHERE StrComp('{item}', `Имя пункта`, 0) = 0;";
            OleDbDataReader rd = myCommand.ExecuteReader();

            // функции вызова с параметром клиента и без!

            while (rd.Read())
            {
                try
                {

                    string dll = rd["Имя DLL"] as string;
                    string nameClass = rd["Имя функции"] as string;
                    // загрузка dll
                    Assembly loadDll = Assembly.Load(dll);

                    Type ourClass = loadDll.GetType(dll + "." + nameClass);

                    // загрузка прав пользователя
                    OleDbCommand userRights = connect.connection.CreateCommand();
                    userRights.CommandText = $"select * from `Права пользователя` WHERE `ID пользователя`={userID} AND `ID пункта меню`={rd["ID"]};";
                    OleDbDataReader userReader = userRights.ExecuteReader();
                    userReader.Read();
                    Object[] rights = { Convert.ToInt32(userReader["R"]), Convert.ToInt32(userReader["W"]), Convert.ToInt32(userReader["E"]), Convert.ToInt32(userReader["D"]), form.User };
                    if (form.ClientAuth)
                    {
                        rights = new Object[] { form.Client }.Concat(rights).ToArray(); //соединяем клиента и права в один массив
                    }

                    Object instane = Activator.CreateInstance(ourClass, rights);
                    
                    //MethodInfo show = ourClass.GetMethod(nameClass, new Type[] { }, null); // запускаем функцию из dll
                    //show.Invoke(instane, null);
                }
                catch
                {
                    throw new Exception("Ошибка загрузки");
                }

            }
        }

        
    }
}
