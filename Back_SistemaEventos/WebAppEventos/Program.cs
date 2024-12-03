using Eventos.Datos;
using Eventos.Datos.Eventos;
using Eventos.Datos.Paquetes;
using Eventos.Datos.Solicitudes;
using Eventos.Negocio;
using Eventos.Negocio.Eventos;
using Eventos.Negocio.Paquetes;
using Eventos.Negocio.Solicitudes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://127.0.0.1:5500") // Agrega tu origen permitido
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configura la cadena de conexión
builder.Services.AddDbContext<ConexionBD>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias
builder.Services.AddScoped<UsuariosRepository>();
builder.Services.AddScoped<UsuariosService>();
builder.Services.AddScoped<ISolicitudRepository, SolicitudRepository>();
builder.Services.AddScoped<ISolicitudService, SolicitudService>();
builder.Services.AddScoped<IPaqueteRepository, PaqueteRepository>();
builder.Services.AddScoped<IPaqueteService, PaqueteService>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IEventoService, EventoService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usa la política de CORS
app.UseCors("AllowLocalhost");

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
