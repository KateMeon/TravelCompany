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
    public partial class RegistrationForm : Form
    {
        private string filePath = string.Empty;
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }
        private Image photo;
        private AuthorizationForm authorizationForm;

        public RegistrationForm(AuthorizationForm form)
        {
            InitializeComponent();
            authorizationForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (FilePath == string.Empty)
                {
                    photo = TravelCompany.Properties.Resources.default_user;
                }
                Registration registration = new Registration(nameB.Text, lastnameB.Text, otcB.Text, dateT.Value, seriaB.Text, numberB.Text, datePasport.Value, pasportB.Text, photo);
                RegistrationForm2 reg_form = new RegistrationForm2(registration, authorizationForm, this);
                reg_form.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
       

        private void LoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите фотографию...";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Получаем путь
                    FilePath = openFileDialog.FileName;
                }
            }
            if (FilePath != "")
            {
                photo = Image.FromFile(FilePath);
                pictureBox1.Image = photo;
            }
            else
            {
                MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
                authorizationForm.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
           
}
