using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Core.Models;

namespace TeamManager.Client.Logic.Implementation
{
    public class TeamService : ITeamService
    {
        public TeamService()
        {

        }

        public Task AddTeam(TeamModel team)
        {
            throw new NotImplementedException();
        }

        public Task<TeamModel> GetTeam(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeamNameModel>> GetTeamNames()
        {
            throw new NotImplementedException();
        }

        public Task RemoveTeam(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeam(TeamModel team)
        {
            throw new NotImplementedException();
        }
    }
}
