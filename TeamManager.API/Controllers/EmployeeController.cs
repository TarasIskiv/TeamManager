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
        public async Task<IActionResult> GetEmployee([FromQuery] string id)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(id);
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees([FromQuery] string teamId)
        {
            try
            {
                var employees = await _employeeService.GetEmployees(teamId);
                return Ok(employees);
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
                await _employeeService.AddEmployee(employee);
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
                await _employeeService.UpdateEmployee(employee);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }

        [HttpDelete("RemoveEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromQuery] string id, [FromQuery] bool keepInHistory)
        {
            try
            {
                await _employeeService.RemoveEmployee(id, keepInHistory);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }
    }
}
