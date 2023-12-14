using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompany.Scripts;

namespace TravelCompany.Forms
{
    public partial class MainForm : Form
    {
        private ToolStripMenuItem mainItem;
        private ToolStripMenuItem secondItem;
        private Client client;
        private LoadMenu load;
        private User user;
        private bool clientAuth = false;
        private AuthorizationForm form;

        public Client Client
        {
            set
            {
                this.client = value;
            }
            get
            {
                return this.client;
            }
        }
        public User User
        {
            set
            {
                this.user = value;
            }
            get
            {
                return this.user;
            }
        }

        public bool ClientAuth
        {
            set
            {
                this.clientAuth = value;
            }
            get
            {
                return this.clientAuth;
            }
        }

        public MainForm(AuthorizationForm formA, int userID, User userN)
        {
            InitializeComponent();
            load = new LoadMenu(this, userID);
            user = userN;
            form = formA;
            if (!load.Load())
            {
                MessageBox.Show("Ошибка загрузки меню", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public MainForm(AuthorizationForm formA, int userID, Client clientA, User userN)
        {
            InitializeComponent();
            load = new LoadMenu(this, userID);
            client = clientA;
            clientAuth = true;
            user = userN;
            form = formA;
            if (!load.Load())
            {
                MessageBox.Show("Ошибка загрузки меню", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateItem(string nameItem)
        {
            mainItem = new ToolStripMenuItem(nameItem);
        }

        public void CreateSecondItem(string nameItem)
        {
            secondItem = new ToolStripMenuItem(nameItem);
        }

        public void AddElem()
        {
            mainItem.DropDownItems.Add(secondItem);
        }

        public void AddItem()
        {
            menuStrip1.Items.Add(mainItem);
        }

        public void AddClick() 
        {
            secondItem.Click += ClickEvent;
        }

        public void ClickEvent(object sender, EventArgs e)
        {
            try
            {
                load.LoadForm((sender as ToolStripMenuItem).Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Завершить работу?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
                form.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
