using System.Security.Cryptography;
using System.Text;

namespace CommonLibraries.String
{
    public static class Cryptography
    {
        /// <summary>
        /// HmacSHA256 运算
        /// </summary>
        /// <param name="secret">待计算内容</param>
        /// <param name="signKey">秘钥</param>
        /// <param name="ishex">默认返回hex格式string，false则为base64</param>
        /// <returns>运算结果</returns>
        public static string HmacSHA256(this string secret, string signKey, bool ishex = true)
        {
            string signRet = string.Empty;
            using (HMACSHA256 mac = new HMACSHA256(Encoding.UTF8.GetBytes(signKey)))
            {
                byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(secret));
                signRet = ishex ? hash.ToHexString() : hash.ToUrlSafeBase64();
            }
            return signRet;
        }

        /// <summary>
        /// MD5 计算
        /// </summary>
        /// <param name="str">待计算字符</param>
        /// <param name="isUpper">是否是大写</param>
        /// <param name="isBig">是否是32位，否则为16位</param>
        /// <returns>计算结果</returns>
        public static string MD5(this string str, bool isUpper = false, bool isBig = true)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                var strResult = isBig ? BitConverter.ToString(result) : BitConverter.ToString(result, 4, 8);
                return isUpper ? strResult.Replace("-", "") : strResult.Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// SHA1 计算
        /// </summary>
        /// <param name="str">待计算字符</param>
        /// <param name="isUpper">是否是大写</param>
        /// <returns>计算结果</returns>
        public static string SHA1(this string str,bool isUpper = false)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                var result = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
                var strResult = BitConverter.ToString(result);
                return isUpper ? strResult.Replace("-", "") : strResult.Replace("-", "").ToLower();
            }
        }

    }
}
