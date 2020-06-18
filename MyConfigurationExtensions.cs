using Microsoft.Extensions.Configuration;

namespace FeatureManagementSandbox
{
  public static class FeatureManagementSandboxConfigurationExtensions
  {
    public static IConfigurationBuilder AddFeatureFlagsConfiguration(this IConfigurationBuilder configuration)
    {
      configuration.Add(new FeatureFlagsConfigurationSource());
      return configuration;
    }
  }
}