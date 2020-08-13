using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 角度计算器
    /// </summary>
    public static class AngleCalc
    {
        /// <summary>
        /// 获取角度值
        /// </summary>
        /// <param name="vertex">角的顶点</param>
        /// <param name="p1">端点1</param>
        /// <param name="p2">端点2</param>
        /// <returns>角度值</returns>
        public static double Angle(PointF vertex, PointF p1, PointF p2)
        {
            double adx = p1.X - vertex.X, ady = p1.Y - vertex.Y, bdx = p2.X - vertex.X, bdy = p2.Y - vertex.Y;
            var v1 = adx * bdx + ady * bdy;
            double dam = Math.Sqrt(adx * adx + ady * ady), dbm = Math.Sqrt(bdx * bdx + bdy * bdy);
            var cosM = v1 / (dam * dbm);
            var angleAmb = Math.Acos(cosM) * 180 / Math.PI;
            return angleAmb;
        }
    }
}
