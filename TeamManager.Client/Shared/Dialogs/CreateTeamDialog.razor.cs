using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using TeamManager.Core.Models;

namespace TeamManager.Client.Shared.Dialogs
{
    partial class CreateTeamDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public TeamModel NewTeam = new TeamModel();
        private EditContext _context;

        protected override void OnInitialized()
        {
            _context = new EditContext(NewTeam);
        }
        public async Task Close()
        {
            MudDialog.Cancel();
        }

        public async Task Save()
        {
            if (!_context.Validate()) return;
            MudDialog.Close(DialogResult.Ok(NewTeam));
        }
    }
}
