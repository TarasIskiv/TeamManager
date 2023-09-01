using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Models;

namespace TeamManager.Client.Logic.Abstraction
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetEmployee(string id);
        Task<List<EmployeeModel>> GetEmployees(string temaId);
        Task AddEmployee(EmployeeModel employee);
        Task UpdateEmployee(EmployeeModel employee);
        Task RemoveEmployee(string id, bool keepInHistory);
    }
}
