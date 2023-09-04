using Microsoft.AspNetCore.Components;
using MudBlazor;
using TeamManager.Core.Models;

namespace TeamManager.Client.Shared.Components
{
    partial class EmployeeDetailsComponent
    {
       
        [Parameter] public EmployeeModel Employee {get; set;} 
        [Parameter] public TeamModel Team {get; set;} 
        [Parameter] public EventCallback<EmployeeModel> EmployeeForUpdate {get; set;}
        [Parameter] public EventCallback<EmployeeModel> EmployeeForRemove {get; set;}
        public string GetTeam() 
        {
            return Team.Name ?? "";
        }
        public string GetActivityPeriod()
        {
            if(Employee is null) return "";
            return Employee.ActiveTo is null ? 
                    String.Concat(Employee.ActiveFrom.ToString("dd'/'MM'/'yyyy"), " - ", "Now") :
                    String.Concat(Employee.ActiveFrom.ToString("dd'/'MM'/'yyyy"), " - ", Employee.ActiveTo.Value.ToString("dd'/'MM'/'yyyy"));
        }

        public async Task UpdateEmployee()
        {
            await EmployeeForUpdate.InvokeAsync(Employee);
        }   

        public async Task DeleteEmployee()
        {
            await EmployeeForRemove.InvokeAsync(Employee);
        }   
        
    }
}
