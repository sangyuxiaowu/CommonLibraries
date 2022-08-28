using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommonLibraries.String
{
    public static class JWT_HS256
    {
        /// <summary>
        /// 生成jwt的token
        /// </summary>
        /// <param name="jwtPayLoad">
        /// PayLoad 对象
        /// new
        /// {
        ///     iat = DateTime.Now,
        ///     expire = DateTime.Now.AddMinutes(15),
        ///     role = "admin",
        /// }
        /// </param>
        /// <param name="_jwtSecret">jwt 签名秘钥</param>
        /// <returns>JWT token</returns>
        public static string MakeToken(object jwtPayLoad, string _jwtSecret = "")
        {
            return MakeToken(JsonSerializer.Serialize(jwtPayLoad), _jwtSecret);
        }
        
        
        /// <summary>
        /// 生成jwt的token
        /// </summary>
        /// <param name="jwtPayLoadJson">json字符串</param>
        /// <param name="_jwtSecret">jwt 签名秘钥</param>
        /// <returns></returns>
        public static string MakeToken(string jwtPayLoadJson, string _jwtSecret = "")
        {
            //表头的处理 
            string headerBase64Url = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}".ToUrlSafeBase64();
            //PayLoad的处理
            string payloadBase64Url = jwtPayLoadJson.ToUrlSafeBase64();
            //Sign的处理
            string sign = $"{headerBase64Url}.{payloadBase64Url}".HmacSHA256(_jwtSecret, false);
            //最终的jwt字符串
            return $"{headerBase64Url}.{payloadBase64Url}.{sign}";
        }

        /// <summary>
        /// 验证签名是否一致
        /// </summary>
        /// <param name="jwtStr">待验jwt字符串</param>
        /// <param name="_jwtSecret">验证结果</param>
        /// <returns></returns>
        public static bool ValiToken(string jwtStr, string _jwtSecret = "")
        {
            var items = jwtStr.Split('.');
            // 若不是3个字段，则不是jwt数据，返回验证失败
            if (items.Length != 3) return false;
            // 计算签名
            string sign = $"{items[0]}.{items[1]}".HmacSHA256(_jwtSecret, false);
            return sign == items[2];
        }


    }
}
