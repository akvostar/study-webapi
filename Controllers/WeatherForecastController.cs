using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing-", "Bracing-", "Chilly-", "Cool-", "Mild-", "Warm-", "Balmy", "Hot", "Sweltering", "Scorching"
        };
       
        [HttpGet("{id:int?}")]
        public IEnumerable<WeatherForecast> Forecasts(int? id)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ))
            .ToArray();
        }
    }

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}