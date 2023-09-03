using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;
using TeamManager.Core.Models;

namespace TeamManager.Client.Shared.Dialogs
{
    partial class AddUpdateTeamDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [AllowNull][Parameter] public TeamModel Team { get; set; }
        [Parameter] public bool IsNew { get; set; } = false;
        private EditContext _context;

        protected override void OnInitialized()
        {
            if(IsNew)
            {
                Team = new TeamModel();
            }
            _context = new EditContext(Team);
        }
        public async Task Close()
        {
            MudDialog.Cancel();
        }

        public async Task Save()
        {
            if (!_context.Validate()) return;
            MudDialog.Close(DialogResult.Ok(Team));
        }
    }
}
