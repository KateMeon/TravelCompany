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
using TravelCompany.Scripts;

namespace TravelCompany
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            RegistrationForm reg_form = new RegistrationForm(this);
            this.Hide();
            reg_form.Show();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginBox.Text) && !string.IsNullOrEmpty(PasswordBox.Text))
            {
                Autorization authorization = new Autorization(this, LoginBox.Text, PasswordBox.Text);
                int resCheck = authorization.AutorizationCheck();
                if(resCheck == 1)
                {
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Логин или пароль введен неверно", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }

        public void ShowNewUser(string Login)
        {
            LoginBox.Text = Login;
            PasswordBox.Clear();
        }
    }
}
