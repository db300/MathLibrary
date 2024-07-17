using System;
using System.Drawing;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 向量计算器
    /// </summary>
    public static class VectorCalc
    {
        /// <summary>
        /// 计算两个向量夹角
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double VectorAngle(PointF a, PointF b, PointF c)
        {
            PointF vectorA2B = new PointF(a.X - b.X, a.Y - b.Y), vectorC2B = new PointF(c.X - b.X, c.Y - b.Y);
            var angle = Math.Atan2(vectorA2B.X * vectorC2B.Y - vectorA2B.Y * vectorC2B.X, InnerProduct(vectorA2B, vectorC2B)) * 180 / Math.PI;
            angle = (angle + 360) % 360;
            return 360 - angle;
        }

        /// <summary>
        /// 计算两个向量内积(在直角坐标系中，两向量的内积等于它们对应坐标的乘积之和)
        /// </summary>
        /// <param name="ptA"></param>
        /// <param name="ptB"></param>
        /// <returns></returns>
        public static float InnerProduct(PointF ptA, PointF ptB)
        {
            return ptA.X * ptB.X + ptA.Y * ptB.Y;
        }

        /// <summary>
        /// 计算两个向量的外积
        /// </summary>
        /// <param name="ptA"></param>
        /// <param name="ptB"></param>
        /// <param name="ptC"></param>
        /// <returns></returns>
        public static float CrossProduct(PointF ptA, PointF ptB, PointF ptC)
        {
            return (ptA.X - ptC.X) * (ptB.Y - ptC.Y) - (ptB.X - ptC.X) * (ptA.Y - ptC.Y);
        }
    }
}
