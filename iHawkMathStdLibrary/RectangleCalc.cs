using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 矩形计算器
    /// </summary>
    public static class RectangleCalc
    {
        /// <summary>
        /// 获取一组点的最大外接矩形
        /// </summary>
        public static RectangleF GetMaxExternalRect(List<PointF> pointList)
        {
            if (pointList == null || pointList.Count == 0) return RectangleF.Empty;
            float left = pointList[0].X, top = pointList[0].Y, right = pointList[0].X, bottom = pointList[0].Y;
            for (var i = 1; i < pointList.Count; i++)
            {
                left = Math.Min(left, pointList[i].X);
                right = Math.Max(right, pointList[i].X);
                top = Math.Min(top, pointList[i].Y);
                bottom = Math.Max(bottom, pointList[i].Y);
            }

            return new RectangleF(left, top, right - left, bottom - top);
        }

        /// <summary>
        /// 获取一组矩形的最大外接矩形
        /// </summary>
        public static RectangleF GetMaxExternalRect(List<RectangleF> rectangleList)
        {
            if (rectangleList == null || rectangleList.Count == 0) return RectangleF.Empty;
            float left = rectangleList[0].Left, right = rectangleList[0].Right, top = rectangleList[0].Top, bottom = rectangleList[0].Bottom;
            for (var i = 1; i < rectangleList.Count; i++)
            {
                left = Math.Min(left, rectangleList[i].Left);
                right = Math.Max(right, rectangleList[i].Right);
                top = Math.Min(top, rectangleList[i].Top);
                bottom = Math.Max(bottom, rectangleList[i].Bottom);
            }

            return new RectangleF(left, top, right - left, bottom - top);
        }
    }
}
