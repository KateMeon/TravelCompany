
namespace TravelCompany
{
    partial class AdminForm
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
            this.components = new System.ComponentModel.Container();
            this.travelCompanyDataSet = new TravelCompany.TravelCompanyDataSet();
            this.travelCompanyDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.travelCompanyDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.travelCompanyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelCompanyDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelCompanyDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // travelCompanyDataSet
            // 
            this.travelCompanyDataSet.DataSetName = "TravelCompanyDataSet";
            this.travelCompanyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // travelCompanyDataSetBindingSource
            // 
            this.travelCompanyDataSetBindingSource.DataSource = this.travelCompanyDataSet;
            this.travelCompanyDataSetBindingSource.Position = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Клиенты",
            "Сотрудники",
            "Города"});
            this.comboBox1.Location = new System.Drawing.Point(13, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Выбор таблицы";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // travelCompanyDataSetBindingSource1
            // 
            this.travelCompanyDataSetBindingSource1.DataSource = this.travelCompanyDataSet;
            this.travelCompanyDataSetBindingSource1.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(195, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(927, 473);
            this.dataGridView1.TabIndex = 2;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 537);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.travelCompanyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelCompanyDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelCompanyDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource travelCompanyDataSetBindingSource;
        private TravelCompanyDataSet travelCompanyDataSet;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource travelCompanyDataSetBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}