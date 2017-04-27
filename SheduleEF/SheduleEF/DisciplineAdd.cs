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
    public partial class DisciplineAdd : Form
    {
        SheaduleContext db;
        public DisciplineAdd()
        {
            InitializeComponent();
            db =new SheaduleContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DisciplineName.Text != "")
            {
                DISCIPLINE d = db.DISCIPLINE.FirstOrDefault(p => p.DISCIPLINE_NAME == DisciplineName.Text);
                if (d == null)
                {
                    DISCIPLINE discipline = new DISCIPLINE();
                    discipline.DISCIPLINE_NAME = DisciplineName.Text;
                    db.DISCIPLINE.Add(discipline);
                    db.SaveChanges();
                    MessageBox.Show("Объект обновлен");
                }
                else MessageBox.Show("Дисциплина уже есть в базе данных");
            }
            else MessageBox.Show("Введите название дисциплины");
        }
    }
}
