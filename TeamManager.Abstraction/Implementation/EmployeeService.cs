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
        public async Task AddEmployee(EmployeeModel employee)
        {
            await _employeeRepository.AddEmployee(employee);
        }

        public async Task<EmployeeModel> GetEmployee(Guid id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task<List<EmployeeModel>> GetEmployees(Guid temaId)
        {
            return await _employeeRepository.GetEmployees(temaId);
        }

        public async Task RemoveEmployee(Guid id, bool keepInHistory)
        {
            if(keepInHistory)
            {
                await _employeeRepository.DeactivateEmployee(id);
            }
            else
            {
                await _employeeRepository.RemoveEmployee(id);
            }
        }

        public async Task UpdateEmployee(EmployeeModel employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
        }
    }
}
