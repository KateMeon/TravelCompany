using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompany;

namespace RightsManagementForm
{
    public partial class Form1 : Form
    {
        private int parR;
        private int parW;
        private int parE;
        private int parD;
        private RightsManagement rights;
        private int userID;

        public Form1()
        {
            
        }
        public Form1(int pR, int pW, int pE, int pD, RightsManagement right)
        {
            InitializeComponent();
            comboBox1.Sorted = true;
            comboBox2.Sorted = true;
            SetParams(pR, pW, pE, pD);
            rights = right;
        }

        public void SetParams(int pR, int pW, int pE, int pD)
        {
            parR = pR;
            parD = pD;
            parW = pW;
            parE = pE;

            if (parE == 1)
            {
                button1.Enabled = true;
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                rights.CheckLogin(loginBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillComboBox(string item, int num)
        {
            if (num == 1)
            {
                comboBox1.Items.Add(item);
            }
            else
            {
                comboBox2.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    rights.SetRights(comboBox1.SelectedItem.ToString(), 1, 0, 0, 0);
                    button2.Enabled = true;
                    rights.LoadComboBox2(comboBox1.SelectedItem.ToString());
                }
                else
                {
                    throw new Exception("Навзание пункта меню не выбрано");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int R = read.Checked ? 1 : 0;
            int W = write.Checked ? 1 : 0;
            int E = execute.Checked ? 1 : 0;
            int D = delete.Checked ? 1 : 0;
            try
            {
                if (comboBox2.SelectedIndex > -1)
                {
                    rights.SetRights(comboBox2.SelectedItem.ToString(), R, W, E, D);
                }
                else
                {
                    throw new Exception("Навзание пункта меню не выбрано");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (MessageBox.Show("Вернуться в главное меню?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
