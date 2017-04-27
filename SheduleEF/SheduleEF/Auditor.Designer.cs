namespace SheduleEF
{
    partial class Auditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auditor));
            this.button1 = new System.Windows.Forms.Button();
            this.NameLable = new System.Windows.Forms.Label();
            this.AuditorNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AuditorBuilding = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Location = new System.Drawing.Point(9, 11);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(139, 13);
            this.NameLable.TabIndex = 4;
            this.NameLable.Text = "Введите номер аудитории";
            this.NameLable.Click += new System.EventHandler(this.NameLable_Click);
            // 
            // AuditorNumber
            // 
            this.AuditorNumber.Location = new System.Drawing.Point(194, 7);
            this.AuditorNumber.Name = "AuditorNumber";
            this.AuditorNumber.Size = new System.Drawing.Size(136, 20);
            this.AuditorNumber.TabIndex = 3;
            this.AuditorNumber.TextChanged += new System.EventHandler(this.AuditorNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите здание";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AuditorBuilding
            // 
            this.AuditorBuilding.FormattingEnabled = true;
            this.AuditorBuilding.Items.AddRange(new object[] {
            "А",
            "Б",
            "В",
            "Г",
            "Спортзал"});
            this.AuditorBuilding.Location = new System.Drawing.Point(194, 43);
            this.AuditorBuilding.Name = "AuditorBuilding";
            this.AuditorBuilding.Size = new System.Drawing.Size(136, 21);
            this.AuditorBuilding.TabIndex = 7;
            this.AuditorBuilding.SelectedIndexChanged += new System.EventHandler(this.AuditorBuilding_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(9, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "(c) ИГЭУ 2016";
            // 
            // Auditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 117);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AuditorBuilding);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.AuditorNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Auditor";
            this.Text = "Расписание ИГЭУ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.TextBox AuditorNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AuditorBuilding;
        private System.Windows.Forms.Label label2;
    }
}