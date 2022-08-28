using CommonLibraries.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class JWT_HS256Test
    {
        [Test]
        public void TestSign()
        {
            string secret = "test";
            var sc = JWT_HS256.MakeToken(new{
                sub = "1234567890",
                name = "John Doe",
                iat= 1516239022
            }, secret);
            if (sc != "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.5mhBHqs5_DTLdINd9p5m7ZJ6XD0Xc55kIaCRY5r6HRA") {
                Assert.Fail("JWT_HS256 签名 Token 失败");
            }
            Assert.Pass();
        }

        [Test]
        public void TestVT()
        {
            var secret = "test";
            var sc = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.5mhBHqs5_DTLdINd9p5m7ZJ6XD0Xc55kIaCRY5r6HRA";
            Assert.IsTrue(JWT_HS256.ValiToken(sc, secret));
        }

        [Test]
        public void TestVF()
        {
            var secret = "your-256-bit-secret";
            var sc = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.5mhBHqs5_DTLdINd9p5m7ZJ6XD0Xc55kIaCRY5r6HRA";
            Assert.IsFalse(JWT_HS256.ValiToken(sc, secret));
        }
    }
}
