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
    public partial class Admin : Form
    {
        public string pas;
        public Admin(string s)
        {
            pas = s;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == pas)
            {
                MessageBox.Show("Пароль введён верно");
            }
            else MessageBox.Show("Неверный пароль");
            this.Close();
        }
    }
}
