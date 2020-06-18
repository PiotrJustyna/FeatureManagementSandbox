using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace FeatureManagementSandbox.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class HelloWorldController : ControllerBase
  {
    private readonly IFeatureManager _featureManager;
    private readonly IFeatureManagerSnapshot _featureManagerSnapshot;

    public HelloWorldController(
          IFeatureManager featureManager,
          IFeatureManagerSnapshot featureManagerSnapshot)
    {
      _featureManager = featureManager;
      _featureManagerSnapshot = featureManagerSnapshot;
    }

    [HttpGet]
    public async Task<string> Get()
    {
      bool featureA = await _featureManagerSnapshot.IsEnabledAsync(nameof(MyFeatureFlags.FeatureA));

      return $"FeatureA: {featureA}.";
    }
  }
}
