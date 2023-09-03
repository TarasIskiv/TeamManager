using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace TeamManager.Client.Shared.Dialogs
{
    partial class SubmitRemoveDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEmployee { get; set; } = false;
        [Parameter] public string ObjectName { get; set; } = string.Empty;
        public bool KeepInHistory { get; set; } = false;

        public string GetMessage()
        {
            return IsEmployee ? $"You gonna remove {ObjectName}" : $"You gonna remove {ObjectName} team";
        }

        public void Close()
        {
            MudDialog.Cancel();
        }

        public void Remove()
        {
            if(IsEmployee)
            {
                MudDialog.Close(DialogResult.Ok(KeepInHistory));
            }
            else
            {
                MudDialog.Close(DialogResult.Ok(new Object()));
            }
        }
    }
}
