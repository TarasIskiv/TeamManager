using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TeamManager.Client;
using TeamManager.Client.Logic.Implementation;
using TeamManager.Client.Logic.Abstraction;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Services
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
