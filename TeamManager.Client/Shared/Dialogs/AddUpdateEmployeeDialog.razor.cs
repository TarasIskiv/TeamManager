using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;
using TeamManager.Core.Models;

namespace TeamManager.Client.Shared.Dialogs
{
    partial class AddUpdateEmployeeDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter, AllowNull] public EmployeeModel Employee { get; set; }
        [Parameter] public bool IsNew { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        private EditContext _employeeContext;
        public string CurrentResponsibility { get; set; } = string.Empty;
        private static string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full z-10";
        private string DragClass = DefaultDragClass;
        private string fileName = string.Empty;

        private void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            ClearDragClass();
            var file = e.File;
            fileName = file.Name;
        }

        private async Task Clear()
        {
            fileName = string.Empty;
            ClearDragClass();
            await Task.Delay(100);
        }
        private void Upload()
        {
            //Upload the files here
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Add("TODO: Upload your files!", Severity.Normal);
        }

        private void SetDragClass()
        {
            DragClass = $"{DefaultDragClass} mud-border-primary";
        }

        private void ClearDragClass()
        {
            DragClass = DefaultDragClass;
        }

        protected override void OnInitialized()
        {
            if (Employee is null) Employee = new EmployeeModel();
            _employeeContext = new EditContext(Employee);
        }

        public void AddResponsibility()
        {
            if (Employee.Responsibilities.Contains(CurrentResponsibility))
            {
                CurrentResponsibility = string.Empty;
                return;
            }
            Employee.Responsibilities.Add(CurrentResponsibility);
            CurrentResponsibility = string.Empty;
        }

        public void CloseChip(MudChip chip)
        {
            var a = chip;
            // react to chip closed
        }

        public void Close()
        {
            MudDialog.Cancel();
        }

        public void Save()
        {
            MudDialog.Close(DialogResult.Ok(Employee)); 
        }
    }
}
