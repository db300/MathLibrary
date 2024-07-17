using System;
using System.Collections.Generic;
using System.Drawing;

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
            return new Point((int)(point.X + 0.5), (int)(point.Y + 0.5));
        }

        /// <summary>
        /// 获取倾斜直线上某点
        /// </summary>
        /// <param name="pt0">直线上已知点</param>
        /// <param name="angle">直线倾斜角度</param>
        /// <param name="deltaX">距离已知点横坐标增量</param>
        /// <returns>所求点</returns>
        public static PointF GetPointOnLineByDeltaX(PointF pt0, double angle, float deltaX = 10)
        {
            return GetPointOnLineByDeltaX(pt0.X, pt0.Y, angle, deltaX);
        }

        /// <summary>
        /// (overload)获取倾斜直线上某点
        /// </summary>
        /// <param name="pX">直线上已知点横坐标</param>
        /// <param name="pY">直线上已知点纵坐标</param>
        /// <param name="angle">直线倾斜角度</param>
        /// <param name="deltaX">距离已知点横坐标增量</param>
        /// <returns>所求点</returns>
        public static PointF GetPointOnLineByDeltaX(float pX, float pY, double angle, float deltaX = 10)
        {
            var radian = Math.PI * angle / 180;//根据角度值获取弧度值
            var tan = Math.Tan(radian);//根据弧度值获取正切值
            var deltaY = deltaX * tan;
            var pt = new PointF(pX + deltaX, (float)(pY + deltaY));
            return pt;
        }

        /// <summary>
        /// 获取倾斜直线上某点
        /// </summary>
        /// <param name="pX">直线上已知点横坐标</param>
        /// <param name="pY">直线上已知点纵坐标</param>
        /// <param name="angle">直线倾斜角度</param>
        /// <param name="deltaY">距离已知点纵坐标增量</param>
        /// <returns>所求点</returns>
        public static PointF GetPointOnLineByDeltaY(float pX, float pY, double angle, float deltaY = 10)
        {
            var radian = Math.PI * angle / 180;//根据角度值获取弧度值
            var tan = Math.Tan(radian);//根据弧度值获取正切值
            var deltaX = deltaY / tan;
            var pt = new PointF((float)(pX + deltaX), pY + deltaY);
            return pt;
        }

        /// <summary>
        /// 获取某一向量上距离起点某一距离的点
        /// </summary>
        /// <param name="pt1">向量起点</param>
        /// <param name="pt2">向量终点</param>
        /// <param name="distance">距离</param>
        /// <returns>所求点</returns>
        public static PointF GetPointOnVector(PointF pt1, PointF pt2, float distance)
        {
            var d = (float)Math.Sqrt((pt2.X - pt1.X) * (pt2.X - pt1.X) + (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y));
            var t = distance / d;
            float x = t * pt2.X + (1 - t) * pt1.X, y = t * pt2.Y + (1 - t) * pt1.Y;
            return new PointF(x, y);
        }

        /// <summary>
        /// 获取某一向量终点旋转某一角度（角度值）后的点
        /// </summary>
        /// <param name="pt1">向量起点</param>
        /// <param name="pt2">向量终点</param>
        /// <param name="angle">旋转角度（角度值）</param>
        /// <returns>所求点</returns>
        public static PointF GetRotatedPointOnVector(PointF pt1, PointF pt2, float angle)
        {
            float dx = pt2.X - pt1.X, dy = pt2.Y - pt1.Y;
            float
                dx1 = (float)(dx * Math.Cos(angle * Math.PI / 180) - dy * Math.Sin(angle * Math.PI / 180)),
                dy1 = (float)(dx * Math.Sin(angle * Math.PI / 180) + dy * Math.Cos(angle * Math.PI / 180));
            return new PointF(pt1.X + dx1, pt1.Y + dy1); //pt2绕pt1旋转后的点
        }

        /// <summary>
        /// 获取某一向量上距离起点某一距离的点，并绕起点旋转某一角度（角度值）后的点
        /// </summary>
        /// <param name="pt1">向量起点</param>
        /// <param name="pt2">向量终点</param>
        /// <param name="distance">距离</param>
        /// <param name="angle">旋转角度（角度值）</param>
        /// <returns>所求点</returns>
        public static PointF GetRotatedPointOnVector(PointF pt1, PointF pt2, float distance, float angle)
        {
            return GetRotatedPointOnVector(pt1, GetPointOnVector(pt1, pt2, distance), angle);
        }

        /// <summary>
        /// 获取某一向量终点倾斜某一角度（角度值）后的点
        /// </summary>
        /// <param name="pt1">向量起点</param>
        /// <param name="pt2">向量终点</param>
        /// <param name="d">旋转角度（角度值）</param>
        /// <param name="dn">倾斜参照角度（角度值）</param>
        /// <returns>所求点</returns>
        public static PointF GetLeanedPointOnVector(PointF pt1, PointF pt2, float d, float dn = 0.0F)
        {
            var pt22 = GetRotatedPointOnVector(pt1, pt2, d); //pt2绕pt1旋转后的点
            if (Math.Abs(dn - 0) <= 0) return new PointF(pt22.X, pt2.Y); //水平倾斜
            if (Math.Abs(dn - 90) <= 0) return new PointF(pt2.X, pt22.Y); //垂直倾斜
            return PointF.Empty;
        }

        /// <summary>
        /// 获取一组点集合的最值点(最左/右/上/下)
        /// </summary>
        /// <param name="points">点集数组</param>
        /// <returns>最值点数据(最左、最右、最上、最下)</returns>
        public static PointF[] GetExtremePoints(PointF[] points)
        {
            if (points == null) return null;
            PointF left = points[0], right = points[0], top = points[0], bottom = points[0];
            foreach (var point in points)
            {
                if (point.X < left.X) left = point;
                if (point.X > right.X) right = point;
                if (point.Y < bottom.Y) bottom = point;
                if (point.Y > top.Y) top = point;
            }

            return new[] { left, right, top, bottom };
        }

        /// <summary>
        /// 获取点到直线的垂点
        /// </summary>
        /// <param name="pt1">直线点1</param>
        /// <param name="pt2">直线点2</param>
        /// <param name="pt">平面上某点</param>
        /// <returns>点pt到直线pt1pt2的垂点</returns>
        public static PointF GetVerticalPointOnLine(PointF pt1, PointF pt2, PointF pt)
        {
            if (pt2.X == pt1.X)
            {
                return new PointF(pt1.X, pt.Y);
            }
            else
            {
                var k = (pt2.Y - pt1.Y) / (pt2.X - pt1.X);
                var x = (k * k * pt1.X + k * (pt.Y - pt1.Y) + pt.X) / (k * k + 1);
                var y = k * (x - pt1.X) + pt1.Y;
                return new PointF(x, y);
            }
        }

        /// <summary>
        /// 获取一组点中距离参考点最近的点
        /// </summary>
        /// <param name="ptRef">参考点</param>
        /// <param name="points">样本点</param>
        public static PointF GetNearestPoint(PointF ptRef, List<PointF> points)
        {
            if (points.Count == 0) return PointF.Empty;
            if (points.Count == 1) return points[0];
            var nearestPoint = points[0];
            double d = DistanceCalc.GetDistance(ptRef, points[0]);
            for (int i = 1; i < points.Count; i++)
            {
                var point = points[i];
                double d1;
                if ((d1 = DistanceCalc.GetDistance(point, ptRef)) <= d)
                {
                    nearestPoint = point;
                    d = d1;
                }
            }
            return nearestPoint;
        }
    }
}
