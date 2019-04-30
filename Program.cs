/*
* Created by Jorge Duran (https://github.com/ganchito55)
* Instruction set references:
*   Intel: https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_minpos_epu16&expand=3783
*   phminposuw instruction: https://www.officedaytime.com/simd512e/simdimg/si.php?f=phminposuw
*/

using System;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;
using System.Linq;
using BenchmarkDotNet.Running;

namespace Simd
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FindMinValueHelper>();
        }
    }

    public class FindMinValueHelper{

        private ushort _us0, _us1,_us2,_us3,_us4,_us5,_us6,_us7;

        public FindMinValueHelper()
        {
            var buffer = new byte[16];
            new Random(453).NextBytes(buffer);

            _us0 = (ushort)(buffer[0] + buffer[1]<<8);
            _us1 = (ushort)(buffer[2] + buffer[3]<<8);
            _us2 = (ushort)(buffer[4] + buffer[5]<<8);
            _us3 = (ushort)(buffer[6] + buffer[7]<<8);
            _us4 = (ushort)(buffer[8] + buffer[9]<<8);
            _us5 = (ushort)(buffer[10] + buffer[11]<<8);
            _us6 = (ushort)(buffer[12] + buffer[13]<<8);
            _us7 = (ushort)(buffer[14] + buffer[15]<<8);
        }

        [Benchmark]
        public ushort FindWithMinSIMD() => MinSIMD(_us0,_us1,_us2,_us3,_us4,_us5,_us6,_us7);
        
        [Benchmark]
        public ushort FindWithLINQ() => MinLINQ(_us0,_us1,_us2,_us3,_us4,_us5,_us6,_us7);

        [Benchmark]
        public ushort FindWithLoop() => MinLoop(_us0,_us1,_us2,_us3,_us4,_us5,_us6,_us7);

        public ushort MinSIMD(ushort us0, ushort us1, ushort us2,
            ushort us3, ushort us4,ushort us5, ushort us6, ushort us7){
            
            var values = Vector128.Create(us0,us1,us2,us3,us4,us5,us6,us7);
            return Sse41.MinHorizontal(values).GetElement(0);
        }

        public ushort MinLINQ(ushort us0, ushort us1, ushort us2,
            ushort us3, ushort us4,ushort us5, ushort us6, ushort us7){
            
            return new ushort[8]{us0,us1,us2,us3,us4,us5,us6,us7}.Min();
        }

        public ushort MinLoop(ushort us0, ushort us1, ushort us2,
            ushort us3, ushort us4,ushort us5, ushort us6, ushort us7){
            
            ushort min = us0;
            foreach(var value in new ushort[7]{us1,us2,us3,us4,us5,us6,us7}){
                if(value<min)
                    min=value;
            }
            return min;
        } 
    }
}
