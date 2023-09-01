using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace TeamManager.Client.Shared
{
    partial class MainLayout
    {
        public MudThemeProvider MudThemeProvider { get; set; }
        MudTheme MudTheme { get; set; }
        private bool _isDarkMode;
        public MainLayout()
        {

        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                ConfigureCustomPalette();
                _isDarkMode = await MudThemeProvider.GetSystemPreference();
                StateHasChanged();
            }
        }
        public void ChangeTheme()
        {
            _isDarkMode = !_isDarkMode;
        }
        public void ConfigureCustomPalette()
        {
            MudTheme = new MudTheme()
            {
                Palette = new PaletteLight()
                {
                    Primary = Colors.Blue.Darken4,
                    Secondary = Colors.Blue.Darken1
                },
                PaletteDark = new PaletteDark()
                {
                    Primary = Colors.Blue.Lighten3,
                    Secondary = Colors.Blue.Lighten1
                }
            };
        }

    }
}
