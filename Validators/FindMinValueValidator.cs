namespace Simd.Validators
{
    // TODO Validator class to unit tests ?
    internal class FindMinValueValidator
    {
        private readonly FindMinValue _findMinValue;

        internal FindMinValueValidator()
        {
            _findMinValue = new FindMinValue();
        }

        internal bool ValidateFindMinValueMethods()
        {
            ushort us0 = 7;
            ushort us1 = 6;
            ushort us2 = 5;
            ushort us3 = 4;
            ushort us4 = 3;
            ushort us5 = 2;
            ushort us6 = 1;
            ushort us7 = 0;

            // I know - reflection
            var result = _findMinValue
                .MinLINQ(
                    us0, us1, us2, us3,
                    us4, us5, us6, us7
                );
            if (result != 0)
                return false;

            result = _findMinValue
                .MinLoopForeach(
                    us0, us1, us2, us3,
                    us4, us5, us6, us7
                );
            if (result != 0)
                return false;

            result = _findMinValue
                .MinLoopFor(
                    us0, us1, us2, us3,
                    us4, us5, us6, us7
                );
            if (result != 0)
                return false;

            result = _findMinValue
                .MinLoopForBuffer(
                    us0, us1, us2, us3,
                    us4, us5, us6, us7
                );
            if (result != 0)
                return false;

            result = _findMinValue
                .MinMath(
                    us0, us1, us2, us3,
                    us4, us5, us6, us7
                );
            if (result != 0)
                return false;

            result = _findMinValue
                .MinSIMD(
                    us0, us1, us2, us3,
                    us4, us5, us6, us7
                );
            if (result != 0)
                return false;

            return true;
        }
    }
}
