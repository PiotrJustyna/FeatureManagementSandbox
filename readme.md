# readme

This repository illustrates how to use:

* [Feature Management](https://www.nuget.org/packages/Microsoft.FeatureManagement)
* with a custom feature flags provider
* that also automatically refreshes itself

## build & run

```bash
dotnet build
dotnet run
```

The code can be ran both locally and in a remote container.

## usage

```bash
curl http://localhost:5000/helloworld
```

The flag refreshes every second, so repeated runs of the command above will give different results.