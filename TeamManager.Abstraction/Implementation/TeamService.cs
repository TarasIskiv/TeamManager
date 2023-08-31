using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Models;
using TeamManager.Logic.Abstraction;
using TeamManager.Repository.Abstraction;

namespace TeamManager.Logic.Implementation
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task AddTeam(TeamModel team)
        {
            await _teamRepository.AddTeam(team);
        }

        public async Task<TeamModel> GetTeam(Guid id)
        {
            return await _teamRepository.GetTeam(id);
        }

        public async Task<List<TeamNameModel>> GetTeamNames()
        {
            return await _teamRepository.GetTeamNames();
        }

        public async Task RemoveTeam(Guid id)
        {
            await _teamRepository.RemoveTeam(id);
        }

        public async Task UpdateTeam(TeamModel team)
        {
            await _teamRepository.UpdateTeam(team);
        }
    }
}
