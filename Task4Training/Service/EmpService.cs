using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task4Training.Models;
using Task4Training.Interface;

namespace Task4Training.Service
{
    public class EmpService:IEmployee
    {
        private readonly TaskContext _taskEmpContext;


        public EmpService(TaskContext taskEmpContext)
        {
            _taskEmpContext = taskEmpContext;
        }

        public async Task<IEnumerable<Employeeswithskills>> GetEmployees()
        {
            var data = await _taskEmpContext.Employees.Select(x => new Employeeswithskills()
            {
                employeeID = x.employeeID,
                EmpName = x.EmpName
            }).ToListAsync();

            if (data != null)
            {
                return data;
            }
            return new List<Employeeswithskills>();
        }
    }
}
