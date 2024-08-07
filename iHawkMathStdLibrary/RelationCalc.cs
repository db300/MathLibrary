﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 关系计算器
    /// </summary>
    public static class RelationCalc
    {
        /// <summary>
        /// 判断点在线段区域内
        /// </summary>
        /// <param name="pt1">线段端点1</param>
        /// <param name="pt2">线段端点2</param>
        /// <param name="pt0">待判断点</param>
        /// <returns>判断结果，true为在线段区域内，反之则为false</returns>
        public static bool PointInLineSegment(PointF pt1, PointF pt2, PointF pt0)
        {
            return (pt0.X >= Math.Min(pt1.X, pt2.X) && pt0.X <= Math.Max(pt1.X, pt2.X) && pt0.Y >= Math.Min(pt1.Y, pt2.Y) && pt0.Y <= Math.Max(pt1.Y, pt2.Y))
                || (Math.Abs(pt1.X - pt2.X) <= 0 && pt0.Y >= Math.Min(pt1.Y, pt2.Y) && pt0.Y <= Math.Max(pt1.Y, pt2.Y) && Math.Abs(pt0.X - pt1.X) <= 5)
                || (Math.Abs(pt1.Y - pt2.Y) <= 0 && pt0.X >= Math.Min(pt1.X, pt2.X) && pt0.X <= Math.Max(pt1.X, pt2.X) && Math.Abs(pt0.Y - pt1.Y) <= 5);
        }

        /// <summary>
        /// 判断点是否在多边形内（包含点在多边形上）
        /// </summary>
        /// <param name="p">待判断的点</param>
        /// <param name="polygonPointList">多边形的点序列</param>
        /// <returns>判断结果，true为在多边形内或多边形上，反之则为false</returns>
        public static bool PointInPolygon(PointF p, List<PointF> polygonPointList)
        {
            if (polygonPointList.Any(point => Math.Abs(p.X - point.X) <= 0 && Math.Abs(p.Y - point.Y) <= 0)) return true;
            var crossCount = 0; //交点个数
            for (var i = 0; i < polygonPointList.Count; i++)
            {
                var p1 = polygonPointList[i];
                var p2 = polygonPointList[(i + 1) % polygonPointList.Count]; //最后一个点的下一点为起始点
                //求解y=p.Y与p1p2的交点
                //p1p2与y=p.y平行，或者交点在p1p2延长线或反向延长线上 
                if (Math.Abs(p1.Y - p2.Y) <= 0 || p.Y < Math.Min(p1.Y, p2.Y) || p.Y >= Math.Max(p1.Y, p2.Y)) continue;
                //求交点的X坐标
                double x = (p.Y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;
                if (x > p.X) crossCount++; //只统计单边交点 
            }

            return crossCount % 2 == 1; //单边交点为偶数，点在多边形之外
        }
    }
}
