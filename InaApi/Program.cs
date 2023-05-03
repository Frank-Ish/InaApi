using Data;
using Entities;
using InaApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services;



//var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Add services to the container.
// Servicio de inyeccion de dependencias.
builder.Services.addServices();


//
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<DbProyectoInaContext>(
    options => options.UseSqlServer("dbINA"));
//builder.Configuration.GetConnectionString("dbINA") ?? throw new InvalidOperationException()));




//Automapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


