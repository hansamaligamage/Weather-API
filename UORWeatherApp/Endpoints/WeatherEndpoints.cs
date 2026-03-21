using Microsoft.EntityFrameworkCore;
using UORWeatherApp.Data;

namespace UORWeatherApp.Endpoints;

public static class WeatherEndpoints
{
    public static void MapWeatherEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", async (WeatherDbContext db) =>
        {
            var forecast = await db.WeatherForecasts.ToListAsync();
            return forecast;
        })
        .WithName("GetWeatherForecast");
    }
}
