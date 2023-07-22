using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks.ActivatorUtilitiesPerformance;

[MemoryDiagnoser]
public class ActivatorUtilitiesPerformance
{
    private readonly IActivatorUtilitiesObjectFactory _activatorUtilitiesObjectFactory;

    private readonly IServiceProvider _provider;
    private readonly IRawCreateObjectFactory _rawCreateObjectFactory;

    public ActivatorUtilitiesPerformance()
    {
        var services = new ServiceCollection();
        services.AddScoped<IRawCreateObjectFactory, RawCreateCreateObjectFactoryFactory>();
        services.AddScoped<IActivatorUtilitiesObjectFactory, ActivatorUtilitiesObjectFactory>();
        _provider = services.BuildServiceProvider();

        _activatorUtilitiesObjectFactory = _provider.GetRequiredService<IActivatorUtilitiesObjectFactory>();
        _rawCreateObjectFactory = _provider.GetRequiredService<IRawCreateObjectFactory>();
    }

    public static void Main(string[] args)
    {
        var config = DefaultConfig.Instance
            .AddJob(Job
                .ShortRun
                .WithLaunchCount(1)
                .WithToolchain(InProcessEmitToolchain.Instance));
        BenchmarkRunner.Run<ActivatorUtilitiesPerformance>(config);
    }

    [Benchmark]
    public void measure_performance_activator_utilities_create_instance()
    {
        var obj = _activatorUtilitiesObjectFactory.CreateObject("idjinn", 69, new[] { "none" });
    }

    [Benchmark]
    public void measure_performance_raw_new_instance()
    {
        var obj = _rawCreateObjectFactory.CreateObject("idjinn", 69, new[] { "none" });
    }
}