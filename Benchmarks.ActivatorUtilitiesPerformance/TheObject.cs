namespace Benchmarks.ActivatorUtilitiesPerformance;

public class TheObject
{
    public TheObject(string name, int age, string[] tags)
    {
        Name = name;
        Age = age;
        Tags = tags;
    }

    public TheObject()
    {
    }

    public string Name { get; init; }
    public int Age { get; init; }
    public string[] Tags { get; init; }
}