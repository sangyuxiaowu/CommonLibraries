using Sang.CommonLibraries.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class CryptographyTest
    {
        [Test]
        public void TestMd5()
        {
            if ("hello word".MD5(true) != "13574EF0D58B50FAB38EC841EFE39DF4") {
                Assert.Fail("md5 32位 大写计算有误");
            }
            if ("hello word".MD5() != "13574ef0d58b50fab38ec841efe39df4")
            {
                Assert.Fail("md5 32位 小写计算有误");
            }
            if ("hello word".MD5(true, false) != "D58B50FAB38EC841")
            {
                Assert.Fail("md5 16位 大写计算有误");
            }
            if ("hello word".MD5(false, false) != "d58b50fab38ec841")
            {
                Assert.Fail("md5 16位 小写计算有误");
            }
            Assert.Pass();
        }

        [Test]
        public void TestSHA1()
        {
            if ("hello word".SHA1(true) != "E0738B87E67BBFC9C5B77556665064446430E81C")
            {
                Assert.Fail("sha1 大写计算有误");
            }
            if ("hello word".SHA1() != "e0738b87e67bbfc9c5b77556665064446430e81c")
            {
                Assert.Fail("sha1 小写计算有误");
            }
            Assert.Pass();
        }

        [Test]
        public void HmacSHA256()
        {
            if ("hello word".HmacSHA256("test") != "34daab295a9c7dae94a63544d1e1b279be261552742b54f5c539b557ebaf70af") {
                Assert.Fail("HmacSHA256 HEX 计算有误");
            }
            if ("hello word".HmacSHA256("test", false) != "NNqrKVqcfa6UpjVE0eGyeb4mFVJ0K1T1xTm1V-uvcK8") {
                Assert.Fail("HmacSHA256 UrlSafe 计算有误");
            }
            Assert.Pass();
        }
    }
}
