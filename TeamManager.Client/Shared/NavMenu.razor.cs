using Microsoft.AspNetCore.Components;
using MudBlazor;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Core.Models;
namespace TeamManager.Client.Shared
{
    partial class NavMenu
    {
        [Inject] ITeamService TeamService { get; set; }
        [Inject] NavigationManager NavManager { get; set; } 
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

        public void AddTeam()
        {

        }
    }
}
