using System;
using System.Text;

namespace Sang.CommonLibraries.String
{
    public static class BytesTool
    {
        /// <summary>
        /// String转16进制格式字符串
        /// </summary>
        /// <param name="bytes">字符串</param>
        /// <param name="join">连接符</param>
        /// <param name="isUpper">是否返回大写</param>
        /// <returns></returns>
        public static string ToHexString(this string str, string join = "", bool isUpper = false)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            return bytes.ToHexString(join, isUpper);
        }

        /// <summary>
        /// byte[]转16进制格式string
        /// </summary>
        /// <param name="bytes">bytes</param>
        ///  <param name="join">连接符</param>
        /// <param name="isUpper">是否返回大写</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes, string join = "", bool isUpper = false)
        {
            var str = join == "-" ? BitConverter.ToString(bytes) : BitConverter.ToString(bytes).Replace("-", join);
            return isUpper ? str : str.ToLower();

            /*
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                var format = isUpper ? "{0:X2}" : "{0:x2}";
                foreach (byte b in bytes)
                {
                    strB.AppendFormat(format, b);
                }
                hexString = strB.ToString();
            }
            return hexString;
            */
        }

    }
}
