using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleEF.Models
{
    public class Teacher
    {
        public Teacher(string name, int lecturs = 0, int seminars = 0, int labs = 0, int PE = 0)
        {
            this.name = name;
            this.lecturs = lecturs;
            this.labs = labs;
            this.phisicalEducation = PE;
            this.seminars = seminars;
        }

        public string name;
        public int lecturs;
        public int labs;
        public int phisicalEducation;
        public int seminars;

        public int All()
        {
            return lecturs + labs + phisicalEducation + seminars;
        }
    }
}
