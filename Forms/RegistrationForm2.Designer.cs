
namespace TravelCompany
{
    partial class RegistrationForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormClosing += RegistrationForm2_FormClosing;
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordBox
            // 
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordBox.Location = new System.Drawing.Point(187, 228);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(432, 30);
            this.PasswordBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(182, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Пароль";
            // 
            // LoginBox
            // 
            this.LoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginBox.Location = new System.Drawing.Point(187, 92);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(432, 30);
            this.LoginBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(182, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Логин";
            // 
            // enterButton
            // 
            this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterButton.Location = new System.Drawing.Point(287, 368);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(164, 42);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "Регистрация";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "*Длина Логина должна быть больше 4 символов\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 68);
            this.label4.TabIndex = 13;
            this.label4.Text = "Пароль должен содержать: *не менее 8 символов; \r\n*символы нижнего регистра;\r\n*сим" +
    "волы верхнего регистра;\r\n*цифры.\r\n";
            // 
            // RegistrationForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "RegistrationForm2";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}