# simd
Using C# and .NET Core 3 to call x86 SIMD instruction to speed up the algorithm of searching the min value

# Benchmark

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