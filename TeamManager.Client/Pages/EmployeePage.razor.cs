using Microsoft.AspNetCore.Components;
using MudBlazor;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Client.Shared.Dialogs;
using TeamManager.Core.Models;

namespace TeamManager.Client.Pages
{
    partial class EmployeePage
    {
        [Parameter] public string Id { get; set; } = default!;
        [Inject] public IEmployeeService EmployeeService{ get; set; } = default!;
        [Inject] public ITeamService TeamService {get; set; } = default!;
        [Inject] public NavigationManager NavManager {get; set;}
        [Inject] IDialogService Dialog { get; set; }
        public EmployeeModel Employee {get; set;} = new();
        public TeamModel Team {get; set;} = new();
        protected override async Task OnInitializedAsync()
        {
           await LoadDetails();
        }

        public async Task LoadDetails()
        {
            Employee = await EmployeeService.GetEmployee(Id);
            Team = await TeamService.GetTeam(Employee.Teamid);
        }

        public async Task UpdateEmployee(EmployeeModel employeeForUpdate)
        {
            var options = new DialogOptions
            {
                CloseOnEscapeKey = true,
                Position = DialogPosition.Center,
                DisableBackdropClick = true
            };
            var teams = await TeamService.GetTeamNames();
            var parameters = new DialogParameters<AddUpdateEmployeeDialog> {{ x => x.IsNew, false}, {x => x.Employee, employeeForUpdate}, { x => x.TeamId, Id}, { x => x.AvailableTeams, teams } };
           
            var dialog = Dialog.Show<AddUpdateEmployeeDialog>("Add Employee", parameters, options);
            var result = await dialog.Result;
            if (result.Canceled) return;

            var employee = result.Data as EmployeeModel;
            await EmployeeService.UpdateEmployee(employee!);
            await LoadDetails();
            await InvokeAsync(StateHasChanged);
        }

        public void MoveBack()
        {
            NavManager.NavigateTo($"/team/{Team.Id}");
        }

        public async Task RemoveEmployee(EmployeeModel selectedEmployee)
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
            MoveBack();
        }
    }
}
