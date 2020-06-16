using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

namespace FeatureManagementSandbox.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IFeatureManager _featureManager;

    public WeatherForecastController(
          ILogger<WeatherForecastController> logger,
          IFeatureManager featureManager)
    {
      _logger = logger;
      _featureManager = featureManager;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
      bool flagAOn = false;

      if (await _featureManager.IsEnabledAsync(nameof(MyFeatureFlags.FeatureA)))
      {
        flagAOn = true;
      }

      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = flagAOn ? DateTime.MinValue : DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }
  }
}
