using System.Text;

namespace CommonLibraries.String
{
    public static class UrlSafeBase64
    {

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="text">待编码的文本字符串</param>
        /// <returns>编码后的文本字符串</returns>
        public static string ToUrlSafeBase64(this string text)
        {
            return UrlSafeBase64_Encode(text);
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="plainTextBytes">待编码的数据</param>
        /// <returns>编码后的文本字符串</returns>
        public static string ToUrlSafeBase64(this byte[] plainTextBytes)
        {
            return UrlSafeBase64_Encode(plainTextBytes);
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="text">待编码的文本字符串</param>
        /// <returns>编码后的文本字符串</returns>
        public static string UrlSafeBase64_Encode(this string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            return plainTextBytes.UrlSafeBase64_Encode();
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="plainTextBytes">待编码的数据</param>
        /// <returns>编码后的文本字符串</returns>
        public static string UrlSafeBase64_Encode(this byte[] plainTextBytes)
        {
            return Convert.ToBase64String(plainTextBytes).Replace('+', '-').Replace('/', '_').TrimEnd('=');
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="base64UrlStr">Base64编码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static string UrlSafeBase64_Decode(this string base64UrlStr)
        {
            if (base64UrlStr == null)
            {
                return "";
            }
            base64UrlStr = base64UrlStr.Replace('-', '+').Replace('_', '/');
            switch (base64UrlStr.Length % 4)
            {
                case 2:
                    base64UrlStr += "==";
                    break;
                case 3:
                    base64UrlStr += "=";
                    break;
            }
            var bytes = Convert.FromBase64String(base64UrlStr);
            return Encoding.UTF8.GetString(bytes);
        }


    }
}