namespace Benchmarks.ActivatorUtilitiesPerformance;

public interface IObjectFactory
{
    public TheObject CreateObject(string name, int age, string[] tags);
}