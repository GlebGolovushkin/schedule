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
    public partial class ScheduleAdd : Form
    {
        SheaduleContext db;
        public ScheduleAdd()
        {
            InitializeComponent();
            db = new SheaduleContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TimeNameTxtBox.Text != "")
            {
                TYPE t = db.TYPE.FirstOrDefault(p => p.TYPE_NAME == TimeNameTxtBox.Text);
                if (t == null)
                {
                    TYPE type = new TYPE();
                    type.TYPE_NAME = TimeNameTxtBox.Text;
                    type.TYPE_TIME_START = StartTimeTimePicker.Value;              
                    type.TYPE_TIME_END = EndDateTimePicker.Value;
                    db.TYPE.Add(type);
                    db.SaveChanges();
                    MessageBox.Show("Объект обновлен");
                }
                else MessageBox.Show("Расписание уже есть в базе данных");
            }
            else MessageBox.Show("Введите данные расписания");

        }
    }
}
