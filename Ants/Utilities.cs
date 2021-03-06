using System;
using System.Collections.Generic;
using System.Text;

namespace Ants
{
    public class Utilities
    {
        public static float Map(float from, float fromMin, float fromMax, float toMin, float toMax)
        {
            var fromAbs = @from - fromMin;
            var fromMaxAbs = fromMax - fromMin;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = toMax - toMin;
            var toAbs = toMaxAbs * normal;

            var to = toAbs + toMin;

            return to;
        }
    }
}
