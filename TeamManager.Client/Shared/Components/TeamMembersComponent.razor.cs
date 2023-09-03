using Microsoft.AspNetCore.Components;
using TeamManager.Core.Models;

namespace TeamManager.Client.Shared.Components
{
    partial class TeamMembersComponent
    {
        [Parameter] public List<EmployeeModel> Members { get; set; } = new();
    }
}
