using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task4Training.Models
{
    public class SkillsMap
    {
        public int EmployeeID { get; set; }
        public int SkillID { get; set; }
        public Emp employee { get; set; }
        public EmpSkills skills { get; set; }
    }
}
