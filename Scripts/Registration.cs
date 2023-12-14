using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace TravelCompany.Scripts
{
    public class Registration
    {
        private User user = new User();
        private Client client;
        private Pasport pasport;

        public string Login
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ConnectionBD connect = new ConnectionBD();
                    connect.OpenConnect();
                    OleDbCommand myCommand = connect.connection.CreateCommand();
                    myCommand.CommandText = $"select Login from Пользователи WHERE StrComp('{value}', Login, 0) = 0;";


                    if (Convert.ToInt32(myCommand.ExecuteScalar()) == 0)
                    {
                       user.Login = value;
                    }
                    else
                    {
                        throw new Exception("Логин занят");
                    }
                    connect.CloseConnect();

                }
                else
                {
                    throw new Exception("Логин не может быть пустым");
                }
            }
        }
        public string Password
        {
            set
            { 
                user.Password = value;
            }
        }

        public Registration(string namev, string surnamev, string patron, DateTime date, string seriav, string num, DateTime datev, string issuedv, Image photo)
        {
            pasport = new Pasport(seriav, num, datev, issuedv);
            client = new Client(namev, surnamev, patron, date, pasport, photo);
        }

        public void RegistrationClient()
        {
            // создаем соединение с БД
            ConnectionBD connect = new ConnectionBD();
            connect.OpenConnect();
            OleDbCommand CommandClient = connect.connection.CreateCommand();
            OleDbCommand CommandPasport = connect.connection.CreateCommand();
            OleDbCommand CommandUser = connect.connection.CreateCommand();
            OleDbCommand CommandSelect = connect.connection.CreateCommand();
            OleDbCommand CommandRights = connect.connection.CreateCommand();


            // добавляем логин и пароль в базу данных "Пользователи" 
            CommandUser.CommandText = $"insert into Пользователи ([Login], [Password]) values ('{user.Login}', '{user.Password}')";
            CommandUser.ExecuteNonQuery();

            // получение ID добавленного пользователя
            CommandSelect.CommandText = $"SELECT @@Identity";
            int id = Convert.ToInt32(CommandSelect.ExecuteScalar());

            // добавляем клиента в базу данных "Клиенты"
            CommandClient.CommandText = $"insert into Клиенты ([Фамилия], [Имя], [Отчество], [Дата рождения], [ID пользователя], [Image]) values ('{client.Surname}', '{client.Name}', '{client.Patronymic}', #{client.DateOfBirth.Day}/{client.DateOfBirth.Month}/{client.DateOfBirth.Year}#, {id}, '@photo')";
            MemoryStream ms = new MemoryStream();
            client.Image.Save(ms, ImageFormat.Jpeg);
            byte[] photo_aray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo_aray, 0, photo_aray.Length);
            CommandClient.Parameters.AddWithValue("@photo", photo_aray);
            CommandClient.ExecuteNonQuery();

            

            // добавляем паспортные данные в базу данных "Паспорт"
            CommandPasport.CommandText = $"insert into Паспорт ([Серия], [Номер], [Дата выдачи], [Кем выдан], [ID клиента]) values ('{pasport.Seria}', '{pasport.Number}', #{pasport.DateOfIssue.Day}/{pasport.DateOfIssue.Month}/{pasport.DateOfIssue.Year}#, '{pasport.Issued}', {id})";
            CommandPasport.ExecuteNonQuery();

            // выдаем пользователю стандартные права
            RightsManagementForm.RightsManagement rights = new RightsManagementForm.RightsManagement();
            rights.SetDefaultRights(id);

            connect.CloseConnect();

        }
    }
}
