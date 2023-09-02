using Microsoft.AspNetCore.Components;
using TeamManager.Core.Models;

namespace TeamManager.Client.Shared.Components
{
    partial class TeamDetailsComponent
    {
        [Parameter] public TeamModel Team { get; set; }
        [Parameter] public int TeamMembers { get; set; }
    }
}
