using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web.Mvc;
using SheaduleASP.Models;

namespace SheaduleASP.Controllers
{
    public class SheaduleController : Controller
    {
        private readonly SheaduleContext db = new SheaduleContext();

        public ActionResult Index()
        {
            ViewBag.FACULTY_NAME = new SelectList(db.FACULTY, "FACULTY_CODE", "FACULTY_NAME");
            ViewBag.GROUP_NUMBER = new SelectList(db.GROUPS, "GROUP_CODE", "GROUP_NUMBER");
            ViewBag.TEACHER_NAME = new SelectList(db.TEACHER, "TEACHER_CODE", "TEACHER_NAME");
            ViewBag.AUDITORIUM_NUMBER = new SelectList(db.AUDITORIUM, "AUDITORIUM_CODE", "AUDITORIUM_NUMBER");

            return View();
        }

        [HttpPost]
        public string Sheadule()
        {
            IEnumerable<GROUPS> groups = db.GROUPS;
            ViewBag.Groups = groups;

            IEnumerable<ACTIVITY> activities = db.ACTIVITY;
            ViewBag.Activity = activities;

            IEnumerable<AUDITORIUM> auditoriums = db.AUDITORIUM;
            ViewBag.Auditorium = auditoriums;

            IEnumerable<DISCIPLINE> disciplines = db.DISCIPLINE;
            ViewBag.Discipline = disciplines;

            IEnumerable<FACULTY> faculties = db.FACULTY;
            ViewBag.Faculty = faculties;

            IEnumerable<TEACHER> teachers = db.TEACHER;
            ViewBag.Teacher = teachers;

            IEnumerable<TIME> times = db.TIME;
            ViewBag.Times = times;

            IEnumerable<TIMETABLE> timetables = db.TIMETABLE;
            ViewBag.TimeTable = timetables;

            IEnumerable<WEEKDAY> weekdays = db.WEEKDAY;
            ViewBag.WeekDay = weekdays;

            var lessons = new List<Lesson>();

            string weekDay;
            int weekDayNumber;
            string course;
            string group;
            string teacher;
            string discipline;
            string activityType;
            string auditorium;
            string weekNumber;
            string time;
            int timeNumber;
            string crosses;
            string faculty;
            string building;
            const string headColor = "bgcolor =\"#F8F8F8\"";

            foreach (var timetable in timetables)
            {
                weekDay = weekdays.First(sss => sss.WEEKDAY_CODE == (int) timetable.WEEKDAY_CODE).WEEKDAY_NAME;
                weekDayNumber = (int) timetable.WEEKDAY_CODE;
                timeNumber = (int) timetable.TIME_CODE;
                course = timetable.COURSE_CODE.ToString();
                group = groups.First(sss => sss.GROUP_CODE == (int) timetable.GROUP_CODE).GROUP_NUMBER;
                teacher = teachers.First(sss => sss.TEACHER_CODE == (int) timetable.TEACHER_CODE).TEACHER_NAME;
                discipline = disciplines.First(sss => sss.DISCIPLINE_CODE == (int) timetable.DISCIPLINE_CODE)
                    .DISCIPLINE_NAME;
                activityType = activities.First(sss => sss.ACTIVITY_TYPE_CODE == (int) timetable.ACTIVITY_TYPE_CODE)
                    .ACTIVITY_TYPE_NAME;
                building = auditoriums.First(sss => sss.AUDITORIUM_CODE == (int) timetable.AUDITORIUM_CODE).BUILDING;
                auditorium = auditoriums.First(sss => sss.AUDITORIUM_CODE == (int) timetable.AUDITORIUM_CODE)
                    .AUDITORIUM_NUMBER;
                weekNumber = timetable.WEEK_NUMBER.ToString();
                time = times.First(sss => sss.TIME_CODE == (int) timetable.TIME_CODE).TIME_START;
                crosses = timetable.CROSSES.ToString();
                faculty = faculties.First(sss => sss.FACULTY_CODE ==
                                                 (int) groups.First(aaa => aaa.GROUP_CODE == (int) timetable.GROUP_CODE)
                                                     .FACULTY_CODE)
                    .FACULTY_NAME;

                lessons.Add(new Lesson(weekDay, course, group, teacher, discipline, activityType, auditorium,
                    weekNumber, time, crosses, faculty, weekDayNumber, timeNumber, building));
            }
            var main = "";
            var shedule = new string[7, 15];
            int[,] color = new int[7, 15];
            for (var i = 0; i < 7; i++)
            for (var j = 0; j < 15; j++)
            {
                shedule[i, j] = "";
                color[i, j] = 5;
            }
            switch (Request.Params.Get("SHEDULE"))
            {
                case "students":
                    var Group = groups.First(gr => gr.GROUP_CODE.ToString() ==
                                                   Request.Params.Get("GROUP_NUMBER").ToString())
                        .GROUP_NUMBER;
                    var Cource = Request.Params.Get("COURCE_NUMBER");
                    var Crosses = Request.Params.Get("CROSSES");
                    var Faculty = faculties.First(gr => gr.FACULTY_CODE.ToString() ==
                                                        Request.Params.Get("FACULTY_NAME").ToString())
                        .FACULTY_NAME;
                    int wek;
                    foreach (var lesson in lessons)
                    {
                        if (lesson.weekNumber == "1")
                            wek = 0;
                        else wek = 8;

                        if (lesson.group == Group && lesson.course == Cource && lesson.crosses == Crosses &&
                            lesson.faculty == Faculty)
                            shedule[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] =
                                lesson.discipline + " " + lesson.teacher + " " + lesson.building + lesson.auditorium;
                        if (lesson.activityType== "Лекция")
                        { 
                           color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 1;
                        }
                        else if (lesson.activityType == "Семинар")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 2;
                        }
                        else if (lesson.activityType == "Физическое воспитание")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 3;
                        }
                        else if (lesson.activityType == "Лабараторная")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 4;
                        }
                    }
                    main += "<table border='10' bordercolor='#d3d3d3' cellpadding='10'>";
                    main += "<tr>";
                    main += "<th "+headColor+"><p>" + Cource + "-" + Group + "</p></th>";
                    main += "<th "+headColor+"><p>Понедельник</p></th>";
                    main += "<th "+headColor+"><p>Вторник</p></th>";
                    main += "<th "+headColor+"><p>Среда</p></th>";
                    main += "<th "+headColor+"><p>Четверг</p></th>";
                    main += "<th "+headColor+"><p>Пятница</p></th>";
                    main += "<th "+headColor+"><p>Суббота</p></th>";
                    main += "<th "+headColor+"><p>Воскресенье</p></th>";
                    main += "</tr>";
                    for (int i = 0; i < 7; i++)
                    {
                        main += "<tr>";
                        if (i==0 || i==7) main += "<td "+headColor+"><p>8.00-9.35</p></td>";
                        if (i==1 || i==8) main += "<td "+headColor+"><p>9.50-11.25</p></td>";
                        if (i==2 || i==9) main += "<td "+headColor+"><p>11.40-13.15</p></td>";
                        if (i==3 || i==10) main +="<td "+headColor+"><p>14.00-15.35</p></td>";
                        if (i==4 || i==11) main +="<td "+headColor+"><p>15.50-17.25</p></td>";
                        if (i==5 || i==12) main +="<td "+headColor+"><p>17.40-19.15</p></td>";
                        if (i==6 || i==13) main +="<td "+headColor+"><p>19.25-21.00</p></td>";
                        for (int j = 0; j < 7; j++)
                        {
                            main += HtmlString(shedule[i, j], color[i, j]);
                        }
                        main += "</tr>";
                    }
                    main += "<tr><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td></tr>";
                    for (int i = 0; i < 7; i++)
                    {
                        main += "<tr>";
                        if (i == 0 || i == 7) main += "<td " + headColor + "><p>8.00-9.35</p></td>";
                        if (i == 1 || i == 8) main += "<td " + headColor + "><p>9.50-11.25</p></td>";
                        if (i == 2 || i == 9) main += "<td " + headColor + "><p>11.40-13.15</p></td>";
                        if (i == 3 || i == 10) main += "<td " + headColor + "><p>14.00-15.35</p></td>";
                        if (i == 4 || i == 11) main += "<td " + headColor + "><p>15.50-17.25</p></td>";
                        if (i == 5 || i == 12) main += "<td " + headColor + "><p>17.40-19.15</p></td>";
                        if (i == 6 || i == 13) main += "<td " + headColor + "><p>19.25-21.00</p></td>";
                        for (int j = 8; j < 15; j++)
                        {
                            main += HtmlString(shedule[i, j], color[i, j]);
                        }
                        main += "</tr>";
                    }
                    main += "</table>";
                    break;

