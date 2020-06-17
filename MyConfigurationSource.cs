using Microsoft.Extensions.Configuration;

namespace FeatureManagementSandbox
{
  public class MyConfigurationSource : IConfigurationSource
  {
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
      return new MyConfigurationProvider(this);
    }
  }
}