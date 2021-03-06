using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace FeatureManagementSandbox
{
  public class DummyFeatureFlagsProvider : ConfigurationProvider
  {
    private bool _value = true;
    private const UInt16 _reloadPeriod = 1000;

    public DummyFeatureFlagsProvider()
    {
      ChangeToken.OnChange(
        () =>
        {
          var cancellationTokenSource = new CancellationTokenSource(_reloadPeriod);
          var cancellationChangeToken = new CancellationChangeToken(cancellationTokenSource.Token);
          return cancellationChangeToken;
        },
        Load);
    }

    public override void Load()
    {
      _value = !_value;
      Set(MyFeatureFlags.FeatureA.ToString(), _value.ToString());
      OnReload();
    }
  }
}