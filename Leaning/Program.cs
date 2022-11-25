using Microsoft.EntityFrameworkCore;
using WebApplication.Domain;
using WebAppplication.Infraestruture;
using WebAppplication.Infraestruture.Context;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder((args));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteDomian, ClientDomain>();
builder.Services.AddScoped<IClientInfraestructure, ClientInfraestructure>();
//builder.Services.AddSingleton<>
//builder.Services.AddTrasinet<>

//CONEXION MYSQL
var connectionString = builder.Configuration.GetConnectionString("ClientDBConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

builder.Services.AddDbContext<ClientDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    });


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