                case "teachers":
                    var Teacher = teachers.First(gr => gr.TEACHER_CODE.ToString() ==
                                                       Request.Params.Get("TEACHER_NAME").ToString())
                        .TEACHER_NAME;
                    foreach (var lesson in lessons)
                    {
                        if (lesson.weekNumber == "1")
                            wek = 0;
                        else wek = 7;

                        if (lesson.teacher == Teacher)
                            shedule[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] =
                                lesson.discipline + " " + lesson.building + lesson.auditorium;
                        if (lesson.activityType == "Лекция")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 1;
                        }
                        else if (lesson.activityType == "Семинар")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 2;
                        }
                        else if (lesson.activityType == "Физическое воспитание")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 3;
                        }
                        else if (lesson.activityType == "Лабараторная")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 4;
                        }
                    }
                    main += "<table border='10' bordercolor='#d3d3d3' cellpadding='10'>";
                    main += "<tr>";
                    main += "<th><p>" + Teacher + "</p></th>";
                    main += "<th " + headColor + "><p>Понедельник</p></th>";
                    main += "<th " + headColor + "><p>Вторник</p></th>";
                    main += "<th " + headColor + "><p>Среда</p></th>";
                    main += "<th " + headColor + "><p>Четверг</p></th>";
                    main += "<th " + headColor + "><p>Пятница</p></th>";
                    main += "<th " + headColor + "><p>Суббота</p></th>";
                    main += "<th " + headColor + "><p>Воскресенье</p></th>";
                    main += "</tr>";
                    for (int i = 0; i < 7; i++)
                    {
                        main += "<tr>";
                        if (i == 0 || i == 7) main += "<td " + headColor + "><p>8.00-9.35</p></td>";
                        if (i == 1 || i == 8) main += "<td " + headColor + "><p>9.50-11.25</p></td>";
                        if (i == 2 || i == 9) main += "<td " + headColor + "><p>11.40-13.15</p></td>";
                        if (i == 3 || i == 10) main += "<td " + headColor + "><p>14.00-15.35</p></td>";
                        if (i == 4 || i == 11) main += "<td " + headColor + "><p>15.50-17.25</p></td>";
                        if (i == 5 || i == 12) main += "<td " + headColor + "><p>17.40-19.15</p></td>";
                        if (i == 6 || i == 13) main += "<td " + headColor + "><p>19.25-21.00</p></td>";
                        for (int j = 0; j < 7; j++)
                        {
                          main += HtmlString(shedule[i, j], color[i, j]);
                        }
                        main += "</tr>";
                    }
                    main += "<tr><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td></tr>";
                    for (int i = 0; i < 7; i++)
                    {
                        main += "<tr>";
                        if (i == 0 || i == 7) main += "<td " + headColor + "><p>8.00-9.35</p></td>";
                        if (i == 1 || i == 8) main += "<td " + headColor + "><p>9.50-11.25</p></td>";
                        if (i == 2 || i == 9) main += "<td " + headColor + "><p>11.40-13.15</p></td>";
                        if (i == 3 || i == 10) main += "<td " + headColor + "><p>14.00-15.35</p></td>";
                        if (i == 4 || i == 11) main += "<td " + headColor + "><p>15.50-17.25</p></td>";
                        if (i == 5 || i == 12) main += "<td " + headColor + "><p>17.40-19.15</p></td>";
                        if (i == 6 || i == 13) main += "<td " + headColor + "><p>19.25-21.00</p></td>";
                        for (int j = 8; j < 15; j++)
                        {
                            main += HtmlString(shedule[i, j], color[i, j]);
                        }
                        main += "</tr>";
                    }
                    main += "</table>";
                    break;

                case "auditoriums":
                    var Auditor = auditoriums.First(gr => gr.AUDITORIUM_CODE.ToString() ==
                                                          Request.Params.Get("AUDITORIUM_NUMBER").ToString())
                        .AUDITORIUM_NUMBER;
                    var Building = auditoriums.First(gr => gr.AUDITORIUM_CODE.ToString() ==
                                                           Request.Params.Get("AUDITORIUM_NUMBER").ToString())
                        .BUILDING;
                    foreach (var lesson in lessons)
                    {
                        if (lesson.weekNumber == "1")
                            wek = 0;
                        else wek = 7;

                        if (lesson.auditorium == Auditor)
                            shedule[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] =
                                lesson.discipline + " " + lesson.teacher + " " + lesson.building + lesson.auditorium;
                        if (lesson.activityType == "Лекция")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 1;
                        }
                        else if (lesson.activityType == "Семинар")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 2;
                        }
                        else if (lesson.activityType == "Физическое воспитание")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 3;
                        }
                        else if (lesson.activityType == "Лабараторная")
                        {
                            color[lesson.weekDayNumber - 1, lesson.timeNumber + wek - 1] = 4;
                        }
                    }
                    main += "<table border='10' bordercolor='#d3d3d3' cellpadding='10'>";
                    main += "<tr>";
                    main += "<th><p>" + Building +"-" + Auditor + "</p></th>";
                    main += "<th " + headColor + "><p>Понедельник</p></th>";
                    main += "<th " + headColor + "><p>Вторник</p></th>";
                    main += "<th " + headColor + "><p>Среда</p></th>";
                    main += "<th " + headColor + "><p>Четверг</p></th>";
                    main += "<th " + headColor + "><p>Пятница</p></th>";
                    main += "<th " + headColor + "><p>Суббота</p></th>";
                    main += "<th " + headColor + "><p>Воскресенье</p></th>";
                    main += "</tr>";
                    for (int i = 0; i < 7; i++)
                    {
                        main += "<tr>";
                        if (i == 0 || i == 7) main += "<td " + headColor + "><p>8.00-9.35</p></td>";
                        if (i == 1 || i == 8) main += "<td " + headColor + "><p>9.50-11.25</p></td>";
                        if (i == 2 || i == 9) main += "<td " + headColor + "><p>11.40-13.15</p></td>";
                        if (i == 3 || i == 10) main += "<td " + headColor + "><p>14.00-15.35</p></td>";
                        if (i == 4 || i == 11) main += "<td " + headColor + "><p>15.50-17.25</p></td>";
                        if (i == 5 || i == 12) main += "<td " + headColor + "><p>17.40-19.15</p></td>";
                        if (i == 6 || i == 13) main += "<td " + headColor + "><p>19.25-21.00</p></td>";
                        for (int j = 0; j < 7; j++)
                        {
                           main += HtmlString(shedule[i, j], color[i, j]);
                        }
                        main += "</tr>";
                    }
                    main += "<tr><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td><td bgcolor=\"#d3d3d3\"></td></tr>";
                    for (int i = 0; i < 7; i++)
                    {
                        main += "<tr>";
                        if (i == 0 || i == 7) main += "<td " + headColor + "><p>8.00-9.35</p></td>";
                        if (i == 1 || i == 8) main += "<td " + headColor + "><p>9.50-11.25</p></td>";
                        if (i == 2 || i == 9) main += "<td " + headColor + "><p>11.40-13.15</p></td>";
                        if (i == 3 || i == 10) main += "<td " + headColor + "><p>14.00-15.35</p></td>";
                        if (i == 4 || i == 11) main += "<td " + headColor + "><p>15.50-17.25</p></td>";
                        if (i == 5 || i == 12) main += "<td " + headColor + "><p>17.40-19.15</p></td>";
                        if (i == 6 || i == 13) main += "<td " + headColor + "><p>19.25-21.00</p></td>";
                        for (int j = 8; j < 15; j++)
                        {
                            main += HtmlString(shedule[i, j], color[i, j]);
                        }
                        main += "</tr>";
                    }
                    main += "</table>";
                    break;
            }

            return main;
        }
        
        private string HtmlString(string text, int color)
        {
            if (text != "")
            {
                if (color == 1)
                {
                    return "<td bgcolor=\"#FFFACD\"><p>" + text + "</p></td>";
                }
                else if (color == 2)
                {
                    return "<td bgcolor=\"#98FB98\"><p>" + text + "</p></td>";
                }
                else if (color == 3)
                {
                    return "<td bgcolor=\"#87CEFA\"><p>" + text + "</p></td>";
                }
                else if (color == 4)
                {
                    return "<td bgcolor=\"#FFE4E1\"><p>" + text + "</p></td>";
                }
            }
            return "<td><p>" + text + "</p></td>";
        }
    }
}