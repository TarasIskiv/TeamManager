using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Models;
using TeamManager.Logic.Abstraction;
using TeamManager.Repository.Abstraction;

namespace TeamManager.Logic.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Task AddEmployee(EmployeeModel employee)
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

        public Task RemoveEmployee(Guid id, bool keepInHistory)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
