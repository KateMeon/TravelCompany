using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TravelCompany
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnectionStringBuilder bldr;
            bldr = new OleDbConnectionStringBuilder();
            bldr.DataSource = "C:\\Users\\kater\\source\\repos\\TravelCompany\\TravelCompany.accdb";
            bldr.Provider = "Microsoft.ACE.OLEDB.12.0";

            string CommandText = $"select * from `{comboBox1.Text}`";
            using (OleDbConnection connection = new OleDbConnection(bldr.ConnectionString))
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }
    }
    
}
