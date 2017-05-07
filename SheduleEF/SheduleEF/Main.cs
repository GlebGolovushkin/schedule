using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using SheduleEF.Models;

namespace SheduleEF
{
    public partial class Main : Form
    {
        string s, password = "password123";
        DateTime dateOnly = DateTime.Today;

        private SheaduleContext db;
        public Main()
        {
            
            InitializeComponent();
            
            contextMenuStrip1.Visible = menuStrip2.Visible = false;
            menuStrip1.Visible = true;
            dataGridView2.ColumnCount = 8;
            dataGridView2.RowCount = 16;
            comboBoxStudent2.Text = "3";
            comboBoxStudent1.Text = "41";
            comboBox1.Text = "А";
            comboBox1_SelectedIndexChanged_1(null, null);
            comboBox1.DropDownStyle = comboBox2.DropDownStyle = comboBoxStudent3.DropDownStyle=comboBoxStudent1.DropDownStyle = comboBoxStudent2.DropDownStyle = comboBoxTeacher3.DropDownStyle = ComboBoxStyle.DropDownList;
            radioButton1.Checked = true;
            Teacher2.Visible =
                comboBoxTeacher3.Visible = Aud2.Visible = comboBox1.Visible= comboBox2.Visible= false;
            radioButton4.Checked = true;
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                dataGridView2.Columns[i].Width = 135;
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Rows[8].Height = 0;
        }


