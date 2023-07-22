# Benchmarking Activator Utilities Performance

Raw creation of objects is 1.700% faster and make 23% less allocations than using activator utilities.

```
|                                                  Method |      Mean |     Error |   StdDev |   Gen0 | Allocated |
|-------------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| measure_performance_activator_utilities_create_instance | 272.18 ns | 49.908 ns | 2.736 ns | 0.0362 |     304 B |
|                    measure_performance_raw_new_instance |  16.90 ns |  8.580 ns | 0.470 ns | 0.0086 |      72 B |
```