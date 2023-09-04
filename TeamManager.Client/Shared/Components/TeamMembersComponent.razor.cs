using Microsoft.AspNetCore.Components;
using MudBlazor;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Client.Shared.Dialogs;
using TeamManager.Core.Models;

namespace TeamManager.Client.Shared.Components
{
    partial class TeamMembersComponent
    {
        [Parameter] public List<EmployeeModel> Members { get; set; } = new();
        [Inject] IDialogService Dialog { get; set; }
        [Inject] IEmployeeService EmployeeService { get; set; }
        [Inject] NavigationManager NavManager { get; set; }
        [Parameter] public EventCallback Refresh {get; set;}
        [Parameter] public EventCallback<EmployeeModel> EmployeeForUpdate { get; set;}
        public async Task DeleteEmployee(EmployeeModel selectedEmployee)
        {
            var options = new DialogOptions
            {
                CloseOnEscapeKey = true,
                Position = DialogPosition.Center,
                DisableBackdropClick = true,
                NoHeader = true
            };

            var parameters = new DialogParameters<SubmitRemoveDialog> { { x => x.IsEmployee, true }, { x => x.ObjectName, String.Concat(selectedEmployee.Name," ", selectedEmployee.Surname) } };

            var dialog = Dialog.Show<SubmitRemoveDialog>("Remove Employee", parameters, options);
            var result = await dialog.Result;
            if (result.Canceled) return;

            bool keepInHistory;
            Boolean.TryParse(result.Data.ToString(), out keepInHistory);
            await EmployeeService.RemoveEmployee(selectedEmployee.Id, keepInHistory);
            await Refresh.InvokeAsync();
        }

        public async Task EditEmployee(EmployeeModel selectedEmployee)
        {
            await EmployeeForUpdate.InvokeAsync(selectedEmployee);
        }
        public bool IsEmployeeDeleted(EmployeeModel employee)
        {
            return employee.ActiveTo is not null;
        }

        public void MemberDetails(string Id)
        {
            NavManager.NavigateTo($"/employee/{Id}");
        }
    }
}
