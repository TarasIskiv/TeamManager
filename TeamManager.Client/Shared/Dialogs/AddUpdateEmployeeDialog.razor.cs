using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;
using TeamManager.Client.Logic.Abstraction;
using TeamManager.Core.Models;

namespace TeamManager.Client.Shared.Dialogs
{
    partial class AddUpdateEmployeeDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter, AllowNull] public EmployeeModel Employee { get; set; }
        [Parameter] public bool IsNew { get; set; }
        [Parameter] public string TeamId { get; set; } = string.Empty;
        [Parameter] public List<TeamNameModel> AvailableTeams { get; set; } = new();
        [Inject] public ITeamService TeamService { get; set; }
        [Inject] ISnackbar Snackbar { get; set; } 
        private EditContext _employeeContext;
        public bool IsPhotoUploaded { get; set; } = false;
        public string CurrentResponsibility { get; set; } = string.Empty;
        private static string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full z-10";
        private string DragClass = DefaultDragClass;
        private string fileName = string.Empty;

        private async Task OnInputFileChanged(InputFileChangeEventArgs e)
        {
            ClearDragClass();
            var file = e.File;
            Employee.Photo = await ConvertPhoto(file);
            IsPhotoUploaded = true;
        }

        public async Task<string> ConvertPhoto(IBrowserFile file)
        {
            using (var stream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                return "data:image/png;base64," + Convert.ToBase64String(bytes);
            }
        }

        private async Task Clear()
        {
            IsPhotoUploaded = false;
            Employee.Photo = string.Empty;
            ClearDragClass();
            await Task.Delay(100);
        }

        private void SetDragClass()
        {
            DragClass = $"{DefaultDragClass} mud-border-primary";
        }

        private void ClearDragClass()
        {
            DragClass = DefaultDragClass;
        }

        protected override async Task OnInitializedAsync()
        {
            if (Employee is null)
            {
                Employee = new EmployeeModel();
                Employee.Teamid = TeamId;
            }
            IsPhotoUploaded = string.IsNullOrEmpty(Employee.Photo) ? false : true;
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
            Employee.Responsibilities.Remove(chip.Text);
        }

        public void Close()
        {
            MudDialog.Cancel();
        }

        public void Save()
        {
            if (!_employeeContext.Validate()) return;
            MudDialog.Close(DialogResult.Ok(Employee)); 
        }
    }
}
