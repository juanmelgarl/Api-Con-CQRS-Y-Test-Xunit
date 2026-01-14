using ApiGestion.Models;
using ApiGestion.Repository;
using ApiGestion.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();            

builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaContext")));
builder.Services.AddScoped<IdueñoRepository,DueñoREpository>();
builder.Services.AddScoped<IDueñoQueryService, DueñoQuerySerivce>();
builder.Services.AddScoped<IDueñoCommand, DueñoCommandServicec>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();   
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
