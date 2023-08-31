using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Models;
using TeamManager.Logic.Abstraction;

namespace TeamManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("GetTeamNames")]
        public async Task<IActionResult> GetTeamNames()
        { 
            try
            {
                var teamNames = await _teamService.GetTeamNames();
                return Ok(teamNames);
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
                await _teamService.AddTeam(team);
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
                var team = await _teamService.GetTeam(id);
                return Ok(team);
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
                await _teamService.RemoveTeam(id);
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
                await _teamService.UpdateTeam(team);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong on server side");
            }
        }
    }
}
