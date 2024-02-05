using GamblingBackDW;
using GamblingBackDW.Application.Services.AdminGambling;
using GamblingBackDW.Application.Services.Interfaces.AdminGambling;
using GamblingBackDW.Automapper;
using GamblingBackDW.Validators;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using GamblingBackDW.SocketSignalR;
using GamblingBackDW.Domain.Services.AdminGambling;
using GamblingBackDW.Application.Services.Interfaces.SessionGambling;
using GamblingBackDW.Application.Services.SessionGambling;
using GamblingBackDW.Domain.Services.SessionGambling;
using GamblingBackDW.Domain.Services.Interfaces.SessionGambling;
using GamblingBackDW.Domain.Services.Interfaces.AdminGambling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Ruta al archivo XML de documentación
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Incluir el archivo XML de documentación en Swagger
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});
builder.Services.AddAutoMapper(typeof(GlobalMapper));
builder.Services.AddDbContext<DbContextGamblingDW>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConeccionSQL")));

builder.Services.AddScoped<IAdminGamblingServices, AdminGamblingServices>();
builder.Services.AddScoped<IAdminGamblingDomain, AdminGamblingDomain>();

builder.Services.AddScoped<ISessionGamblingServices, SessionGamblingServices>();
builder.Services.AddScoped<ISessionGamblingDomain, SessionGamblingDomain>();

//builder.Services.AddScoped<IManangementTravelAppServices, ManangementTravelAppServices>();
//builder.Services.AddScoped<IManangementTravelDomainServices, ManangementTravelDomainServices>();

builder.Services.AddTransient<GlobalValidator>();
builder.Services.AddTransient<SocketMessage>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");

app.MapHub<SocketMessage>("/socketMessage");

app.Run();
