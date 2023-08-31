using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Models;
using TeamManager.Database;
using TeamManager.Repository.Abstraction;

namespace TeamManager.Repository.Implementation
{
    public class TeamRepository : ITeamRepository
    {
        private readonly MongoContext _context;

        public TeamRepository(MongoContext context)
        {
            _context = context;
        }
        public async Task AddTeam(TeamModel team)
        {
            await _context.Teams.InsertOneAsync(team);
        }

        public async Task<TeamModel> GetTeam(string id)
        {
            return await _context.Teams.Find(team => team.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task<List<TeamNameModel>> GetTeamNames()
        {
            return await _context.Teams.Find(new BsonDocument()).Project(team => new TeamNameModel() { Id = team.Id, Name = team.Name}).ToListAsync();
        }

        public async Task RemoveTeam(string id)
        {
            await _context.Teams.DeleteOneAsync(team => team.Id.Equals(id));
        }

        public async Task UpdateTeam(TeamModel team)
        {
            var filter = Builders<TeamModel>.Filter.Where(mongoTeam => mongoTeam.Id.Equals(team.Id));
            var update = Builders<TeamModel>.Update.Set(mongoTeam => mongoTeam.Name, team.Name).Set(mongoTeam => mongoTeam.Description, team.Description);
            var record = await _context.Teams.FindOneAndUpdateAsync(filter, update);
        }
    }
}
