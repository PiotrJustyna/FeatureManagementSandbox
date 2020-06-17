using System;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace FeatureManagementSandbox
{
  public class MyConfigurationProvider : ConfigurationProvider
  {
    private readonly Timer _reloadTimer;
    public MyConfigurationSource Source { get; }
    private bool _value;

    public MyConfigurationProvider(MyConfigurationSource source)
    {
      Source = source;

      _reloadTimer = new Timer((obj) => Load(), null, 3000, 1000);
    }

    public override void Load()
    {
      _value = !_value;
      // Console.WriteLine($"{DateTime.Now.ToString()}: Configuration loaded: {_value}.");
      Set(MyFeatureFlags.FeatureA.ToString(), _value.ToString());
    }
  }
}