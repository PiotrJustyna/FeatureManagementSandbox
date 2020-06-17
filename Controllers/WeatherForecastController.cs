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
    private readonly IFeatureManagerSnapshot _featureManagerSnapshot;

    public WeatherForecastController(
          ILogger<WeatherForecastController> logger,
          IFeatureManager featureManager,
          IFeatureManagerSnapshot featureManagerSnapshot)
    {
      _logger = logger;
      _featureManager = featureManager;
      _featureManagerSnapshot = featureManagerSnapshot;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
      bool flagAOn1 = await _featureManagerSnapshot.IsEnabledAsync(nameof(MyFeatureFlags.FeatureA));

      await Task.Delay(99);

      bool flagAOn2 = await _featureManagerSnapshot.IsEnabledAsync(nameof(MyFeatureFlags.FeatureA));

      await Task.Delay(99);

      bool flagAOn3 = await _featureManagerSnapshot.IsEnabledAsync(nameof(MyFeatureFlags.FeatureA));

      await Task.Delay(99);

      bool flagAOn4 = await _featureManagerSnapshot.IsEnabledAsync(nameof(MyFeatureFlags.FeatureA));


      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)],
        PiotrMessage = $"{MyFeatureFlags.FeatureA}: {flagAOn1}/{flagAOn2}/{flagAOn3}/{flagAOn4}."
      })
      .ToArray();
    }
  }
}
