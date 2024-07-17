using System;
using System.Drawing;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 距离计算器
    /// </summary>
    public static class DistanceCalc
    {
        /// <summary>
        /// 获取平面空间中两点间距离
        /// get the distance between two points
        /// </summary>
        /// <param name="pt1">点1</param>
        /// <param name="pt2">点2</param>
        /// <returns>两点间距离</returns>
        public static double GetDistance(PointF pt1, PointF pt2)
        {
            return Math.Sqrt((pt1.X - pt2.X) * (pt1.X - pt2.X) + (pt1.Y - pt2.Y) * (pt1.Y - pt2.Y));
        }

        /// <summary>
        /// 获取平面空间中点到直线的距离
        /// get the distance from point to line
        /// </summary>
        /// <param name="pt">点</param>
        /// <param name="pt1">直线起点1</param>
        /// <param name="pt2">直线起点2</param>
        /// <returns>点到直线间距离</returns>
        public static double GetDistanceP2L(PointF pt, PointF pt1, PointF pt2)
        {
            double d;
            float x1 = pt1.X, y1 = pt1.Y, x2 = pt2.X, y2 = pt2.Y, x0 = pt.X, y0 = pt.Y;
            if (Math.Abs(pt1.X - pt2.X) <= 0) d = Math.Abs(pt.X - pt1.X);
            else if (Math.Abs(pt1.Y - pt2.Y) <= 0) d = Math.Abs(pt.Y - pt1.Y);
            else d = Math.Abs((y2 - y1) * x0 + (x1 - x2) * y0 + y1 * x2 - x1 * y2) / Math.Sqrt((y2 - y1) * (y2 - y1) + (x1 - x2) * (x1 - x2));
            return d;
        }
    }
}
