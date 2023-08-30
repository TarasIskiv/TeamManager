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
        public Task AddEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public Task DeactivateEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> GetEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeModel>> GetEmployees(Guid temaId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
