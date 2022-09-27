using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task4Training.Models;
using Task4Training.Controllers;

namespace Task4Training.Interface
{
    public interface ISkill
    {
        public Task<IEnumerable<SkillResponse>> GetAllSkills();
    }
}
