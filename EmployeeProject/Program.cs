using EmployeeProject.Data;
using EmployeeProject.Mappings;
using EmployeeProject.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper; // Explicitly include AutoMapper namespace to avoid ambiguity

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDbContext>(OPTIONS =>
OPTIONS.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnectionString")));

builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
builder.Services.AddScoped<ISkillRepository, SQLSkillRepository>();
builder.Services.AddScoped<IEmployeeSkillRepository, SQLEmployeeSkillRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
