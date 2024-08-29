
using EmployeeApi;
using EmployeeAPI;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Unity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MasterContext>(options => 
  options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbContext"))
);

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

var container = UnityConfig.RegisterComponents();
builder.Services.AddSingleton(container);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.Configuration.GetSection("ConnectionStrings").Bind(app.Configuration.GetSection("ConnectionStrings"));
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


internal class ConnectionStrings
{
  public string EmployeeDbContext { get; set; }
}