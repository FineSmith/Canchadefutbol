var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();

// Middleware
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        mensaje = "API Cancha de Fútbol funcionando",
        version = "1.0",
        endpoints = new
        {
            horarios = "/api/horarios",
            servicios = "/api/servicios",
            canchas = "/api/canchas",
            openapi = "/openapi/v1.json"
        }
    });
});

app.MapGet("/api/horarios", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            id = 1,
            fecha = "2026-10-05",
            hora = "08:00",
            estado = "Disponible",
            tipoCancha = "Fútbol 7",
            precio = 80.00,
            duracion = "1 hora"
        },
        new
        {
            id = 2,
            fecha = "2026-10-05",
            hora = "10:00",
            estado = "Reservado",
            tipoCancha = "Fútbol 7",
            precio = 80.00,
            duracion = "1 hora"
        },
        new
        {
            id = 3,
            fecha = "2026-10-05",
            hora = "12:00",
            estado = "Disponible",
            tipoCancha = "Fútbol 7",
            precio = 90.00,
            duracion = "1 hora"
        },
        new
        {
            id = 4,
            fecha = "2026-10-05",
            hora = "14:00",
            estado = "Disponible",
            tipoCancha = "Fútbol 11",
            precio = 150.00,
            duracion = "1 hora"
        },
        new
        {
            id = 5,
            fecha = "2026-10-05",
            hora = "16:00",
            estado = "Reservado",
            tipoCancha = "Fútbol 11",
            precio = 150.00,
            duracion = "1 hora"
        },
        new
        {
            id = 6,
            fecha = "2026-10-05",
            hora = "18:00",
            estado = "Disponible",
            tipoCancha = "Fútbol 7",
            precio = 100.00,
            duracion = "1 hora"
        },
        new
        {
            id = 7,
            fecha = "2026-10-06",
            hora = "08:00",
            estado = "Disponible",
            tipoCancha = "Fútbol 7",
            precio = 80.00,
            duracion = "1 hora"
        },
        new
        {
            id = 8,
            fecha = "2026-10-06",
            hora = "10:00",
            estado = "Reservado",
            tipoCancha = "Fútbol 11",
            precio = 150.00,
            duracion = "1 hora"
        },
        new
        {
            id = 9,
            fecha = "2026-10-06",
            hora = "14:00",
            estado = "Disponible",
            tipoCancha = "Fútbol 7",
            precio = 90.00,
            duracion = "1 hora"
        },
        new
        {
            id = 10,
            fecha = "2026-10-06",
            hora = "20:00",
            estado = "Disponible",
            tipoCancha = "Fútbol 11",
            precio = 170.00,
            duracion = "1 hora"
        }
    });
});

app.MapGet("/api/servicios", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            id = 1,
            nombre = "Alquiler de cancha",
            descripcion = "Alquiler de cancha para partidos de fútbol",
            precio = 80.00
        },
        new
        {
            id = 2,
            nombre = "Iluminación",
            descripcion = "Servicio de iluminación para partidos nocturnos",
            precio = 20.00
        },
        new
        {
            id = 3,
            nombre = "Vestuarios",
            descripcion = "Uso de vestuarios para los jugadores",
            precio = 15.00
        },
        new
        {
            id = 4,
            nombre = "Estacionamiento",
            descripcion = "Espacio de estacionamiento para clientes",
            precio = 10.00
        },
        new
        {
            id = 5,
            nombre = "Entrenamiento",
            descripcion = "Espacio para entrenamientos deportivos",
            precio = 100.00
        }
    });
});

app.MapGet("/api/canchas", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            id = 1,
            nombre = "Cancha 1",
            tipo = "Fútbol 7",
            capacidad = 14,
            estado = "Disponible",
            precioHora = 80.00
        },
        new
        {
            id = 2,
            nombre = "Cancha 2",
            tipo = "Fútbol 7",
            capacidad = 14,
            estado = "Disponible",
            precioHora = 90.00
        },
        new
        {
            id = 3,
            nombre = "Cancha 3",
            tipo = "Fútbol 11",
            capacidad = 22,
            estado = "Disponible",
            precioHora = 150.00
        },
        new
        {
            id = 4,
            nombre = "Cancha 4",
            tipo = "Fútbol 11",
            capacidad = 22,
            estado = "Mantenimiento",
            precioHora = 150.00
        }
    });
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "5206";
var host = app.Environment.IsProduction() ? "0.0.0.0" : "localhost";

app.Run($"http://{host}:{port}");