using CommonLibraries.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class BytesToolTest
    {
        [Test]
        public void TestHex()
        {
            Console.WriteLine("hello word".ToHexString(" "));
            if ("hello word".ToHexString() != "68656c6c6f20776f7264") {
                Assert.Fail("HEX字符串失败");
            }
            Assert.Pass();
        }
    }
}
