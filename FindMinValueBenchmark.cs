using System;
using BenchmarkDotNet.Attributes;

namespace Simd
{
    public class FindMinValueBenchmark
    {
        private ushort _us0, _us1, _us2, _us3, _us4, _us5, _us6, _us7;
        private FindMinValue _findMinValue;

        [GlobalSetup]
        public void Setup()
        {
            _findMinValue = new FindMinValue();

            var buffer = new byte[16];
            new Random(453).NextBytes(buffer);

            _us0 = (ushort)(buffer[0] + buffer[1] << 8);
            _us1 = (ushort)(buffer[2] + buffer[3] << 8);
            _us2 = (ushort)(buffer[4] + buffer[5] << 8);
            _us3 = (ushort)(buffer[6] + buffer[7] << 8);
            _us4 = (ushort)(buffer[8] + buffer[9] << 8);
            _us5 = (ushort)(buffer[10] + buffer[11] << 8);
            _us6 = (ushort)(buffer[12] + buffer[13] << 8);
            _us7 = (ushort)(buffer[14] + buffer[15] << 8);
        }

        [Benchmark]
        public ushort FindWithLINQ() 
            => _findMinValue.MinLINQ(_us0, _us1, _us2, _us3, _us4, _us5, _us6, _us7);

        [Benchmark]
        public ushort FindWithLoopForeach()
            => _findMinValue.MinLoopForeach(_us0, _us1, _us2, _us3, _us4, _us5, _us6, _us7);

        [Benchmark]
        public ushort FindWithLoopForBuffer()
            => _findMinValue.MinLoopForBuffer(_us0, _us1, _us2, _us3, _us4, _us5, _us6, _us7);

        [Benchmark]
        public ushort FindWithLoopFor() 
            => _findMinValue.MinLoopFor(_us0, _us1, _us2, _us3, _us4, _us5, _us6, _us7);

        [Benchmark]
        public ushort FindWithMinMath() 
            => _findMinValue.MinMath(_us0, _us1, _us2, _us3, _us4, _us5, _us6, _us7);

        [Benchmark]
        public ushort FindWithMinSIMD()
            => _findMinValue.MinSIMD(_us0, _us1, _us2, _us3, _us4, _us5, _us6, _us7);
    }
}
