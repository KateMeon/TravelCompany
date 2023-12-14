using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Data.Common;

namespace TravelCompany.Scripts
{
    class WorkBD
    {
        private ConnectionBD connect;
        public WorkBD()
        {
            connect = new ConnectionBD();
        }
        public bool CheckClient(int ID)
        {
            bool check = true;
            connect.OpenConnect();
            OleDbCommand myCommand = connect.connection.CreateCommand();
            myCommand.CommandText = $"select * from Клиенты WHERE `ID пользователя`={ID};";

            if (Convert.ToInt32(myCommand.ExecuteScalar()) == 0) // если пользователь не найден
            {
                check = false;
            }
            connect.CloseConnect();
            
            return check;
        }

        public Client TakeClient(int ID)
        {
            Client client;
            connect.OpenConnect();
            OleDbCommand myCommand = connect.connection.CreateCommand();
            myCommand.CommandText = $"select `Имя`, `Фамилия`, `Отчество`, `Дата рождения` from Клиенты WHERE `ID пользователя`={ID};";

            OleDbDataReader reader = myCommand.ExecuteReader();
            
            reader.Read();
            string namev = reader["Имя"] as string;
            string surnamev = reader["Фамилия"] as string;
            string patron = reader["Отчество"] as string;
            DateTime date = (DateTime)reader["Дата рождения"];

            // найдем паспорт пользователя
            OleDbCommand selectPasport = connect.connection.CreateCommand();
            selectPasport.CommandText = $"select * from Паспорт WHERE `ID клиента`={ID};";

            OleDbDataReader readP = selectPasport.ExecuteReader();
            readP.Read();
            
            Pasport pasportv = new Pasport(readP["Серия"] as string, readP["Номер"] as string, (DateTime)readP["Дата выдачи"], readP["Кем выдан"] as string);


            // загрузим фото пользователя
            /*Image imageP;


            OleDbCommand imageCommand = connect.connection.CreateCommand();
            imageCommand.CommandText = $"SELECT Image FROM Клиенты WHERE `ID пользователя`={ID};";     
            OleDbDataReader imageReader = imageCommand.ExecuteReader();
            imageReader.Read();

            //if (imageReader.HasRows) //Проверяем есть ли в выборке строки
            //{
            try
            {
                MemoryStream memory = new MemoryStream();   //Создаем поток, в котором будем хранить изображение         
                foreach (DbDataRecord record in imageReader) //Цикл для всех записей, полученных в результате выборки
                    memory.Write((byte[])record["Image"], 0, ((byte[])record["Image"]).Length); //Пишем в поток

                imageP = Image.FromStream(memory);//Получаем изображение из потока
                memory.Dispose();  
                //client = new Client(namev, surnamev, patron, date, pasportv, imageP);
            }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                client = null;
           // }
            //else
            //{
              //  throw new Exception("Ошибка загрузки пользователя");
            //}*/
            client = new Client(namev, surnamev, patron, date, pasportv);
            connect.CloseConnect();
            return client;
        }


    
    }
}
