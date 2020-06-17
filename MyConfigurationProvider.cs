using System;
using Microsoft.Extensions.Configuration;

namespace FeatureManagementSandbox
{
  public class MyConfigurationProvider : ConfigurationProvider
  {
    public MyConfigurationSource Source { get; }

    public MyConfigurationProvider(MyConfigurationSource source)
    {
      Source = source;
    }

    public override void Load()
    {
      Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: Configuration loaded.");
      Set(MyFeatureFlags.FeatureA.ToString(), true.ToString());
    }
  }
}