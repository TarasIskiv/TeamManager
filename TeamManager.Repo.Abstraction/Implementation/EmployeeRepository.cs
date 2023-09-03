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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MongoContext _context;
        public EmployeeRepository(MongoContext context)
        {
            _context = context;
        }
        public async Task AddEmployee(EmployeeModel employee)
        {
            await _context.Employees.InsertOneAsync(employee);
        }

        public async Task DeactivateEmployee(string id)
        {
            var filter = Builders<EmployeeModel>.Filter.Where(emp => emp.Id.Equals(id));
            var update = Builders<EmployeeModel>.Update.Set(emp => emp.KeepHistory, true)
                .Set(emp => emp.ActiveTo, DateTime.UtcNow);
            await _context.Employees.UpdateOneAsync(filter, update);
        }

        public async Task<EmployeeModel> GetEmployee(string id)
        {
            var filter = Builders<EmployeeModel>.Filter.Where(employer => employer.Id.Equals(id));
            return await _context.Employees.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<List<EmployeeModel>> GetEmployees(string temaId)
        {
            return (await _context.Employees.Find(employer => employer.Teamid.Equals(temaId)).ToListAsync()) ?? new List<EmployeeModel>();
        }

        public async Task RemoveEmployee(string id)
        {
            var filter = Builders<EmployeeModel>.Filter.Where(employer => employer.Id.Equals(id));
            await _context.Employees.DeleteOneAsync(filter);
        }

        public async Task UpdateEmployee(EmployeeModel employee)
        {
            var filter = Builders<EmployeeModel>.Filter.Where(emp => emp.Id.Equals(employee.Id));
            var update = Builders<EmployeeModel>.Update.Set(emp => emp.Name , employee.Name)
                .Set(emp => emp.Surname, employee.Surname)
                .Set(emp => emp.Teamid, employee.Teamid)
                .Set(emp => emp.Role, employee.Role)
                .Set(emp => emp.Responsibilities, employee.Responsibilities);
            await _context.Employees.UpdateOneAsync(filter, update);
        }
    }
}
