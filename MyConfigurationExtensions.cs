using Microsoft.Extensions.Configuration;

namespace FeatureManagementSandbox
{
  public static class MyConfigurationExtensions
  {
    public static IConfigurationBuilder AddMyConfiguration(this IConfigurationBuilder configuration)
    {
      configuration.Add(new MyConfigurationSource());
      return configuration;
    }
  }
}