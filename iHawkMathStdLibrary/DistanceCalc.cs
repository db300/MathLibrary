using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
