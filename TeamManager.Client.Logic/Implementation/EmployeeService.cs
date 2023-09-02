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
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _client;
        public EmployeeService(HttpClient client)
        {
            _client = client;
        }

        public async Task AddEmployee(EmployeeModel employee)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/Employee/AddEmployee");
            request.Content = JsonContent.Create(employee);
            await _client.SendAsync(request);
        }

        public async Task<EmployeeModel> GetEmployee(string id)
        {
            return await _client.GetFromJsonAsync<EmployeeModel>($"api/Employee/GetEmployee?id={id}") ?? new EmployeeModel();
        }

        public async Task<List<EmployeeModel>> GetEmployees(string temaId)
        {
            return await _client.GetFromJsonAsync<List<EmployeeModel>>("api/Employee/GetEmployees") ?? new List<EmployeeModel>();
        }

        public async Task RemoveEmployee(string id, bool keepInHistory)
        {
            await _client.DeleteAsync($"api/Employee/RemoveEmployee?id={id}&keepInHistory={keepInHistory}");
        }

        public async Task UpdateEmployee(EmployeeModel employee)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "api/Employee/UpdateEmployee");
            request.Content = JsonContent.Create(employee);
            await _client.SendAsync(request);
        }
    }
}
