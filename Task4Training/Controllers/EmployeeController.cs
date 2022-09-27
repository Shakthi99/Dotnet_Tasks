using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task4Training.Service;
using Task4Training.Interface;



namespace Task4Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("GetEmployeesData")]
        public async Task<IActionResult> GetEmployeesData()
        {
            try
            {
                var result = await _employeeService.GetEmployees();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

