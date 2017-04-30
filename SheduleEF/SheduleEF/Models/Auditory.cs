using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleEF.Models
{
    public class Auditory
    {
        public Auditory(string building, string number, int labs=0, int seminars=0, int lections=0, int pE = 0)
        {
            this.building = building;
            this.number = number;
            this.lecturs = lections;
            this.labs = labs;
            this.phisicalEducation = pE;
            this.seminars = seminars;
        }
        public string building;
        public int lecturs;
        public string number;
        public int labs;
        public int phisicalEducation;
        public int seminars;

        public int All()
        {
            return lecturs + labs + phisicalEducation + seminars;
        }
    }
}
