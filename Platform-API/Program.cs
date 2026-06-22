var builder = WebApplication.CreateBuilder(args);

// [ORIGINAL]: Esto ya venía en tu plantilla de .NET 10. Se encarga de generar el JSON de tu API.
builder.Services.AddOpenApi();

// [MODIFICADO]: ¡AGREGADO POR TI! 
// Esta línea es obligatoria para que el explorador de endpoints de .NET le pase la información a Swagger.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // [ORIGINAL]: Esto ya venía. Expone el mapa de tu API en la ruta: /openapi/v1.json
    app.MapOpenApi(); 
    
    // [MODIFICADO]: ¡AGREGADO POR TI!
    // Activamos la interfaz gráfica azul de Swagger y la configuramos para que lea el JSON nativo de .NET 10.
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1"); // Le dice a Swagger de dónde sacar la lista de endpoints
        options.RoutePrefix = "swagger";                  // Define que la página se abrirá escribiendo /swagger
    });
}

app.UseHttpsRedirection();

// [ORIGINAL]: Todo lo que sigue hacia abajo es el endpoint de prueba (WeatherForecast) que Microsoft pone por defecto.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}