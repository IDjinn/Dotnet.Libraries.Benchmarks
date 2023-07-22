using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks.ActivatorUtilitiesPerformance;

public interface IActivatorUtilitiesObjectFactory : IObjectFactory
{
}

public class ActivatorUtilitiesObjectFactory : IActivatorUtilitiesObjectFactory
{
    private readonly IServiceProvider _provider;

    public ActivatorUtilitiesObjectFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public TheObject CreateObject(string name, int age, string[] tags)
    {
        return ActivatorUtilities.CreateInstance<TheObject>(_provider, name, age, tags);
    }
}