using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WFM_Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftLockController : ControllerBase
    {
        private WFMContext _context;





        public SoftLockController(WFMContext context)
        {
            _context = context;





        }
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Softlock>>> Get()
        //{





        //    return await _context.Softlocks.ToListAsync();
        //}





        [HttpPost]
        public async Task<ActionResult<IEnumerable<Softlock>>> Post(Softlock Softlock)
        {
            try
            {
                //await _context.Softlocks.AddAsync(Softlock);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, Softlock);
            }





            catch (DbUpdateException)
            {





                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Server Error"
                });
            }
        }
        [HttpDelete]
        public async Task<ActionResult<string>> Delete(int employeeId)
        {



            return StatusCode(StatusCodes.Status204NoContent);

        }
    }
       