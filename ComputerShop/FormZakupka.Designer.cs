
namespace ComputerShopView
{
    partial class FormZakupka
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
            this.labelComplect = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxComplect = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelComplect
            // 
            this.labelComplect.AutoSize = true;
            this.labelComplect.Location = new System.Drawing.Point(12, 27);
            this.labelComplect.Name = "labelComplect";
            this.labelComplect.Size = new System.Drawing.Size(103, 15);
            this.labelComplect.TabIndex = 0;
            this.labelComplect.Text = "Комплектующее:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 23);
            this.textBox1.TabIndex = 1;
            // 
            // comboBoxComplect
            // 
            this.comboBoxComplect.FormattingEnabled = true;
            this.comboBoxComplect.Location = new System.Drawing.Point(126, 24);
            this.comboBoxComplect.Name = "comboBoxComplect";
            this.comboBoxComplect.Size = new System.Drawing.Size(216, 23);
            this.comboBoxComplect.TabIndex = 2;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(12, 82);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(81, 15);
            this.labelDate.TabIndex = 3;
            this.labelDate.Text = "Дата закупки:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(313, 116);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(394, 116);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormZakupka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 151);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.comboBoxComplect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelComplect);
            this.Name = "FormZakupka";
            this.Text = "FormZakupka";
            this.Load += new System.EventHandler(this.FormZakupka_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComplect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxComplect;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}