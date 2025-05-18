using Microsoft.EntityFrameworkCore;
using Personal_Reading_Tracker.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure Entity Framework Core to use SQL Server
// This line:
// 1. Registers the ReadingTrackerDbContext in the dependency injection container
// 2. Configures it to use SQL Server as the database provider
// 3. Gets the connection string named "SqlServerConnection" from appsettings.json
builder.Services.AddDbContext<ReadingTrackerContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
