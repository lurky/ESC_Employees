using MudBlazor.Services;
using EmployeeUI_Blazor.Components;
using EmployeeData;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using EmployeeData.Contracts;
using EmployeeData.Repos;
using EmployeeUI_Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddHttpClient();
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<MasterContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbContext")));
builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();
var mapper = AutoMapperConfig.Configure();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
