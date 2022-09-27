using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Task4Training.Models;

namespace Task4Training.Models
{
    public class EmpSkills
    {
        [Key]
        public int SkillID { get; set; }
        public string Name { get; set; }
        //  public ICollection<Emp> employee { get; set; }
        public ICollection<SkillsMap> skillmap { get; set; }
    }
}
