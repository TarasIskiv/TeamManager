using Microsoft.AspNetCore.Components;
using MudBlazor;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Client.Shared.Dialogs;
using TeamManager.Core.Models;

namespace TeamManager.Client.Pages
{
    partial class TeamPage
    {
        [Parameter] public string Id { get; set; }
        [Inject] public ITeamService TeamService { get; set; }
        [Inject] public IEmployeeService EmployeeService { get; set; }
        [Inject] IDialogService Dialog { get; set; }
        [Inject] NavigationManager NavManager { get; set; }
        public TeamModel Team { get; set; } = new();
        public List<EmployeeModel> Employees { get; set; } = new();
        public int TeamMembersCount { get; set; } = 0;
        public bool UsersExpanded { get; set; } = false;
        public TeamPage()
        {

        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id == null) return;
            await LoadTeamDetails();
        }

        public async Task LoadTeamDetails()
        {
            Team = await TeamService.GetTeam(Id);
            Employees = await EmployeeService.GetEmployees(Id);
            TeamMembersCount = Employees.Count();
        }

        public void ExpandCollapse()
        {
            UsersExpanded = !UsersExpanded;
        }

        public async Task AddNewEmployee()
        {
            var options = new DialogOptions
            {
                CloseOnEscapeKey = true,
                Position = DialogPosition.Center,
                DisableBackdropClick = true
            };
            var teams = await TeamService.GetTeamNames();
            var parameters = new DialogParameters<AddUpdateEmployeeDialog> {{ x => x.IsNew, true}, { x => x.TeamId, Id}, { x => x.AvailableTeams, teams } };
           
            var dialog = Dialog.Show<AddUpdateEmployeeDialog>("Add Employee", parameters, options);
            var result = await dialog.Result;
            if (result.Canceled) return;

            var employee = result.Data as EmployeeModel;
            employee.ActiveFrom = DateTime.UtcNow;
            await EmployeeService.AddEmployee(employee!);
            await LoadTeamDetails();
            await InvokeAsync(StateHasChanged);
        }

        public async Task DeleteTeam()
        {
            var options = new DialogOptions
            {
                CloseOnEscapeKey = true,
                Position = DialogPosition.Center,
                DisableBackdropClick = true,
                NoHeader = true
            };

            var parameters = new DialogParameters<SubmitRemoveDialog> { { x => x.IsEmployee, false }, { x => x.ObjectName, Team.Name } };

            var dialog = Dialog.Show<SubmitRemoveDialog>("Remove Team", parameters, options);
            var result = await dialog.Result;
            if (result.Canceled) return;

            await TeamService.RemoveTeam(Id);
            NavManager.NavigateTo("/");
        }

        public async Task UpdateTeam()
        {
            var options = new DialogOptions
            {
                CloseOnEscapeKey = true,
                Position = DialogPosition.Center,
                DisableBackdropClick = true
            };

            var parameters = new DialogParameters<AddUpdateTeamDialog> { { x => x.IsNew, false }, { x => x.Team, Team} };

            var dialog = Dialog.Show<AddUpdateTeamDialog>("Update Team", parameters, options);
            var result = await dialog.Result;
            if (result.Canceled) return;

            var newTeam = result.Data as TeamModel;
            await TeamService.UpdateTeam(newTeam!);
            await LoadTeamDetails();
            await InvokeAsync(StateHasChanged);
        }
    }
}
