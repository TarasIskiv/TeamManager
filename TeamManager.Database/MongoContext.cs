using Microsoft.Extensions.Options;
using MongoDB.Driver;
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
        }
    }
}
