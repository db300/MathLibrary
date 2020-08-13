using System;
using System.Collections.Generic;
using System.Text;

namespace iHawkMathStdLibrary
{
    /// <summary>
    /// 单位换算
    /// </summary>
    public static class UnitConverter
    {
        /// <summary>
        /// 像素(px)转换成厘米(cm)
        /// </summary>
        /// <param name="px">像素值</param>
        /// <param name="dpi">分辨率</param>
        /// <returns>厘米值</returns>
        public static float Px2Cm(float px, float dpi)
        {
            return (float) (px / dpi * 2.539999918);
        }
    }
}
