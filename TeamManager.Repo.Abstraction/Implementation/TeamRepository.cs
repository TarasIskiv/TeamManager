using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Models;
using TeamManager.Repository.Abstraction;

namespace TeamManager.Repository.Implementation
{
    public class TeamRepository : ITeamRepository
    {
        public TeamRepository()
        {

        }
        public Task AddTeam(TeamModel team)
        {
            throw new NotImplementedException();
        }

        public Task<TeamModel> GetTeam(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeamNameModel>> GetTeamNames()
        {
            throw new NotImplementedException();
        }

        public Task RemoveTeam(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeam(TeamModel team)
        {
            throw new NotImplementedException();
        }
    }
}
