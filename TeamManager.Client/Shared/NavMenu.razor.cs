using Microsoft.AspNetCore.Components;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Core.Models;
namespace TeamManager.Client.Shared
{
    partial class NavMenu
    {
        [Inject] ITeamService TeamService { get; set; }
        public List<TeamNameModel> TeamNames { get; set; } = new();
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
    }
}
