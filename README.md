# simd
Using C# and .NET Core 3 to call x86 SIMD instruction to speed up the algorithm of searching the min value

# V2 Benchmark

## Windows, .NET Core 3.1 and i7-6700k
``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]     : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  DefaultJob : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT


```
|                Method |      Mean |     Error |    StdDev |
|---------------------- |----------:|----------:|----------:|
|          FindWithLINQ | 58.246 ns | 0.3291 ns | 0.3079 ns |
|   FindWithLoopForeach |  9.827 ns | 0.1140 ns | 0.1067 ns |
| FindWithLoopForBuffer |  9.094 ns | 0.1056 ns | 0.0936 ns |
|       FindWithLoopFor |  7.370 ns | 0.0556 ns | 0.0520 ns |
|       FindWithMinMath |  4.684 ns | 0.0470 ns | 0.0416 ns |
|       FindWithMinSIMD |  2.531 ns | 0.0128 ns | 0.0107 ns |


# V1 Benchmark

## Windows, .NET Core 3 and i7-6700k
``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT


```
|          Method |      Mean |     Error |    StdDev |
|---------------- |----------:|----------:|----------:|
| FindWithMinSIMD |  2.574 ns | 0.0216 ns | 0.0180 ns |
|    FindWithLINQ | 58.882 ns | 0.3967 ns | 0.3711 ns |
|    FindWithLoop | 10.210 ns | 0.2322 ns | 0.4187 ns |

## Linux, .NET Core 3 Preview and Intel Q9300

``` ini

BenchmarkDotNet=v0.11.5, OS=ubuntu 18.04
Intel Core2 Quad CPU Q9300 2.50GHz, 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=3.0.100-preview4-011223
  [Host]     : .NET Core 3.0.0-preview4-27615-11 (CoreCLR 4.6.27615.73, CoreFX 4.700.19.21213), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0-preview4-27615-11 (CoreCLR 4.6.27615.73, CoreFX 4.700.19.21213), 64bit RyuJIT


```
|          Method |       Mean |     Error |    StdDev |
|---------------- |-----------:|----------:|----------:|
| FindWithMinSIMD |   3.696 ns | 0.0225 ns | 0.0200 ns |
|    FindWithLINQ | 182.543 ns | 3.5925 ns | 4.2767 ns |
|    FindWithLoop |  29.490 ns | 0.1920 ns | 0.1796 ns |

# References

[Intel instruction documentation](https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_minpos_epu16&expand=3783)

[Visual documentation](https://www.officedaytime.com/simd512e/simdimg/si.php?f=phminposuw)
