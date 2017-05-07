﻿using System;
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
    public partial class TascAddAud : Form
    {
        string build;
        string aud;
        string weekday;
        private int weeknumber;
        string time;
        private SheaduleContext db;
        public TascAddAud(string build,string aud,string weekday,int weeknumber, string time)
        {
            InitializeComponent();

            this.build = build;
            this.aud = aud;
            this.weekday = weekday;
            this.weeknumber = weeknumber;
            this.time = time;
            db=new SheaduleContext();
            Activity.DropDownStyle =
                    Course.DropDownStyle =
                            Discipline.DropDownStyle =
                                Group.DropDownStyle =
                                    Teacher.DropDownStyle =ComboBoxStyle.DropDownList;
            Course.Text = "3";
            AddList.SelectedIndex = 0;
            TascAdd_Load(null, null);
        }

        private void TascAdd_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet22.ACTIVITY". При необходимости она может быть перемещена или удалена.
            this.aCTIVITYTableAdapter1.Fill(this.sheaduleDataSet22.ACTIVITY);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet21.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter10.Fill(this.sheaduleDataSet21.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet20.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter9.Fill(this.sheaduleDataSet20.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet19.GROUPS". При необходимости она может быть перемещена или удалена.
            this.gROUPSTableAdapter1.Fill(this.sheaduleDataSet19.GROUPS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet17.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter8.Fill(this.sheaduleDataSet17.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet16.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter7.Fill(this.sheaduleDataSet16.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet15.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter6.Fill(this.sheaduleDataSet15.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet14.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter5.Fill(this.sheaduleDataSet14.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet13.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter4.Fill(this.sheaduleDataSet13.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet12.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter3.Fill(this.sheaduleDataSet12.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet11.TimeTableView". При необходимости она может быть перемещена или удалена.
            this.timeTableViewTableAdapter.Fill(this.sheaduleDataSet11.TimeTableView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet8.TIME". При необходимости она может быть перемещена или удалена.
            this.tIMETableAdapter.Fill(this.sheaduleDataSet8.TIME);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet7.TEACHER". При необходимости она может быть перемещена или удалена.
            this.tEACHERTableAdapter.Fill(this.sheaduleDataSet7.TEACHER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet6.WEEKDAY". При необходимости она может быть перемещена или удалена.
            this.wEEKDAYTableAdapter.Fill(this.sheaduleDataSet6.WEEKDAY);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet5.GROUPS". При необходимости она может быть перемещена или удалена.
            this.gROUPSTableAdapter.Fill(this.sheaduleDataSet5.GROUPS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet4.DISCIPLINE". При необходимости она может быть перемещена или удалена.
            this.dISCIPLINETableAdapter.Fill(this.sheaduleDataSet4.DISCIPLINE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet3.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter2.Fill(this.sheaduleDataSet3.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet2.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter1.Fill(this.sheaduleDataSet2.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet1.AUDITORIUM". При необходимости она может быть перемещена или удалена.
            this.aUDITORIUMTableAdapter.Fill(this.sheaduleDataSet1.AUDITORIUM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sheaduleDataSet.ACTIVITY". При необходимости она может быть перемещена или удалена.
            this.aCTIVITYTableAdapter.Fill(this.sheaduleDataSet.ACTIVITY);

        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (AddList.SelectedItem.ToString() == "Учителя")
            {
                TeacherAdd ta = new TeacherAdd();
                ta.ShowDialog();
            }
            else if (AddList.SelectedItem.ToString() == "Аудиторию")
            {
                Auditor au = new Auditor();
                au.ShowDialog();
            }
            else if (AddList.SelectedItem.ToString() == "Дисциплину")
            {
                DisciplineAdd dis = new DisciplineAdd();
                dis.ShowDialog();
            }
            else if (AddList.SelectedItem.ToString() == "Группу")
            {
                GroupAdd ga = new GroupAdd();
                ga.ShowDialog();
            }
            else if (AddList.SelectedItem.ToString() == "Расписание")
            {
                ScheduleAdd sa = new ScheduleAdd();
                sa.ShowDialog();
            }
        }

        private void AddingTask_Click(object sender, EventArgs e)
        {
            try
            {
                TIMETABLE tt = new TIMETABLE();
                WEEKDAY wd = db.WEEKDAY.FirstOrDefault(p => p.WEEKDAY_NAME == weekday);
                if (wd == null) MessageBox.Show("Неверный день недели");
                TYPE type = db.TYPE.FirstOrDefault(p => p.TYPE_NAME == Schedule.SelectedValue.ToString());
                if (type == null) MessageBox.Show("Неверное расписание");
                ACTIVITY ac = db.ACTIVITY.FirstOrDefault(p => p.ACTIVITY_TYPE_NAME == Activity.SelectedValue.ToString());
                if (ac == null) MessageBox.Show("Неверный вид занятия");
                AUDITORIUM au =
                    db.AUDITORIUM.FirstOrDefault(
                        p =>
                            (p.AUDITORIUM_NUMBER == aud &&
                             p.BUILDING == build));
                if (au == null) MessageBox.Show("Неверная аудитория");
                DISCIPLINE dp =
                    db.DISCIPLINE.FirstOrDefault(p => (p.DISCIPLINE_NAME == Discipline.SelectedValue.ToString()));
                if (dp == null) MessageBox.Show("Неверная аудитория");
                GROUPS gr = db.GROUPS.FirstOrDefault(p => p.GROUP_NUMBER == Group.SelectedValue.ToString());
                if (gr == null) MessageBox.Show("Неверная группа");
                TEACHER te = db.TEACHER.FirstOrDefault(p => p.TEACHER_NAME == Teacher.SelectedValue.ToString());
                if (te == null) MessageBox.Show("Неверное имя преподавателя");
                TIME ti = db.TIME.FirstOrDefault(p => p.TIME_START == time);
                if (ti == null) MessageBox.Show("Неверное время занятия");
                TIMETABLE timetable = new TIMETABLE();
                timetable.WEEKDAY_CODE = wd.WEEKDAY_CODE;
                timetable.COURSE_CODE = Convert.ToInt32(Course.SelectedItem.ToString());
                timetable.GROUP_CODE = gr.GROUP_CODE;
                timetable.TEACHER_CODE = te.TEACHER_CODE;
                timetable.DISCIPLINE_CODE = dp.DISCIPLINE_CODE;
                timetable.ACTIVITY_TYPE_CODE = ac.ACTIVITY_TYPE_CODE;
                timetable.AUDITORIUM_CODE = au.AUDITORIUM_CODE;
                timetable.WEEK_NUMBER = weeknumber;
                timetable.TIME_CODE = ti.TIME_CODE;
                timetable.TYPE_CODE = type.TYPE_CODE;
                timetable.CROSSES = checkBox1.Checked ? 2 : 1;
                db.TIMETABLE.Add(timetable);
                db.SaveChanges();
                MessageBox.Show("Объект Добавлен");
            }
            catch (Exception er)
            {
                MessageBox.Show("Все данные должны быть заполнены!");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        

        

        private void TascAdd_Activated(object sender, EventArgs e)
        {
            TascAdd_Load(null, null);
        }

        private void WeekDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
