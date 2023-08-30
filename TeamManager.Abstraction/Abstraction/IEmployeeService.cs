using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Models;

namespace TeamManager.Logic.Abstraction
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetEmployee(Guid id);
        Task<List<EmployeeModel>> GetEmployees(Guid temaId);
        Task AddEmployee(EmployeeModel employee);
        Task UpdateEmployee(EmployeeModel employee);
        Task RemoveEmployee(Guid id, bool keepInHistory);
    }
}
