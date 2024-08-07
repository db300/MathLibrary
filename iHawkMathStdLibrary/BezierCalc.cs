﻿using System;
using System.Drawing;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 贝塞尔曲线计算器
    /// </summary>
    public static class BezierCalc
    {
        /// <summary>
        /// 拆分三次贝塞尔曲线
        /// </summary>
        /// <param name="points">贝塞尔曲线锚点及手柄点数组</param>
        /// <param name="time">拆分次数</param>
        /// <returns>拆分后的三次贝塞尔曲线锚点及手柄点数组</returns>
        public static PointF[] SplitCubicCurve(PointF[] points, int time = 1)
        {
            var outpoints = new PointF[(int)(points.Length * 2 * Math.Pow(2, time - 1))];
            var loop = 0;
            if (time == 1)
            {
                for (var i = 0; i < points.Length; i += 4)
                {
                    PointF pt0 = points[i], pt1 = points[i + 1], pt2 = points[i + 2], pt3 = points[i + 3];
                    PointF
                        pt13 = new PointF((pt0.X + 3 * pt1.X + 3 * pt2.X + pt3.X) / 8, (pt0.Y + 3 * pt1.Y + 3 * pt2.Y + pt3.Y) / 8),
                        pt11 = new PointF((7 * pt0.X + 9 * pt1.X) / 16, (7 * pt0.Y + 9 * pt1.Y) / 16),
                        pt12 = new PointF((7 * pt0.X + 21 * pt1.X + 3 * pt2.X + pt3.X) / 32, (7 * pt0.Y + 21 * pt1.Y + 3 * pt2.Y + pt3.Y) / 32),
                        pt21 = new PointF((pt0.X + 3 * pt1.X + 21 * pt2.X + 7 * pt3.X) / 32, (pt0.Y + 3 * pt1.Y + 21 * pt2.Y + 7 * pt3.Y) / 32),
                        pt22 = new PointF((7 * pt3.X + 9 * pt2.X) / 16, (7 * pt3.Y + 9 * pt2.Y) / 16);
                    outpoints[loop * 8] = pt0;
                    outpoints[loop * 8 + 1] = pt11;
                    outpoints[loop * 8 + 2] = pt12;
                    outpoints[loop * 8 + 3] = pt13;
                    outpoints[loop * 8 + 4] = pt13;
                    outpoints[loop * 8 + 5] = pt21;
                    outpoints[loop * 8 + 6] = pt22;
                    outpoints[loop * 8 + 7] = pt3;
                    loop++;
                }
            }
            else
            {
                var outPts = points;
                while (time > 0)
                {
                    outPts = SplitCubicCurve(outPts);
                    time--;
                }
                for (var i = 0; i < outPts.Length; i++) outpoints[i] = outPts[i];
            }
            return outpoints;
        }

        /// <summary>
        /// 获取三次贝塞尔曲线上某t对应的点
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static PointF GetCubicCurvePoint(PointF p0, PointF p1, PointF p2, PointF p3, float t)
        {
            return new PointF(
                p0.X * (1 - t) * (1 - t) * (1 - t) + 3 * p1.X * t * (1 - t) * (1 - t) + 3 * p2.X * t * t * (1 - t) + p3.X * t * t * t,
                p0.Y * (1 - t) * (1 - t) * (1 - t) + 3 * p1.Y * t * (1 - t) * (1 - t) + 3 * p2.Y * t * t * (1 - t) + p3.Y * t * t * t);
        }

        /// <summary>
        /// 计算二次贝塞尔曲线点B(t)=(1-t)*(1-t)*P0+2*t*(1-t)P1+t*t*P2
        /// </summary>
        /// <param name="pt0">OnLine起始点</param>
        /// <param name="pt1">OffLine控制点</param>
        /// <param name="pt2">OnLine终止点</param>
        /// <param name="accuracy">贝塞尔曲线绘制精度，默认10个点</param>
        /// <returns>二次贝塞尔曲线点</returns>
        public static PointF[] GetQuadraticCurvePoints(PointF pt0, PointF pt1, PointF pt2, int accuracy = 10)
        {
            var points = new PointF[accuracy + 1];
            for (var i = 0; i <= accuracy; i++)
            {
                var pt = new PointF();
                var t = (float)i / accuracy;
                pt.X = (1 - t) * (1 - t) * pt0.X + 2 * t * (1 - t) * pt1.X + t * t * pt2.X;
                pt.Y = (1 - t) * (1 - t) * pt0.Y + 2 * t * (1 - t) * pt1.Y + t * t * pt2.Y;
                points[i] = pt;
            }

            return points;
        }

        /// <summary>
        /// 二次曲线点转换为三次曲线点
        /// </summary>
        /// <param name="start">二次曲线起始线上点</param>
        /// <param name="controlPoint">二次曲线线外控制点</param>
        /// <param name="end">二次曲线终止线上点</param>
        /// <returns>item1: 起始线上点, item2: 线外控制点1, item3: 线外控制点2</returns>
        public static Tuple<PointF, PointF, PointF, PointF> Quadratic2Cubic(PointF start, PointF controlPoint, PointF end)
        {
            var c1X = (start.X + 2 * controlPoint.X) / 3;
            var c1Y = (start.Y + 2 * controlPoint.Y) / 3;
            var c2X = (end.X + 2 * controlPoint.X) / 3;
            var c2Y = (end.Y + 2 * controlPoint.Y) / 3;
            return new Tuple<PointF, PointF, PointF, PointF>(start, new PointF(c1X, c1Y), new PointF(c2X, c2Y), end);
        }

        /// <summary>
        /// 计算二次贝塞尔曲线控制点(默认 t = 0.5F)
        /// </summary>
        /// <param name="p0">贝塞尔曲线起点</param>
        /// <param name="p2">贝塞尔曲线终点</param>
        /// <param name="p">曲线上的点，假定该点对应的t=0.5</param>
        public static PointF GetQuadraticCurveControlPoint(PointF p0, PointF p2, PointF p)
        {
            //𝑃1 = 2𝑃(0.5)−0.5𝑃0−0.5𝑃2
            var p1X = 2 * p.X - 0.5 * p0.X - 0.5 * p2.X;
            var p1Y = 2 * p.Y - 0.5 * p0.Y - 0.5 * p2.Y;
            return new PointF((float)p1X, (float)p1Y);
        }

        /// <summary>
        /// 计算二次贝塞尔曲线控制点
        /// </summary>
        /// <param name="p0">贝塞尔曲线起点</param>
        /// <param name="p2">贝塞尔曲线终点</param>
        /// <param name="p">曲线上的点</param>
        /// <param name="t">p点对应的t</param>
        public static PointF GetQuadraticCurveControlPoint(PointF p0, PointF p2, PointF p, float t)
        {
            //𝑃1 = (𝑃(t)−(1-t)*(1-t)𝑃0−t*t𝑃2)/(2*t*(1-t))
            var p1X = (p.X - (1 - t) * (1 - t) * p0.X - t * t * p2.X) / 2 / t / (1 - t);
            var p1Y = (p.Y - (1 - t) * (1 - t) * p0.Y - t * t * p2.Y) / 2 / t / (1 - t);
            return new PointF((float)p1X, (float)p1Y);
        }

        /// <summary>
        /// 获取三次贝塞尔曲线上某一点对应的t值
        /// </summary>
        /// <param name="start">贝塞尔曲线起点</param>
        /// <param name="control1">贝塞尔曲线控制点1</param>
        /// <param name="control2">贝塞尔曲线控制点2</param>
        /// <param name="end">贝塞尔曲线终点</param>
        /// <param name="pt">曲线上已知点</param>
        /// <param name="alpha">误差，默认1</param>
        /// <param name="time">t分割次数，默认10000</param>
        public static float GetCubicCurvePointT(PointF start, PointF control1, PointF control2, PointF end, PointF pt, float alpha = 1F, int time = 10000)
        {
            for (var i = 0; i <= time; i++)
            {
                var t = (float)i / time;
                var p = GetCubicCurvePoint(start, control1, control2, end, t);
                if (DistanceCalc.GetDistance(pt, p) <= alpha) return t;
            }
            return -1;
        }
    }
}
