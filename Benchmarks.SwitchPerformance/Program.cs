using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace Benchmarks.SwitchPerformance;


[MemoryDiagnoser]
public class Program
{
    private static readonly Random _rand = new Random(69);
    private static readonly char[]  _validMapPoints = {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
        'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
        'U', 'V', 'W', 'X', 
        // 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        // 'k', 'l','m', 'n', 'o', 'p', 'q', 'r','s', 't',
        // 'u', 'v', 'w', 'x', 
    };
    
    public static void Main(string[] args)
    {
        var config = DefaultConfig.Instance
            .AddJob(Job
                .ShortRun
                .WithLaunchCount(1)
                .WithToolchain(InProcessEmitToolchain.Instance));
        BenchmarkRunner.Run<Program>(config);
    }
    
    [Benchmark]
    public void measure_performance_switch()
    {
        map_height_lookup_switch(Convert.ToChar(_validMapPoints[_rand.Next(_validMapPoints.Length)]));
    }
    
    [Benchmark]
    public void measure_performance_math()
    {
        map_height_char_code(Convert.ToChar(_validMapPoints[_rand.Next(_validMapPoints.Length)]));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static ushort map_height_char_code(char tile)
    {
        int charCode = (int)tile;

        if (charCode >= 48 && charCode <= 57) // '0' to '9'
        {
            return (ushort)(charCode - 48);
        }

        if (charCode >= 65 && charCode <= 87) // 'A' to 'W'
        {
            return (ushort)(charCode - 55);
        }

        if (tile == 'X')
        {
            return ushort.MaxValue;
        }
        throw new ArgumentOutOfRangeException(nameof(tile), tile, null);
    }

    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static ushort map_height_lookup_switch(char tile)
    {
        return tile switch
        {
            '0' => 0,
            '1' => 1,
            '2' => 2,
            '3' => 3,
            '4' => 4,
            '5' => 5,
            '6' => 6,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            'A' => 10,
            'B' => 11,
            'C' => 12,
            'D' => 13,
            'E' => 14,
            'F' => 15,
            'G' => 16,
            'H' => 17,
            'I' => 18,
            'J' => 19,
            'K' => 20,
            'L' => 21,
            'M' => 22,
            'N' => 23,
            'O' => 24,
            'P' => 25,
            'Q' => 26,
            'R' => 27,
            'S' => 28,
            'T' => 29,
            'U' => 30,
            'V' => 31,
            'W' => 32,

            'X' => ushort.MaxValue,
            _ => throw new ArgumentOutOfRangeException(nameof(tile), tile, null)
        };
    }
}