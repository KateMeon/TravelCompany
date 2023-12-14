using System;
using System.Data.OleDb;
using TravelCompany;

namespace TravelCompany
{
    public class ConnectionBD
    {
        private string pathBD = "C:\\Users\\kater\\source\\repos\\TravelCompany\\TravelCompany.accdb";
        public string PathBD
        {
            get
            {
                return this.pathBD;
            }
            set
            {
                this.pathBD = value;
            }
        }
        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        public OleDbConnection connection;
        public ConnectionBD()
        {
            OleDbConnectionStringBuilder bldr;
            bldr = new OleDbConnectionStringBuilder();
            bldr.DataSource = this.PathBD;
            bldr.Provider = "Microsoft.ACE.OLEDB.12.0";
            connection = new OleDbConnection(bldr.ConnectionString);

        }

        public void OpenConnect()
        {
            connection.Open();
        }
        public void CloseConnect()
        {
            connection.Close();
        }
    }
}
