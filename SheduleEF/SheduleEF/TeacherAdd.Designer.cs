﻿namespace SheduleEF
{
    partial class TeacherAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherAdd));
            this.TeacherName = new System.Windows.Forms.TextBox();
            this.NameLable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TeacherName
            // 
            this.TeacherName.Location = new System.Drawing.Point(198, 12);
            this.TeacherName.Name = "TeacherName";
            this.TeacherName.Size = new System.Drawing.Size(136, 20);
            this.TeacherName.TabIndex = 0;
            this.TeacherName.TextChanged += new System.EventHandler(this.TeacherName_TextChanged);
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Location = new System.Drawing.Point(13, 16);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(157, 13);
            this.NameLable.TabIndex = 1;
            this.NameLable.Text = "Введите Фио Преподавателя";
            this.NameLable.Click += new System.EventHandler(this.NameLable_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "(c) ИГЭУ 2016";
            // 
            // TeacherAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 71);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.TeacherName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeacherAdd";
            this.Text = "Расписание ИГЭУ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TeacherName;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}