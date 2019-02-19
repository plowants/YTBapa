using System;
namespace YTBapa.Common.Extension
{
    public static class  Utils
    {
        /// <summary>
        /// 字符串转Int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str){
            int outNum=0;
            int.TryParse(str,out outNum);
            return outNum;
        }
    }

}