using Microsoft.Extensions.Configuration;

namespace FeatureManagementSandbox
{
  public class FeatureFlagsConfigurationSource : IConfigurationSource
  {
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
      return new DummyFeatureFlagsProvider();
    }
  }
}