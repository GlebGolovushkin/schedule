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
    public partial class GroupAdd : Form
    {
        SheaduleEntities db;
        public GroupAdd()
        {
            InitializeComponent();
            db = new SheaduleEntities();
            FacultyName.DropDownStyle = ComboBoxStyle.DropDownList;
            FacultyName.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GroupNumber.Text != "")
            {
                GROUPS g = db.GROUPS.FirstOrDefault(p => (p.GROUP_NUMBER.ToString() == GroupNumber.Text));
                if (g == null)
                {
                    GROUPS gr = new GROUPS();
                    FACULTY fac = db.FACULTY.FirstOrDefault(p => (p.FACULTY_NAME.ToString() == FacultyName.SelectedItem.ToString()));
                    if (fac == null)
                    {
                        FACULTY f = new FACULTY();
                        f.FACULTY_NAME = FacultyName.SelectedItem.ToString();
                        fac = f;
                        db.FACULTY.Add(f);
                    }
                    gr.GROUP_NUMBER = GroupNumber.Text;
                    
                    gr.FACULTY_CODE = fac.FACULTY_CODE;
                    
                    db.GROUPS.Add(gr);
                    db.SaveChanges();
                    MessageBox.Show("Объект обновлен");
                }
                else MessageBox.Show("Группа уже есть в базе данных");
            }
            else MessageBox.Show("Введите группу");
        }
    }
}
