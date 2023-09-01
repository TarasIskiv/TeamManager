using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Core.Models;

namespace TeamManager.Client.Logic.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService()
        {

        }

        public Task AddEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> GetEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeModel>> GetEmployees(string temaId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveEmployee(string id, bool keepInHistory)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
