
namespace ComputerShopView
{
    partial class FormGlav
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
            this.buttonComplects = new System.Windows.Forms.Button();
            this.buttonSborkas = new System.Windows.Forms.Button();
            this.buttonZakupkas = new System.Windows.Forms.Button();
            this.buttonGetSpisok = new System.Windows.Forms.Button();
            this.buttonOtchet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonComplects
            // 
            this.buttonComplects.Location = new System.Drawing.Point(12, 12);
            this.buttonComplects.Name = "buttonComplects";
            this.buttonComplects.Size = new System.Drawing.Size(124, 23);
            this.buttonComplects.TabIndex = 0;
            this.buttonComplects.Text = "Коплектующие";
            this.buttonComplects.UseVisualStyleBackColor = true;
            this.buttonComplects.Click += new System.EventHandler(this.buttonComplects_Click);
            // 
            // buttonSborkas
            // 
            this.buttonSborkas.Location = new System.Drawing.Point(142, 12);
            this.buttonSborkas.Name = "buttonSborkas";
            this.buttonSborkas.Size = new System.Drawing.Size(124, 23);
            this.buttonSborkas.TabIndex = 1;
            this.buttonSborkas.Text = "Сборки";
            this.buttonSborkas.UseVisualStyleBackColor = true;
            this.buttonSborkas.Click += new System.EventHandler(this.buttonSborkas_Click);
            // 
            // buttonZakupkas
            // 
            this.buttonZakupkas.Location = new System.Drawing.Point(272, 12);
            this.buttonZakupkas.Name = "buttonZakupkas";
            this.buttonZakupkas.Size = new System.Drawing.Size(124, 23);
            this.buttonZakupkas.TabIndex = 2;
            this.buttonZakupkas.Text = "Закупки";
            this.buttonZakupkas.UseVisualStyleBackColor = true;
            this.buttonZakupkas.Click += new System.EventHandler(this.buttonZakupkas_Click);
            // 
            // buttonGetSpisok
            // 
            this.buttonGetSpisok.Location = new System.Drawing.Point(402, 12);
            this.buttonGetSpisok.Name = "buttonGetSpisok";
            this.buttonGetSpisok.Size = new System.Drawing.Size(124, 23);
            this.buttonGetSpisok.TabIndex = 3;
            this.buttonGetSpisok.Text = "Получение спикска";
            this.buttonGetSpisok.UseVisualStyleBackColor = true;
            this.buttonGetSpisok.Click += new System.EventHandler(this.buttonGetSpisok_Click);
            // 
            // buttonOtchet
            // 
            this.buttonOtchet.Location = new System.Drawing.Point(532, 12);
            this.buttonOtchet.Name = "buttonOtchet";
            this.buttonOtchet.Size = new System.Drawing.Size(124, 23);
            this.buttonOtchet.TabIndex = 4;
            this.buttonOtchet.Text = "Отчет";
            this.buttonOtchet.UseVisualStyleBackColor = true;
            this.buttonOtchet.Click += new System.EventHandler(this.buttonOtchet_Click);
            // 
            // FormGlav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 303);
            this.Controls.Add(this.buttonOtchet);
            this.Controls.Add(this.buttonGetSpisok);
            this.Controls.Add(this.buttonZakupkas);
            this.Controls.Add(this.buttonSborkas);
            this.Controls.Add(this.buttonComplects);
            this.Name = "FormGlav";
            this.Text = "Главаная форма";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonComplects;
        private System.Windows.Forms.Button buttonSborkas;
        private System.Windows.Forms.Button buttonZakupkas;
        private System.Windows.Forms.Button buttonGetSpisok;
        private System.Windows.Forms.Button buttonOtchet;
    }
}