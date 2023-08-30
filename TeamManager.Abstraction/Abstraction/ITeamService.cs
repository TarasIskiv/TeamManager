using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Models;

namespace TeamManager.Logic.Abstraction
{
    public interface ITeamService
    {
        Task<List<TeamNameModel>> GetTeamNames();
        Task<TeamModel> GetTeam(Guid id);
        Task RemoveTeam(Guid id);
        Task UpdateTeam(TeamModel team);
        Task AddTeam(TeamModel team);
    }
}
