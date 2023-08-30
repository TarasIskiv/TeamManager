using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Models;
using TeamManager.Logic.Abstraction;

namespace TeamManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee([FromQuery] Guid id)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees([FromQuery] Guid teamId)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeModel employee)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeModel employee)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }

        [HttpDelete("RemoveEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromQuery] Guid id, [FromQuery] bool keepInHistory)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }
    }
}
