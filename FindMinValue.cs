using System;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Simd
{
    internal class FindMinValue
    {
        internal ushort MinSIMD(ushort us0, ushort us1, ushort us2,
          ushort us3, ushort us4, ushort us5, ushort us6, ushort us7)
        {
            var values = Vector128.Create(us0, us1, us2, us3, us4, us5, us6, us7);
            return Sse41.MinHorizontal(values).GetElement(0);
        }

        internal ushort MinLINQ(ushort us0, ushort us1, ushort us2,
            ushort us3, ushort us4, ushort us5, ushort us6, ushort us7)
        {
            return new []{ us0, us1, us2, us3, us4, us5, us6, us7 }.Min();
        }

        internal ushort MinLoopForeach(ushort us0, ushort us1, ushort us2,
            ushort us3, ushort us4, ushort us5, ushort us6, ushort us7)
        {
            ushort min = us0;
            foreach (var value in new ushort[] { us1, us2, us3, us4, us5, us6, us7 })
            {
                if (value < min)
                    min = value;
            }
            return min;
        }

        // No thread safety!
        private readonly ushort[] _buffer = new ushort[8];
        internal ushort MinLoopForBuffer(ushort us0, ushort us1, ushort us2,
            ushort us3, ushort us4, ushort us5, ushort us6, ushort us7)
        {
            var min = us0;
            _buffer[0] = us0;
            _buffer[1] = us1;
            _buffer[2] = us2;
            _buffer[3] = us3;
            _buffer[4] = us4;
            _buffer[5] = us5;
            _buffer[6] = us6;
            _buffer[7] = us7;

            for (int i = 0; i < _buffer.Length; i++)
            {
                var value = _buffer[i];
                if (value < min)
                    min = value;
            }
            return min;
        }

        internal ushort MinLoopFor(ushort us0, ushort us1, ushort us2,
            ushort us3, ushort us4, ushort us5, ushort us6, ushort us7)
        {
            var min = us0;
            unsafe
            {
                var values = stackalloc ushort[] { us1, us2, us3, us4, us5, us6, us7 };
                for (int i = 0; i < 7; i++)
                {
                    var value = values[i];
                    if (value < min)
                        min = value;
                }
                return min;
            }
        }
        
        internal ushort MinMath(
            ushort us0, ushort us1, ushort us2,
            ushort us3, ushort us4, ushort us5, ushort us6, ushort us7)
        {
            var min = us0;
            min = Math.Min(min, us1);
            min = Math.Min(min, us2);
            min = Math.Min(min, us3);
            min = Math.Min(min, us4);
            min = Math.Min(min, us5);
            min = Math.Min(min, us6);
            return Math.Min(min, us7);
        }
    }
}
