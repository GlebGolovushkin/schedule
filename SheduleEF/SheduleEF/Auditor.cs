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
    public partial class Auditor : Form
    {
        SheaduleContext db;
        public Auditor()
        {
            InitializeComponent();
            db = new SheaduleContext();
            AuditorBuilding.DropDownStyle = ComboBoxStyle.DropDownList;
            AuditorBuilding.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AuditorNumber.Text != "")
            {
                AUDITORIUM a = db.AUDITORIUM.FirstOrDefault(p => (p.AUDITORIUM_NUMBER == AuditorNumber.Text)&& (p.BUILDING == AuditorBuilding.SelectedItem.ToString()));
                if (a == null)
                {
                    AUDITORIUM auditor = new AUDITORIUM();
                    auditor.AUDITORIUM_NUMBER = AuditorNumber.Text;
                    auditor.BUILDING = AuditorBuilding.SelectedItem.ToString();
                    db.AUDITORIUM.Add(auditor);
                    db.SaveChanges();
                    MessageBox.Show("Объект обновлен");
                }
                else MessageBox.Show("Аудитория уже есть в базе данных");
            }
            else MessageBox.Show("Введите аудиторию");
        }

        private void NameLable_Click(object sender, EventArgs e)
        {

        }

        private void AuditorNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void AuditorBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
