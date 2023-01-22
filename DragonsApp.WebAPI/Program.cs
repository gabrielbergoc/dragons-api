using System.Text.Json.Serialization;
using DragonsApp.Database;
using DragonsApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// get configs

var connectionString = builder.Configuration.GetConnectionString("dragons");

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// app services
builder.Services
    .AddScoped<IDragonRepository, DragonRepository>();
builder.Services
    .AddDbContext<DragonsDbContext>();

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

app.UseCors(
    options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
);

app.Run();
