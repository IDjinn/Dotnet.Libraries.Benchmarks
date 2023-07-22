using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks.ActivatorUtilitiesPerformance;

public class ObjectFactory : IObjectFactory
{
    private readonly IServiceProvider _provider;

    public ObjectFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public TheObject CreateObject(string name, int age, string[] tags)
    {
        return ActivatorUtilities.CreateInstance<TheObject>(_provider,name, age, tags);
    }
}