
using System.Text;
using CommonLibraries.String;

namespace StringTest
{
    public class UrlSafeBase64Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestString()
        {
            if("Hello Word��".UrlSafeBase64_Encode() == "SGVsbG8gV29yZO-8gQ")
            {
                Assert.Pass();
            }
            Assert.Fail("UrlSafeBase64 ����ʧ��");
        }

        [Test]
        public void TestBytesg()
        {
            if (Encoding.UTF8.GetBytes("Hello Word��").UrlSafeBase64_Encode() == "SGVsbG8gV29yZO-8gQ")
            {
                Assert.Pass();
            }
            Assert.Fail("UrlSafeBase64 ����ʧ��");
        }

        [Test]
        public void TestStringDe()
        {
            if ("SGVsbG8gV29yZO-8gQ".UrlSafeBase64_Decode() == "Hello Word��")
            {
                Assert.Pass();
            }
            Assert.Fail("UrlSafeBase64 ����ʧ��");
        }
    }
}