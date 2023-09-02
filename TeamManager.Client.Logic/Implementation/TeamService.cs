using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Core.Models;

namespace TeamManager.Client.Logic.Implementation
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient _client;
        public TeamService(HttpClient client)
        {
            _client = client;
        }

        public async Task AddTeam(TeamModel team)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/Team/AddTeam");
            request.Content = JsonContent.Create(team);
            await _client.SendAsync(request);
        }

        public async Task<TeamModel> GetTeam(string id)
        {
            return await _client.GetFromJsonAsync<TeamModel>($"api/Team/GetTeam?Id={id}") ?? new TeamModel();
        }

        public async Task<List<TeamNameModel>> GetTeamNames()
        {
            return await _client.GetFromJsonAsync<List<TeamNameModel>>("api/Team/GetTeamNames") ?? new List<TeamNameModel>();
        }

        public async Task RemoveTeam(string id)
        {
            await _client.DeleteAsync($"api/Team/RemoveTeam?id={id}");
        }

        public async Task UpdateTeam(TeamModel team)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "api/Team/UpdateTeam");
            request.Content = JsonContent.Create(team);
            await _client.SendAsync(request);
        }
    }
}
