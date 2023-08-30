﻿using System;
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
