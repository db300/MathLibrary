using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 点计算器
    /// </summary>
    public static class PointCalc
    {
        /// <summary>
        /// (overload)get the midpoint between two points
        /// </summary>
        /// <param name="p1">point 1</param>
        /// <param name="p2">point 2</param>
        /// <returns>midpoint</returns>
        public static PointF GetMidPointF(PointF p1, PointF p2)
        {
            return GetMidPointF(p1.X, p1.Y, p2.X, p2.Y);
        }

        /// <summary>
        /// (overload)get the midpoint between two points
        /// </summary>
        /// <param name="x1">point1's x</param>
        /// <param name="y1">point1's y</param>
        /// <param name="x2">point2's x</param>
        /// <param name="y2">point2's y</param>
        /// <returns>midpoint</returns>
        public static PointF GetMidPointF(float x1, float y1, float x2, float y2)
        {
            return new PointF(Math.Min(x1, x2) + Math.Abs(x1 - x2) / 2, Math.Min(y1, y2) + Math.Abs(y1 - y2) / 2);
        }

        /// <summary>
        /// get the midpoint between two points
        /// </summary>
        /// <param name="p1">point 1</param>
        /// <param name="p2">point 2</param>
        /// <returns>midpoint</returns>
        public static Point GetMidPoint(PointF p1, PointF p2)
        {
            var point = GetMidPointF(p1, p2);
            return new Point((int) (point.X + 0.5), (int) (point.Y + 0.5));
        }
    }
}
