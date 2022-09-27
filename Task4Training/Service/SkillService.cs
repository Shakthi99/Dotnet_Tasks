using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task4Training.Models;
using Task4Training.Interface;
using Microsoft.EntityFrameworkCore;


namespace Task4Training.Service
{
    public class SkillService: ISkill
    {
        private readonly TaskContext _taskContext;
        public SkillService(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }
        public async Task<IEnumerable<SkillResponse>> GetAllSkills()
        {
            var result = await _taskContext.Skills.Include(x => x.skillmap).ThenInclude(x => x.skills).Select(x => new SkillResponse
            {
                SkillID = x.SkillID,
                Name = x.Name,
                employee = x.skillmap.Select(y => y.employee.EmpName).ToList()
            }).ToListAsync();
            return result;
        }
    }
}

