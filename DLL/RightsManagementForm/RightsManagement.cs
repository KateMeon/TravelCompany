using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompany;
using System.Data.OleDb;

namespace RightsManagementForm
{
    public class RightsManagement
    {
        private User user;
        private int userId;
        private int check = 0;
        Form1 form;

        public int UserId
        {
            set
            {
                this.userId = value;
            }
            get
            {
                return this.userId;
            }
        }
        public RightsManagement(int pR, int pE, int pW, int pD, User userN)
        {
            user = userN;
            form = new Form1(pR, pE, pW, pD, this);
            StartForm();
            form.ShowDialog();
        }

        public RightsManagement(Client client, int pR, int pE, int pW, int pD, User userN)
        {
            user = userN;
            form = new Form1(pR, pE, pW, pD, this);
            StartForm();
            form.ShowDialog();
        }
        public RightsManagement()
        {

        }

        public void StartForm()
        {
            ConnectionBD connect = new ConnectionBD();
            connect.OpenConnect();

            OleDbCommand myCommand = connect.connection.CreateCommand();
            myCommand.CommandText = $"select * from Меню WHERE `ID родительского пункта`=0 ORDER BY `Порядок`;";
            OleDbDataReader rd = myCommand.ExecuteReader();
            while (rd.Read())
            {
                form.FillComboBox(Convert.ToString(rd["Имя пункта"]), 1);
            }
            connect.CloseConnect();
        }

        public void LoadComboBox2(string nameItem)
        {
            ConnectionBD connect = new ConnectionBD();
            connect.OpenConnect();
            // находим id родительского пункта
            OleDbCommand myCommand = connect.connection.CreateCommand();
            myCommand.CommandText = $"select ID from Меню WHERE StrComp('{nameItem}', `Имя пункта`, 0) = 0;";
            OleDbDataReader rd = myCommand.ExecuteReader();
            rd.Read();
            int idItem = Convert.ToInt32(rd["ID"]);

            // находим все подпункты данного пункта меню
            OleDbCommand loadItems = connect.connection.CreateCommand();
            loadItems.CommandText = $"select * from Меню WHERE `ID родительского пункта`={idItem} ORDER BY `Порядок`;";
            OleDbDataReader reader = loadItems.ExecuteReader();
            while (reader.Read())
            {
                form.FillComboBox(Convert.ToString(reader["Имя пункта"]), 2);
            }
            connect.CloseConnect();
        }

        public void SetDefaultRights(int userId)
        {
            // выдача стандартных прав
            ConnectionBD connect = new ConnectionBD();
            connect.OpenConnect();

            OleDbCommand myCommand = connect.connection.CreateCommand();
            myCommand.CommandText = $"select * from Меню ORDER BY `Порядок`;";
            OleDbDataReader rd = myCommand.ExecuteReader();
            while (rd.Read())
            {
                OleDbCommand setRight = connect.connection.CreateCommand();
                string item = rd["Имя пункта"] as string;
                if (item == "Сменить пароль")
                {
                    setRight.CommandText = $"insert into `Права пользователя` ([ID пользователя], [ID пункта меню], [R], [W], [E], [D]) values ('{userId}', '{rd["ID"]}', 1, 0, 1, 0);";
                }
                else if (item == "Разное" || item == "Справка" || item == "Содержание" || item == "О программе")
                {
                    setRight.CommandText = $"insert into `Права пользователя` ([ID пользователя], [ID пункта меню], [R], [W], [E], [D]) values ('{userId}', '{rd["ID"]}', 1, 0, 0, 0);";
                }
                else
                {
                    setRight.CommandText = $"insert into `Права пользователя` ([ID пользователя], [ID пункта меню], [R], [W], [E], [D]) values ('{userId}', '{rd["ID"]}', 0, 0, 0, 0);";
                }
                setRight.ExecuteNonQuery();
            }
            connect.CloseConnect();
        }

        public void SetRights(string nameItem, int R, int W, int E, int D)
        {
            // выдача прав на конкретный пункт
            if (check == 1)
            {
                ConnectionBD connect = new ConnectionBD();
                connect.OpenConnect();

                OleDbCommand myCommand = connect.connection.CreateCommand();
                myCommand.CommandText = $"select ID from Меню WHERE StrComp('{nameItem}', `Имя пункта`, 0) = 0;";
                OleDbDataReader rd = myCommand.ExecuteReader();
                rd.Read();

                OleDbCommand setRight = connect.connection.CreateCommand();
                setRight.CommandText = $"UPDATE `Права пользователя` SET [R]={R}, [W]={W}, [E]={E}, [D]={D} WHERE `ID пользователя`={UserId} AND `ID пункта меню`={rd["ID"]};";
                setRight.ExecuteNonQuery();

                connect.CloseConnect();
            }
            else
            {
                throw new Exception("Пользователь не указан");
            }
        }
        public int CheckLogin(string login)
        {
            try
            {
                ConnectionBD connect = new ConnectionBD();
                connect.OpenConnect();
                OleDbCommand user = connect.connection.CreateCommand();
                user.CommandText = $"select ID from `Пользователи` WHERE StrComp('{login}', Login, 0) = 0;";
                OleDbDataReader userReader = user.ExecuteReader();
                userReader.Read();
                UserId = Convert.ToInt32(userReader["ID"]);
                check = 1;
                connect.CloseConnect();
            }
            catch
            {
                check = 0;
                throw new Exception("Пользователь не найден");
            }
            return check;
        }
    }
}
