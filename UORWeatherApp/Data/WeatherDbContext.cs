using Microsoft.EntityFrameworkCore;
using UORWeatherApp.Models;

namespace UORWeatherApp.Data;

public class WeatherDbContext : DbContext
{
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WeatherForecast>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.TemperatureC).IsRequired();
            entity.Property(e => e.Summary).HasMaxLength(50);

            entity.HasData(
                new WeatherForecast { Id = 1, Date = new DateOnly(2024, 1, 1), TemperatureC = 15, Summary = "Mild" },
                new WeatherForecast { Id = 2, Date = new DateOnly(2024, 1, 2), TemperatureC = 22, Summary = "Warm" },
                new WeatherForecast { Id = 3, Date = new DateOnly(2024, 1, 3), TemperatureC = -5, Summary = "Freezing" },
                new WeatherForecast { Id = 4, Date = new DateOnly(2024, 1, 4), TemperatureC = 10, Summary = "Cool" },
                new WeatherForecast { Id = 5, Date = new DateOnly(2024, 1, 5), TemperatureC = 28, Summary = "Hot" },
                new WeatherForecast { Id = 6, Date = new DateOnly(2024, 1, 6), TemperatureC = 18, Summary = "Pleasant" },
                new WeatherForecast { Id = 7, Date = new DateOnly(2024, 1, 7), TemperatureC = 0, Summary = "Chilly" }
            );
        });
    }
}
