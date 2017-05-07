using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheduleEF
{
    public partial class TeacherAdd : Form
    {
        SheaduleEntities db;
        public TeacherAdd()
        {
            InitializeComponent();
            db = new SheaduleEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TeacherName.Text!="")
            {
                TEACHER t = db.TEACHER.FirstOrDefault(p => p.TEACHER_NAME == TeacherName.Text);
                if (t == null)
                {
                    TEACHER teacher = new TEACHER();
                    teacher.TEACHER_NAME = TeacherName.Text;
                    db.TEACHER.Add(teacher);
                    db.SaveChanges();
                    MessageBox.Show("Объект обновлен");
                }
                else MessageBox.Show("Преподаватель уже есть в базе данных");
            }
            else MessageBox.Show("Введите имя преподавателя");
        }

        private void TeacherName_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameLable_Click(object sender, EventArgs e)
        {

        }
    }
}
