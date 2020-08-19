using System;
using System.Collections.Generic;
using System.Text;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 方程计算器
    /// </summary>
    public static class EquationCalc
    {
        /// <summary>
        /// 解一元二次方程(a * x ^ 2 + b * x + c = 0)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static bool QuadraticEquation(float a, float b, float c, out double x1, out double x2)
        {
            x1 = -0.1f;
            x2 = -0.1f;
            double dt = b * b - 4 * a * c;
            bool succeed;
            try
            {
                if (dt > 0)
                {
                    x1 = (-b + Math.Sqrt(dt)) / (2 * a);
                    x2 = (-b - Math.Sqrt(dt)) / (2 * a);
                    succeed = true;
                }
                else if (Math.Abs(dt - 0) <= 0)
                {
                    x1 = -(b / (2 * a));
                    x2 = -(b / (2 * a));
                    succeed = true;
                }
                else succeed = false;
            }
            catch (Exception)
            {
                succeed = false;
            }

            return succeed;
        }
    }
}
