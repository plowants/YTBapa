using System;
using System.Runtime.CompilerServices;

namespace YTBapa.Common
{
    public static class UtilityExtension
    {
        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="pam"></param>
        /// <returns></returns>
        public static int ToInt(this string pam)
        {
            int result = 0;
            int.TryParse(pam, out result);
            return result;
        }
        /// <summary>
        /// 数字保留两位小数，向上取整
        /// </summary>
        /// <param name="pam"></param>
        /// <returns></returns>
        public static Decimal ToDecimal2(this Decimal pam)
        {
            return Math.Round(pam,2,MidpointRounding.AwayFromZero);
        }
    }
}