        private void AddNewItem_Click(object sender, EventArgs e)
        {
            TascAdd add = new TascAdd();
            add.ShowDialog();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet37.TimeTableView". При необходимости она может быть перемещена или удалена.
            this.timeTableViewTableAdapter6.Fill(this.sheaduleDataSet37.TimeTableView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet36.TimeTableView". При необходимости она может быть перемещена или удалена.
            this.timeTableViewTableAdapter5.Fill(this.sheaduleDataSet36.TimeTableView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet35.TimeTableView". При необходимости она может быть перемещена или удалена.
            this.timeTableViewTableAdapter4.Fill(this.sheaduleDataSet35.TimeTableView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet32.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter.Fill(this.sheaduleDataSet32.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet31.FACULTY". При необходимости она может быть перемещена или удалена.
            this.fACULTYTableAdapter.Fill(this.sheaduleDataSet31.FACULTY);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet30.GROUPS". При необходимости она может быть перемещена или удалена.
            this.gROUPSTableAdapter1.Fill(this.sheaduleDataSet30.GROUPS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet26.TimeTableView". При необходимости она может быть перемещена или удалена.
            this.timeTableViewTableAdapter3.Fill(this.sheaduleDataSet26.TimeTableView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet25.TimeTableView". При необходимости она может быть перемещена или удалена.
            this.timeTableViewTableAdapter2.Fill(this.sheaduleDataSet25.TimeTableView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet24.TimeTableView". При необходимости она может быть перемещена или удалена.
            this.timeTableViewTableAdapter1.Fill(this.sheaduleDataSet24.TimeTableView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet23.TeacherView". При необходимости она может быть перемещена или удалена.
            this.teacherViewTableAdapter.Fill(this.sheaduleDataSet23.TeacherView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet10.GROUPS". При необходимости она может быть перемещена или удалена.
            this.gROUPSTableAdapter.Fill(this.sheaduleDataSet10.GROUPS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet9.TimeTableView". При необходимости она может быть перемещена или удалена.
            this.timeTableViewTableAdapter.Fill(this.sheaduleDataSet9.TimeTableView);
            if (radioButton1.Checked)button1_Click(null, null);
            if (radioButton2.Checked) button1_Click_1(null,null);
            if (radioButton3.Checked) aud(null, null);
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                dataGridView2.Columns[i].Width = 135;
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Rows[8].Height = 0;
        }


        #region FillingGroupShedule
        private void button1_Click(object sender, EventArgs e)
        {
            
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                for (int j = 1; j < dataGridView2.RowCount; j++)
                {
                    if (j==8)
                        continue;;
                    dataGridView2.Rows[j].Cells[i].Value = "";
                    dataGridView2.Rows[j].Cells[i].Style.BackColor=Color.White;
                }
            }
            string group, course;
            if (comboBoxStudent1.Text == "")
            {
                group = "41";
                if (comboBoxStudent1.Items.Count > 0)
                {
                    comboBoxStudent1.SelectedIndex=0;
                }
            }
            else group = comboBoxStudent1.Text;
            if (comboBox2.Text == "")
            {
                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.SelectedIndex = 0;
                }
                else
                {
                    comboBox2.Text = "б017";
                }
            }
            course = comboBoxStudent2.SelectedItem.ToString();
            dataGridView2.AutoSize = true;
            dataGridView2.Rows[0].Cells[1].Value = "Понедельник";
            dataGridView2.Rows[0].Cells[2].Value = "Вторник";
            dataGridView2.Rows[0].Cells[3].Value = "Среда";
            dataGridView2.Rows[0].Cells[4].Value = "Четверг";
            dataGridView2.Rows[0].Cells[5].Value = "Пятница";
            dataGridView2.Rows[0].Cells[6].Value = "Суббота";
            dataGridView2.Rows[0].Cells[7].Value = "Воскресенье";
            dataGridView2.Rows[1].Cells[0].Value = "8.00-9.35";
            dataGridView2.Rows[2].Cells[0].Value = "9.50-11.25";
            dataGridView2.Rows[3].Cells[0].Value = "11.40-13.15";
            dataGridView2.Rows[4].Cells[0].Value = "14.00-15.35";
            dataGridView2.Rows[5].Cells[0].Value = "15.50-17.25";
            dataGridView2.Rows[6].Cells[0].Value = "17.40-19.15";
            dataGridView2.Rows[7].Cells[0].Value = "19.25-21.00";
            dataGridView2.Rows[1+8].Cells[0].Value = "8.00-9.35";
            dataGridView2.Rows[2+8].Cells[0].Value = "9.50-11.25";
            dataGridView2.Rows[3+8].Cells[0].Value = "11.40-13.15";
            dataGridView2.Rows[4+8].Cells[0].Value = "14.00-15.35";
            dataGridView2.Rows[5+8].Cells[0].Value = "15.50-17.25";
            dataGridView2.Rows[6+8].Cells[0].Value = "17.40-19.15";
            dataGridView2.Rows[7+8].Cells[0].Value = "19.25-21.00";
            dataGridView2.Rows[0].Cells[0].Value = course + "–" + group;
            dataGridView2.Rows[0].DefaultCellStyle.BackColor =    Color.PaleTurquoise;
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView2.Rows[8].DefaultCellStyle.BackColor =    Color.Lavender;
            dataGridView2.Rows[8].Height = 0;
            dataGridView2.Rows[0].Cells[0].Style.BackColor = Color.Aqua;
            dataGridView2.RowHeadersWidth = 100;
            dataGridView2.Rows[8].Height = 0;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = false;
            dataGridView2.EnableHeadersVisualStyles = false;
            for (int i=0;i<dataGridView2.ColumnCount;i++)
            dataGridView2.Columns[i].Width = 135;
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Rows[8].Height = 0;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.Rows[8].Height = 0;
            int crosses = radioButton5.Checked? 2 : 1;
            int day = 0;
            int time = 0;
            int week = 0;
            Color activityColor = new Color();
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == group && dataGridView1.Rows[i].Cells[1].Value.ToString() == course && Convert.ToInt32(dataGridView3.Rows[i].Cells[12].Value.ToString()) == crosses && Convert.ToDateTime(dataGridView1.Rows[i].Cells[13].Value.ToString()).Date < dateOnly && Convert.ToDateTime(dataGridView1.Rows[i].Cells[14].Value.ToString()).Date > dateOnly)
                {
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "2")
                        week = 8;
                    else week = 0;
                    day = GetColumn(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    time = GetRow(dataGridView1.Rows[i].Cells[10].Value.ToString()) + week;
                    if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "Физкультура")
                    {
                        dataGridView2.Rows[time].Cells[day].Value = dataGridView1.Rows[i].Cells[8].Value;
                    }
                    else
                    {
                        dataGridView2.Rows[time].Cells[day].Value = (string) dataGridView1.Rows[i].Cells[8].Value + " " +
                                                                    dataGridView1.Rows[i].Cells[7].Value + " " +
                                                                    dataGridView1.Rows[i].Cells[3].Value +
                                                                    dataGridView1.Rows[i].Cells[4].Value;
                    }
                    activityColor = GetColor(dataGridView1.Rows[i].Cells[9].Value.ToString());
                    dataGridView2.Rows[time].Cells[day].Style.BackColor = activityColor;
                }

            }
            dataGridView2.Rows[8].Height = 0;
        }
        #endregion
        #region CellSettings
        private int GetRow(string time)
        {
            switch (time)
            {
                case ("8:00"):
                    return 1;
                    break;
                case ("9:50"):
                    return 2;
                    break;
                case ("11:40"):
                    return 3;
                    break;
                case ("14:00"):
                    return 4;
                    break;
                case ("15:50"):
                    return 5;
                    break;
                case ("17:40"):
                    return 6;
                    break;
                case ("19:25"):
                    return 7;
                    break;

            }
            return 0;
        }
        private int GetColumn(string day)
        {
            switch (day)
            {
                case ("Понедельник"):
                    return 1;
                    break;
                case ("Вторник"):
                    return 2;
                    break;
                case ("Среда"):
                    return 3;
                    break;
                case ("Четверг"):
                    return 4;
                    break;
                case ("Пятница"):
                    return 5;
                    break;
                case ("Суббота"):
                    return 6;
                    break;
                case ("Воскресенье"):
                    return 7;
                    break;
            }
            return 0;
        }
        private Color GetColor(string day)
        {
            switch (day)
            {
                case ("Лабараторная"):
                    return Color.LightPink;
                    break;
                case ("Семинар"):
                    return Color.PaleGreen;
                    break;
                case ("Лекция"):
                    return Color.BlanchedAlmond;
                    break;
                case ("Физическое воспитание"):
                    return Color.Thistle;
            }
            return Color.White;
        }
        #endregion
        #region Print
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView2.Size.Width, dataGridView2.Size.Height + 30);
            dataGridView2.DrawToBitmap(bmp, dataGridView2.Bounds);
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void Print_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void Save_Click(object sender, EventArgs e)
        {
        }
        #endregion
        #region StripMenu
        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Save_Click(null, null);
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddNewItem_Click(null, null);
        }

        private void распечататьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Print_Click(null, null);
        }
        #endregion
        #region Teacher
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                for (int j = 1; j < dataGridView2.RowCount; j++)
                {
                    if (j == 8)
                        continue; ;
                    dataGridView2.Rows[j].Cells[i].Value = "";
                    dataGridView2.Rows[j].Cells[i].Style.BackColor = Color.White;
                }
            }
            dataGridView2.AutoSize = true;
            dataGridView2.Rows[8].Height = 0;
            string teacher = comboBoxTeacher3.SelectedValue.ToString();
            dataGridView2.Rows[0].Cells[1].Value = "Понедельник";
            dataGridView2.Rows[0].Cells[2].Value = "Вторник";
            dataGridView2.Rows[0].Cells[3].Value = "Среда";
            dataGridView2.Rows[0].Cells[4].Value = "Четверг";
            dataGridView2.Rows[0].Cells[5].Value = "Пятница";
            dataGridView2.Rows[0].Cells[6].Value = "Суббота";
            dataGridView2.Rows[0].Cells[7].Value = "Воскресенье";
            dataGridView2.Rows[1].Cells[0].Value = "8.00-9.35";
            dataGridView2.Rows[2].Cells[0].Value = "9.50-11.25";
            dataGridView2.Rows[3].Cells[0].Value = "11.40-13.15";
            dataGridView2.Rows[4].Cells[0].Value = "14.00-15.35";
            dataGridView2.Rows[5].Cells[0].Value = "15.50-17.25";
            dataGridView2.Rows[6].Cells[0].Value = "17.40-19.15";
            dataGridView2.Rows[7].Cells[0].Value = "19.25-21.00";
            dataGridView2.Rows[1 + 8].Cells[0].Value = "8.00-9.35";
            dataGridView2.Rows[2 + 8].Cells[0].Value = "9.50-11.25";
            dataGridView2.Rows[3 + 8].Cells[0].Value = "11.40-13.15";
            dataGridView2.Rows[4 + 8].Cells[0].Value = "14.00-15.35";
            dataGridView2.Rows[5 + 8].Cells[0].Value = "15.50-17.25";
            dataGridView2.Rows[6 + 8].Cells[0].Value = "17.40-19.15";
            dataGridView2.Rows[7 + 8].Cells[0].Value = "19.25-21.00";
            dataGridView2.Rows[0].Cells[0].Value = teacher;
            dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView2.Rows[8].DefaultCellStyle.BackColor = Color.Lavender;
            dataGridView2.RowHeadersWidth = 100;
            dataGridView2.Rows[8].Height = 0;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = false;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.Rows[8].Height = 0;
            int crosses = 1;
            for (int i=0;i<dataGridView2.ColumnCount;i++)
            dataGridView2.Columns[i].Width = 135;
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Rows[8].Height = 0;
            int day = 0;
            int time = 0;
            int week = 0;
            Color activityColor = new Color();
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[7].Value.ToString() == teacher )
                {
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "2")
                        week = 8;
                    else week = 0;
                    day = GetColumn(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    time = GetRow(dataGridView1.Rows[i].Cells[10].Value.ToString()) + week;
                    if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "Физкультура")
                    {
                        dataGridView2.Rows[time].Cells[day].Value = dataGridView1.Rows[i].Cells[8].Value;
                    }
                    else
                    {
                        dataGridView2.Rows[time].Cells[day].Value = (string)dataGridView1.Rows[i].Cells[8].Value + " " +
                                                                    dataGridView1.Rows[i].Cells[7].Value + " " +
                                                                    dataGridView1.Rows[i].Cells[3].Value +
                                                                    dataGridView1.Rows[i].Cells[4].Value;
                    }
                    activityColor = GetColor(dataGridView1.Rows[i].Cells[9].Value.ToString());
                    dataGridView2.Rows[time].Cells[day].Style.BackColor = activityColor;
                }

            }
            dataGridView2.Rows[8].Height = 0;
        }
        #endregion

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                bool deleted = false;
                bool trusful = true;
                for (int i = 0; i < dataGridView2.SelectedCells.Count; i++)
                {
                    if (dataGridView2.SelectedCells[i].RowIndex == 0 || dataGridView2.SelectedCells[i].ColumnIndex == 0 ||
                        dataGridView2.SelectedCells[i].RowIndex == 8)
                    {
                        MessageBox.Show("Выберите ячейку или ячейки из расписания");
                        trusful = false;
                        break;
                    }
                }
                if (!trusful)
                {
                    return;
                }
                int column;
                int row;
                string time, weekdayname;
                int weeknumber;
                int course;
                int crosses;
                db = new SheaduleContext();
                for (int i = 0; i < dataGridView2.SelectedCells.Count; i++)
                {
                    course = Convert.ToInt32(comboBoxStudent2.SelectedItem.ToString());
                    column = dataGridView2.SelectedCells[i].ColumnIndex;
                    row = dataGridView2.SelectedCells[i].RowIndex;
                    time = dataGridView2.Rows[row].Cells[0].Value.ToString();
                    weekdayname = dataGridView2.Rows[0].Cells[column].Value.ToString();
                    weeknumber = row > 7 ? 2 : 1;
                    crosses = radioButton4.Checked ? 1 : 2;
                    for (int j = time.Length - 1; j > 0; j--)
                    {
                        if (time[j] == '-')
                        {
                            time = time.Substring(0, time.LastIndexOf('-'));
                            break;
                        }

                    }
                    time = time.Replace('.', ':');
                    while (true)
                    {
                        TIMETABLE tt = new TIMETABLE();
                        WEEKDAY wd = db.WEEKDAY.FirstOrDefault(p => p.WEEKDAY_NAME == (weekdayname));
                        GROUPS gr =
                            db.GROUPS.FirstOrDefault(p => p.GROUP_NUMBER == comboBoxStudent1.SelectedItem.ToString());
                        TIME ti = db.TIME.FirstOrDefault(p => p.TIME_START == time);
                        TIMETABLE timetable =
                            db.TIMETABLE.FirstOrDefault(
                                p =>
                                    p.COURSE_CODE == course && p.GROUP_CODE == gr.GROUP_CODE &&
                                    p.TIME_CODE == ti.TIME_CODE &&
                                    p.WEEKDAY_CODE == wd.WEEKDAY_CODE && p.WEEK_NUMBER == weeknumber &&
                                    p.CROSSES == crosses);

                        if (timetable != null)
                        {
                            db.TIMETABLE.Remove(timetable);
                            db.SaveChanges();
                            deleted = true;
                        }
                        else break;
                    }
                }
                if (deleted)
                {
                    MessageBox.Show("Успешно удалено");
                    Main_Load(null, null);
                }
            }
            else if (radioButton3.Checked)
            {
                bool deleted = false;
                bool trusful = true;
                for (int i = 0; i < dataGridView2.SelectedCells.Count; i++)
                {
                    if (dataGridView2.SelectedCells[i].RowIndex == 0 || dataGridView2.SelectedCells[i].ColumnIndex == 0 ||
                        dataGridView2.SelectedCells[i].RowIndex == 8)
                    {
                        MessageBox.Show("Выберите ячейку или ячейки из расписания");
                        trusful = false;
                        break;
                    }
                }
                if (!trusful)
                {
                    return;
                }
                int column;
                int row;
                string time, weekdayname;
                int weeknumber;
                string build;
                string aud;
                db = new SheaduleContext();
                for (int i = 0; i < dataGridView2.SelectedCells.Count; i++)
                {
                    build = comboBox1.SelectedItem.ToString();
                    aud= comboBox2.SelectedItem.ToString();
                    column = dataGridView2.SelectedCells[i].ColumnIndex;
                    row = dataGridView2.SelectedCells[i].RowIndex;
                    time = dataGridView2.Rows[row].Cells[0].Value.ToString();
                    weekdayname = dataGridView2.Rows[0].Cells[column].Value.ToString();
                    weeknumber = row > 7 ? 2 : 1;
                    for (int j = time.Length - 1; j > 0; j--)
                    {
                        if (time[j] == '-')
                        {
                            time = time.Substring(0, time.LastIndexOf('-'));
                            break;
                        }

                    }
                    time = time.Replace('.', ':');
                    while (true)
                    {
                        TIMETABLE tt = new TIMETABLE();
                        AUDITORIUM Aud = db.AUDITORIUM.FirstOrDefault(p=>p.BUILDING==build && p.AUDITORIUM_NUMBER == aud);
                        WEEKDAY wd = db.WEEKDAY.FirstOrDefault(p => p.WEEKDAY_NAME == (weekdayname));
                        GROUPS gr =
                            db.GROUPS.FirstOrDefault(p => p.GROUP_NUMBER == comboBoxStudent1.SelectedItem.ToString());
                        TIME ti = db.TIME.FirstOrDefault(p => p.TIME_START == time);
                        TIMETABLE timetable =
                            db.TIMETABLE.FirstOrDefault(
                                p =>
                                    p.AUDITORIUM_CODE == Aud.AUDITORIUM_CODE && p.GROUP_CODE == gr.GROUP_CODE &&
                                    p.TIME_CODE == ti.TIME_CODE &&
                                    p.WEEKDAY_CODE == wd.WEEKDAY_CODE && p.WEEK_NUMBER == weeknumber);

                        if (timetable != null)
                        {
                            db.TIMETABLE.Remove(timetable);
                            db.SaveChanges();
                            deleted = true;
                        }
                        else break;
                    }
                }
                if (deleted)
                {
                    MessageBox.Show("Успешно удалено");
                    Main_Load(null, null);
                    button1_Click_1(null,null);
                }
            }
            else
            {
                bool deleted = false;
                bool trusful = true;
                for (int i = 0; i < dataGridView2.SelectedCells.Count; i++)
                {
                    if (dataGridView2.SelectedCells[i].RowIndex == 0 || dataGridView2.SelectedCells[i].ColumnIndex == 0 ||
                        dataGridView2.SelectedCells[i].RowIndex == 8)
                    {
                        MessageBox.Show("Выберите ячейку или ячейки из расписания");
                        trusful = false;
                        break;
                    }
                }
                if (!trusful)
                {
                    return;
                }
                int column;
                int row;
                string time, weekdayname;
                int weeknumber;
                string teacher;
                db = new SheaduleContext();
                for (int i = 0; i < dataGridView2.SelectedCells.Count; i++)
                {
                    teacher = comboBoxTeacher3.SelectedValue.ToString();
                    column = dataGridView2.SelectedCells[i].ColumnIndex;
                    row = dataGridView2.SelectedCells[i].RowIndex;
                    time = dataGridView2.Rows[row].Cells[0].Value.ToString();
                    weekdayname = dataGridView2.Rows[0].Cells[column].Value.ToString();
                    weeknumber = row > 7 ? 2 : 1;
                    for (int j = time.Length - 1; j > 0; j--)
                    {
                        if (time[j] == '-')
                        {
                            time = time.Substring(0, time.LastIndexOf('-'));
                            break;
                        }

                    }
                    time = time.Replace('.', ':');
                    while (true)
                    {
                        TIMETABLE tt = new TIMETABLE();
                        TEACHER tch = db.TEACHER.FirstOrDefault(p => p.TEACHER_NAME == teacher);
                        WEEKDAY wd = db.WEEKDAY.FirstOrDefault(p => p.WEEKDAY_NAME == (weekdayname));
                        GROUPS gr =
                            db.GROUPS.FirstOrDefault(p => p.GROUP_NUMBER == comboBoxStudent1.SelectedItem.ToString());
                        TIME ti = db.TIME.FirstOrDefault(p => p.TIME_START == time);
                        TIMETABLE timetable =
                            db.TIMETABLE.FirstOrDefault(
                                p =>
                                    p.TEACHER_CODE == tch.TEACHER_CODE && p.GROUP_CODE == gr.GROUP_CODE &&
                                    p.TIME_CODE == ti.TIME_CODE &&
                                    p.WEEKDAY_CODE == wd.WEEKDAY_CODE && p.WEEK_NUMBER == weeknumber);

                        if (timetable != null)
                        {
                            db.TIMETABLE.Remove(timetable);
                            db.SaveChanges();
                            deleted = true;
                        }
                        else break;
                    }
                }
                if (deleted)
                {
                    MessageBox.Show("Успешно удалено");
                    Main_Load(null, null);
                    aud(null, null);
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (dataGridView2.SelectedCells.Count != 1)
                {
                    MessageBox.Show("Выберите ячейку для редактирования");
                }
                else if (dataGridView2.SelectedCells[0].RowIndex == 0 || dataGridView2.SelectedCells[0].ColumnIndex == 0)
                {
                    MessageBox.Show("Выберите ячейку из расписания");
                }
                int course = Convert.ToInt32(comboBoxStudent2.SelectedItem.ToString());
                int group = Convert.ToInt32(comboBoxStudent1.SelectedItem.ToString());
                int column = dataGridView2.SelectedCells[0].ColumnIndex;
                int row = dataGridView2.SelectedCells[0].RowIndex;
                string time = dataGridView2.Rows[row].Cells[0].Value.ToString();
                int crosses = radioButton4.Checked ? 1 : 2;
                for (int j = time.Length - 1; j > 0; j--)
                {
                    if (time[j] == '-')
                    {
                        time = time.Substring(0, time.LastIndexOf('-'));
                        break;
                    }

                }
                time = time.Replace('.', ':');
                int weeknumber = row > 7 ? 2 : 1;
                string weekdayName = dataGridView2.Rows[0].Cells[column].Value.ToString();
                TascAddStudent ta = new TascAddStudent(weekdayName, time, group, course, weeknumber, crosses);
                ta.ShowDialog();
            }
            else if (radioButton2.Checked)
            {
                if (dataGridView2.SelectedCells.Count != 1)
                {
                    MessageBox.Show("Выберите ячейку для редактирования");
                }
                else if (dataGridView2.SelectedCells[0].RowIndex == 0 || dataGridView2.SelectedCells[0].ColumnIndex == 0)
                {
                    MessageBox.Show("Выберите ячейку из расписания");
                }
                string teacher = comboBoxTeacher3.SelectedValue.ToString();
                int column = dataGridView2.SelectedCells[0].ColumnIndex;
                int row = dataGridView2.SelectedCells[0].RowIndex;
                string time = dataGridView2.Rows[row].Cells[0].Value.ToString();
                for (int j = time.Length - 1; j > 0; j--)
                {
                    if (time[j] == '-')
                    {
                        time = time.Substring(0, time.LastIndexOf('-'));
                        break;
                    }

                }
                time = time.Replace('.', ':');
                int weeknumber = row > 7 ? 2 : 1;
                string weekdayName = dataGridView2.Rows[0].Cells[column].Value.ToString();
                TascAddTeacher ta = new TascAddTeacher(teacher,time, weekdayName, weeknumber);
                ta.ShowDialog();
            }
            else
            {
                if (dataGridView2.SelectedCells.Count != 1)
                {
                    MessageBox.Show("Выберите ячейку для редактирования");
                }
                else if (dataGridView2.SelectedCells[0].RowIndex == 0 || dataGridView2.SelectedCells[0].ColumnIndex == 0)
                {
                    MessageBox.Show("Выберите ячейку из расписания");
                }
                string build = comboBox1.SelectedItem.ToString();
                string aud = comboBox2.SelectedItem.ToString();
                int column = dataGridView2.SelectedCells[0].ColumnIndex;
                int row = dataGridView2.SelectedCells[0].RowIndex;
                string time = dataGridView2.Rows[row].Cells[0].Value.ToString();
                for (int j = time.Length - 1; j > 0; j--)
                {
                    if (time[j] == '-')
                    {
                        time = time.Substring(0, time.LastIndexOf('-'));
                        break;
                    }

                }
                time = time.Replace('.', ':');
                int weeknumber = row > 7 ? 2 : 1;
                string weekdayName = dataGridView2.Rows[0].Cells[column].Value.ToString();
                TascAddAud ta = new TascAddAud(build,aud,weekdayName,weeknumber,time);
                ta.ShowDialog();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count != 1)
            {
                MessageBox.Show("Выберите ячейку для редактирования");
            }
            else if (dataGridView2.SelectedCells[0].RowIndex == 0 || dataGridView2.SelectedCells[0].ColumnIndex == 0)
            {
                MessageBox.Show("Выберите ячейку из расписания");
            }
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            Main_Load(null, null);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new SheaduleContext();
            string fc;
            if (comboBoxStudent3.SelectedValue == null)
                fc = "ИВТФ";
            else fc = comboBoxStudent3.SelectedValue.ToString();
            var fac = db.FACULTY.FirstOrDefault(p => p.FACULTY_NAME == fc);
            comboBoxStudent1.Items.Clear();
            for (int i = 0; i < dataGridView4.RowCount - 1; i++)
            {
                if (dataGridView4.Rows[i].Cells[1].Value.ToString() == fac.FACULTY_CODE.ToString())
                {
                    comboBoxStudent1.Items.Add(dataGridView4.Rows[i].Cells[2].Value.ToString());
                }
            }
            comboBoxStudent1.SelectedIndex = 0;
        }

        private void checkBoxStudent2_CheckedChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void checkBoxStudent1_CheckedChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            bool check = radioButton1.Checked;
            Student1.Visible =
                    Student2.Visible =
                        Student3.Visible =
                                    comboBoxStudent1.Visible =
                                        comboBoxStudent2.Visible = comboBoxStudent3.Visible = radioButton4.Visible= radioButton5.Visible=check;
            if (check)
            {
                button1_Click(null,null);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = radioButton2.Checked;
            Teacher2.Visible =
                    comboBoxTeacher3.Visible =
                        check;
            if (check)
            {
                button1_Click_1(null, null);
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            bool check = radioButton3.Checked;
            Aud2.Visible =
                    comboBox1.Visible = comboBox2.Visible=
                        check;
            if (check)
            {
                aud(null, null);
            }
        }
        
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            db = new SheaduleContext();
            string build;
            if (comboBox1.SelectedItem == null)
                build = "Б";
            else build = comboBox1.SelectedItem.ToString();
            comboBox2.Items.Clear();
            for (int i = 0; i < dataGridView5.RowCount - 1; i++)
            {
                if (dataGridView5.Rows[i].Cells[1].Value.ToString() == build)
                {
                    comboBox2.Items.Add(dataGridView5.Rows[i].Cells[3].Value.ToString());
                }
            }
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
            else
            {
                comboBox2.Text = "";
            }
        }
        
        private void aud(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                for (int j = 1; j < dataGridView2.RowCount; j++)
                {
                    if (j == 8)
                        continue; ;
                    dataGridView2.Rows[j].Cells[i].Value = "";
                    dataGridView2.Rows[j].Cells[i].Style.BackColor = Color.White;
                }
            }
            dataGridView2.AutoSize = true;
            dataGridView2.Rows[8].Height = 0;
            string build;
            if (comboBox1.SelectedItem != null)
                build = comboBox1.SelectedItem.ToString();
            else build = "Б";
            string aud;
            if (comboBox2.SelectedItem == null)
            {
                aud = "";
            }
            else
            {
                aud = comboBox2.SelectedItem.ToString();
            }
            dataGridView2.Rows[0].Cells[1].Value = "Понедельник";
            dataGridView2.Rows[0].Cells[2].Value = "Вторник";
            dataGridView2.Rows[0].Cells[3].Value = "Среда";
            dataGridView2.Rows[0].Cells[4].Value = "Четверг";
            dataGridView2.Rows[0].Cells[5].Value = "Пятница";
            dataGridView2.Rows[0].Cells[6].Value = "Суббота";
            dataGridView2.Rows[0].Cells[7].Value = "Воскресенье";
            dataGridView2.Rows[1].Cells[0].Value = "8.00-9.35";
            dataGridView2.Rows[2].Cells[0].Value = "9.50-11.25";
            dataGridView2.Rows[3].Cells[0].Value = "11.40-13.15";
            dataGridView2.Rows[4].Cells[0].Value = "14.00-15.35";
            dataGridView2.Rows[5].Cells[0].Value = "15.50-17.25";
            dataGridView2.Rows[6].Cells[0].Value = "17.40-19.15";
            dataGridView2.Rows[7].Cells[0].Value = "19.25-21.00";
            dataGridView2.Rows[1 + 8].Cells[0].Value = "8.00-9.35";
            dataGridView2.Rows[2 + 8].Cells[0].Value = "9.50-11.25";
            dataGridView2.Rows[3 + 8].Cells[0].Value = "11.40-13.15";
            dataGridView2.Rows[4 + 8].Cells[0].Value = "14.00-15.35";
            dataGridView2.Rows[5 + 8].Cells[0].Value = "15.50-17.25";
            dataGridView2.Rows[6 + 8].Cells[0].Value = "17.40-19.15";
            dataGridView2.Rows[7 + 8].Cells[0].Value = "19.25-21.00";
            dataGridView2.Rows[0].Cells[0].Value = build + "-" + aud;
            dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView2.Rows[8].DefaultCellStyle.BackColor = Color.Lavender;
            dataGridView2.RowHeadersWidth = 100;
            dataGridView2.Rows[8].Height = 0;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = false;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.Rows[8].Height = 0;
            int crosses = 1;
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                dataGridView2.Columns[i].Width = 135;
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Rows[8].Height = 0;
            int day = 0;
            int time = 0;
            int week = 0;
            Color activityColor = new Color();
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == build && dataGridView1.Rows[i].Cells[4].Value.ToString() == aud)
                {
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "2")
                        week = 8;
                    else week = 0;
                    day = GetColumn(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    time = GetRow(dataGridView1.Rows[i].Cells[10].Value.ToString()) + week;
                    if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "Физкультура")
                    {
                        dataGridView2.Rows[time].Cells[day].Value = dataGridView1.Rows[i].Cells[8].Value;
                    }
                    else
                    {
                        dataGridView2.Rows[time].Cells[day].Value = (string)dataGridView1.Rows[i].Cells[8].Value + " " +
                                                                    dataGridView1.Rows[i].Cells[7].Value + " " +
                                                                    dataGridView1.Rows[i].Cells[3].Value +
                                                                    dataGridView1.Rows[i].Cells[4].Value;
                    }
                    activityColor = GetColor(dataGridView1.Rows[i].Cells[9].Value.ToString());
                    dataGridView2.Rows[time].Cells[day].Style.BackColor = activityColor;
                }

            }
            dataGridView2.Rows[8].Height = 0;
        }

        private void картинкойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "jpg|*.jpg";
            fd.Title = "Save an Image File";
            Bitmap bmp = new Bitmap(dataGridView2.Size.Width + 10, dataGridView2.Size.Height + 30);
            dataGridView2.DrawToBitmap(bmp, dataGridView2.Bounds);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bmp.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    MessageBox.Show("Impossible to save image", "FATAL ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void excelФайломToolStripMenuItem_Click(object sender, EventArgs e)
        {
             DataTable dt = new DataTable();
              Excel.Range rng;
              Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
              Excel.Workbook ExcelWorkBook;
              Excel.Worksheet ExcelWorkSheet;
              ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
              ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
              rng= ExcelWorkSheet.get_Range("A2", "H17");
             for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
              {
                  ExcelWorkSheet.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
              }
            string sellName="";
            Excel.Range rn;
            rng.Borders.LineStyle = Excel.XlBordersIndex.xlInsideHorizontal;
            rng.WrapText = true;
            rng.Columns.ColumnWidth = 24;
            rng.Rows.AutoFit();
            Excel.Range rng1 = ExcelWorkSheet.get_Range("A2", "A2");
            rng1.Interior.ColorIndex = 34;
            rng1.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            Excel.Range rng2 = ExcelWorkSheet.get_Range("B2", "H2");
            rng2.Interior.ColorIndex = 42;
            rng2.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            Excel.Range rng3 = ExcelWorkSheet.get_Range("A3", "A17");
            rng3.ColumnWidth = 10;
            rng3.Interior.ColorIndex = 42;
            rng3.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            Excel.Range rng4 = ExcelWorkSheet.get_Range("A10", "H10");
            rng4.Interior.ColorIndex = 24;
            rng4.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            int number;
            for (int i = 0; i < dataGridView2.Rows.Count ; i++)
              {
                  for (int j = 0; j < dataGridView2.Columns.Count ; j++)
                  {
                      if (dataGridView2.Rows[i].Cells[j].Value != null)
                      {
                          ExcelWorkSheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                        if (j == 1)
                            sellName = "B";
                        else if (j == 2)
                            sellName = "C";
                        else if (j == 3)
                            sellName = "D";
                        else if (j == 4)
                            sellName = "E";
                        else if (j == 5)
                            sellName = "F";
                        else if (j == 6)
                            sellName = "G";
                        else if (j == 7)
                            sellName = "H";
                          number = i + 2;
                          if (i > 0 && j > 0 && dataGridView2.Rows[i].Cells[j].Value!="")
                          {
                              rn = ExcelWorkSheet.get_Range(sellName + "" + number, sellName + "" + number);
                              if (dataGridView2.Rows[i].Cells[j].Style.BackColor == Color.LightPink)
                                  rn.Interior.ColorIndex = 38;
                              else if (dataGridView2.Rows[i].Cells[j].Style.BackColor == Color.PaleGreen)
                                  rn.Interior.ColorIndex = 35;
                              else if (dataGridView2.Rows[i].Cells[j].Style.BackColor == Color.BlanchedAlmond)
                                  rn.Interior.ColorIndex = 36;
                              else if (dataGridView2.Rows[i].Cells[j].Style.BackColor == Color.Thistle)
                                  rn.Interior.ColorIndex = 37;
                              rn.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
                          }
                      }
                }
              }
            
            ExcelApp.Visible = true;

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3_CheckedChanged(null, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1_CheckedChanged(null, null);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5_CheckedChanged(null, null);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3_CheckedChanged(null, null);
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TascAdd ta = new TascAdd();
            ta.ShowDialog();
        }

        private void таблицейExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excelФайломToolStripMenuItem_Click(null, null);
        }

        private void изображениемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            картинкойToolStripMenuItem_Click(null,null);
        }

        private void распечататьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Print_Click(null, null);
        }

        private void нагрузкаПреподавателейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Excel.Range rng;
            Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            List<Teacher> teachers = new List<Teacher>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!teachers.Any(t => t.name == dataGridView1.Rows[i].Cells[7].Value.ToString()))
                {
                    teachers.Add(new Teacher(dataGridView1.Rows[i].Cells[7].Value.ToString()));
                }
                if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Лекция")
                    teachers.First(t => t.name == dataGridView1.Rows[i].Cells[7].Value.ToString()).lecturs++;
                else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Семинар")
                    teachers.First(t => t.name == dataGridView1.Rows[i].Cells[7].Value.ToString()).seminars++;
                else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Лабараторная")
                    teachers.First(t => t.name == dataGridView1.Rows[i].Cells[7].Value.ToString()).labs++;
                else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Физическое воспитание")
                    teachers.First(t => t.name == dataGridView1.Rows[i].Cells[7].Value.ToString()).phisicalEducation++;
            }
            rng = ExcelWorkSheet.get_Range("A2", "F"+ (teachers.Count+2));
            rng.Borders.LineStyle = Excel.XlBordersIndex.xlInsideHorizontal;
            rng.WrapText = true;
            rng.Rows.AutoFit();
            ExcelWorkSheet.Cells[2, 1] = "Преподаватель";
            ExcelWorkSheet.Cells[2, 2] = "Лекции";
            ExcelWorkSheet.Cells[2, 3] = "Семинары";
            ExcelWorkSheet.Cells[2, 4] = "Лабораторные";
            ExcelWorkSheet.Cells[2, 5] = "Физическое воспитание";
            ExcelWorkSheet.Cells[2, 6] = "Всего";
            Excel.Range rng1 = ExcelWorkSheet.get_Range("A2", "F2");
            rng1.Interior.ColorIndex = 34;
            rng1.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            for (int i = 0; i < teachers.Count; i++)
            {
                ExcelWorkSheet.Cells[i+3,1] = teachers[i].name;
                ExcelWorkSheet.Cells[i+3,2] = teachers[i].lecturs;
                ExcelWorkSheet.Cells[i+3,3] = teachers[i].seminars;
                ExcelWorkSheet.Cells[i+3,4] = teachers[i].labs;
                ExcelWorkSheet.Cells[i+3,5] = teachers[i].phisicalEducation;
                ExcelWorkSheet.Cells[i+3,6] = teachers[i].All();
            }

            ExcelApp.Visible = true;

        }

        private void нагрузкаАудиторийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Excel.Range rng;
            Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            List<Auditory> auditories = new List<Auditory>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!auditories.Any(t => t.building == dataGridView1.Rows[i].Cells[3].Value.ToString()&& t.number == dataGridView1.Rows[i].Cells[4].Value.ToString()))
                {
                    auditories.Add(new Auditory(dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString()));
                }
                if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Лекция")
                    auditories.First(t => t.building == dataGridView1.Rows[i].Cells[3].Value.ToString() && t.number == dataGridView1.Rows[i].Cells[4].Value.ToString()).lecturs++;
                else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Семинар")
                    auditories.First(t => t.building == dataGridView1.Rows[i].Cells[3].Value.ToString() && t.number == dataGridView1.Rows[i].Cells[4].Value.ToString()).seminars++;
                else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Лабараторная")
                    auditories.First(t => t.building == dataGridView1.Rows[i].Cells[3].Value.ToString() && t.number == dataGridView1.Rows[i].Cells[4].Value.ToString()).labs++;
                else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Физическое воспитание")
                    auditories.First(t => t.building == dataGridView1.Rows[i].Cells[3].Value.ToString() && t.number == dataGridView1.Rows[i].Cells[4].Value.ToString()).phisicalEducation++;
            }
            rng = ExcelWorkSheet.get_Range("A2", "F" + (auditories.Count + 2));
            rng.Borders.LineStyle = Excel.XlBordersIndex.xlInsideHorizontal;
            rng.WrapText = true;
            rng.Rows.AutoFit();
            ExcelWorkSheet.Cells[2, 1] = "Аудитория";
            ExcelWorkSheet.Cells[2, 2] = "Лекции";
            ExcelWorkSheet.Cells[2, 3] = "Семинары";
            ExcelWorkSheet.Cells[2, 4] = "Лабораторные";
            ExcelWorkSheet.Cells[2, 5] = "Физическое воспитание";
            ExcelWorkSheet.Cells[2, 6] = "Всего";
            Excel.Range rng1 = ExcelWorkSheet.get_Range("A2", "F2");
            rng1.Interior.ColorIndex = 34;
            rng1.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
            for (int i = 0; i < auditories.Count; i++)
            {
                ExcelWorkSheet.Cells[i + 3, 1] = auditories[i].building+"-"+ auditories[i].number;
                ExcelWorkSheet.Cells[i + 3, 2] = auditories[i].lecturs;
                ExcelWorkSheet.Cells[i + 3, 3] = auditories[i].seminars;
                ExcelWorkSheet.Cells[i + 3, 4] = auditories[i].labs;
                ExcelWorkSheet.Cells[i + 3, 5] = auditories[i].phisicalEducation;
                ExcelWorkSheet.Cells[i + 3, 6] = auditories[i].All();
            }

            ExcelApp.Visible = true;

        }

        private void администраторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin(password);
            adm.ShowDialog();
            s = adm.textBox1.Text;
            if (s==password)
            {
                contextMenuStrip1.Visible = menuStrip2.Visible = true;
                menuStrip1.Visible = false;
                button1.Visible = false;
                dataGridView2.ContextMenuStrip = contextMenuStrip1;
            }
        }
    }
}
