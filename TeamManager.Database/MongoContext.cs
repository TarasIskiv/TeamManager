using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Models;

namespace TeamManager.Database
{
    public class MongoContext
    {
        public IMongoCollection<TeamModel> Teams  { get; private set; }
        public IMongoCollection<EmployeeModel> Employees { get; private set; }
        private const string _teamCollectionName = "Teams";
        private const string _employeeCollectionName = "Employees";
        public MongoContext(IOptions<MongoSettings> settings)
        {
            MongoClient client = new MongoClient(settings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
            Teams = database.GetCollection<TeamModel>(_teamCollectionName);
            Employees = database.GetCollection<EmployeeModel>(_employeeCollectionName);
            Initialize();
        }

        private List<T>? GetDataFromFile<T>(string fileName) where T : class
        {
            var data = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(fileName));
            return data;
        }

        private void WriteData(List<TeamModel> teams, List<EmployeeModel> employees)
        {
            Teams.InsertMany(teams);
            Employees.InsertMany(employees);
        } 

        private void Initialize()
        {
            if(Teams.Count(new BsonDocument()) != 0) return; 
            var teams = GetDataFromFile<TeamModel>("../TeamManager.Database/TeamManager.Teams.json");
            var employees = GetDataFromFile<EmployeeModel>("../TeamManager.Database/TeamManager.Employees.json");
            if(teams is null) return;
            WriteData(teams, employees ?? new List<EmployeeModel>());
        }
    }
}
