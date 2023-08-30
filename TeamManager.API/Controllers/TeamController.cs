using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Models;

namespace TeamManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        public TeamController()
        {

        }

        [HttpGet("GetTeamNames")]
        public async Task<IActionResult> GetTeamNames()
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

        [HttpPost("AddNewTeam")]
        public async Task<IActionResult> AddNewTeam([FromBody] TeamModel team)
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

        [HttpGet("GetTeam")]
        public async Task<IActionResult> GetTeam([FromQuery] Guid id)
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

        [HttpDelete("RemoveTeam")]
        public async Task<IActionResult> RemoveTeam([FromQuery] Guid id)
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

        [HttpPut("UpdateTeam")]
        public async Task<IActionResult> UpdateTeam([FromBody] TeamModel team)
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
