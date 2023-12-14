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

namespace TravelCompany
{
    public partial class RegistrationForm2 : Form
    {
        private Registration registration;
        private AuthorizationForm authorizationForm;
        private RegistrationForm registrationForm;
        private bool successReg = false;
        public RegistrationForm2(Registration reg, AuthorizationForm form, RegistrationForm regForm)
        {
            InitializeComponent();
            registration = reg;
            authorizationForm = form;
            registrationForm = regForm;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginBox.Text) && !string.IsNullOrEmpty(PasswordBox.Text))
            {
                try
                {
                    registration.Login = LoginBox.Text;
                    registration.Password = PasswordBox.Text;
                    registration.RegistrationClient();
                    successReg = true;
                    registrationForm.Close();
                    this.Close();
                    authorizationForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RegistrationForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (successReg)
            {
                e.Cancel = false;
            }
            else if (MessageBox.Show("Вернуться к прошлому окну?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
                registrationForm.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
