namespace SheaduleASP.Models
{
    public class Lesson
    {
        public string activityType;
        public string auditorium;
        public string building;
        public string course;
        public string crosses;
        public string discipline;
        public string faculty;
        public string group;
        public string teacher;
        public string time;
        public int timeNumber;

        public string weekDay;
        public int weekDayNumber;
        public string weekNumber;

        public Lesson(string WeekDay, string Course, string Group, string Teacher, string Discipline,
            string ActivityType, string Auditorium, string WeekNumber, string Time, string Crosses, string Faculty,
            int TimeNumber, int WeekDayNumber, string Building)
        {
            weekDay = WeekDay;
            course = Course;
            group = Group;
            teacher = Teacher;
            discipline = Discipline;
            activityType = ActivityType;
            auditorium = Auditorium;
            weekNumber = WeekNumber;
            time = Time;
            crosses = Crosses;
            faculty = Faculty;
            weekDayNumber = WeekDayNumber;
            timeNumber = TimeNumber;
            building = Building;
        }
    }
}