/*
* Created by Jorge Duran (https://github.com/ganchito55)
* Instruction set references:
*   Intel: https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_minpos_epu16&expand=3783
*   phminposuw instruction: https://www.officedaytime.com/simd512e/simdimg/si.php?f=phminposuw
*/

using System;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Running;
using Simd.Validators;

namespace Simd
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!Sse41.IsSupported){
                Console.WriteLine("Your CPU doesn't support SSE4.1 Instruction set");
                return;
            }

            var findMinValueValidator = new FindMinValueValidator();
            if (!findMinValueValidator.ValidateFindMinValueMethods())
            {
                Console.WriteLine("Not all methods return the correct result");
                return;

            }

            var summary = BenchmarkRunner.Run<FindMinValueBenchmark>();
        }
    }
}
