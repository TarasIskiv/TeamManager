using Microsoft.AspNetCore.Components;
using MudBlazor;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Client.Shared.Dialogs;
using TeamManager.Core.Models;
namespace TeamManager.Client.Shared
{
    partial class NavMenu
    {
        [Inject] ITeamService TeamService { get; set; }
        [Inject] NavigationManager NavManager { get; set; } 
        [Inject] IDialogService Dialog { get; set; }
        public List<TeamNameModel> TeamNames { get; set; } = new();
        private TeamNameModel SelectedTeam { get; set; }
        public NavMenu()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await LoadTeamNames();
        }

        public async Task LoadTeamNames()
        {
            TeamNames = await TeamService.GetTeamNames();
        }

        public void NavigateToTeam(string Id)
        {
            SelectedTeam = TeamNames.SingleOrDefault(team => team.Id.Equals(Id))!;
            NavManager.NavigateTo($"/team/{Id}");
        }

        public async Task AddTeam()
        {
            var options = new DialogOptions 
            { 
                CloseOnEscapeKey = true, 
                Position = DialogPosition.Center,
                DisableBackdropClick=true
            };

            var parameters = new DialogParameters<AddUpdateTeamDialog> { { x => x.IsNew, true }};

            var dialog = Dialog.Show<AddUpdateTeamDialog>("Create Team", parameters, options);
            var result = await dialog.Result;
            if (result.Canceled) return;

            var newTeam = result.Data as TeamModel;
            await TeamService.AddTeam(newTeam!);
            await LoadTeamNames();
            await InvokeAsync(StateHasChanged);
        }
    }
}
