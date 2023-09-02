using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TeamManager.Client;
using TeamManager.Client.Logic.Implementation;
using TeamManager.Client.Logic.Abstraction;
using MudBlazor.Services;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

//Services
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

await builder.Build().RunAsync();
