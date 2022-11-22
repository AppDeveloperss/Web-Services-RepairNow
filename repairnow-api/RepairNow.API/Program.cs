using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RepairNow.Domain;
using RepairNow.Domain.Test;
using RepairNow.Infraestructure;
using RepairNow.Infraestructure.Context;
using RepairNowAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Inyeccion de Dependencias
//Primero se hace esto para comenzar con la inyeccion, le paso la interfaz y por el otro la clase
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<IAppliancesDomain, AppliancesDomain>();
builder.Services.AddScoped<IAppliancesRepository, AppliancesRepository>();

builder.Services.AddScoped<IAppointmentsDomain, AppointmentsDomain>();
builder.Services.AddScoped<IAppointmentsRepository,AppointmentsRepository>();

builder.Services.AddScoped<IReportsDomain, ReportsDomain>();
builder.Services.AddScoped<IReportsRepository, ReportsRepository>();

builder.Services.AddScoped<ITokenDomain,TokenDomain>();

//luego te vas a user controller y ese recibe el dominio, luego te vas al dominio y haces lo mismo pero con la infraestructura


//Leer cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("RepairNowConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));


//Conexion a Base De datos

builder.Services.AddDbContext<RepairNowDB>(dbContextOptions =>
{
    dbContextOptions.UseMySql(connectionString, serverVersion);
});


builder.Services.AddAutoMapper(
    typeof(RepairNowAPI.Mapper.ModelToResource),
    typeof(RepairNowAPI.Mapper.ResourceToModel)
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});


var app = builder.Build();

//Valido si la base de datos ha sido creada, si no lo ha sido, la crea
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<RepairNowDB>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();