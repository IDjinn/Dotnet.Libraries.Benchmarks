namespace Benchmarks.ActivatorUtilitiesPerformance;

public interface IRawCreateObjectFactory : IObjectFactory
{
}

public class RawCreateCreateObjectFactoryFactory : IRawCreateObjectFactory
{
    public TheObject CreateObject(string name, int age, string[] tags)
    {
        return new TheObject
        {
            Name = name,
            Age = age,
            Tags = tags
        };
    }
}