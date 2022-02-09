using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ApiTestingFramework.Interfaces;
using NUnit.Framework;
using RestSharp.Deserializers;
using Console = System.Console;

namespace ApiTestingFramework
{
    [TestFixture]
    public class ExTest: BaseClient
    {
        [Test]
        public void JustTesting()
        {
            Console.WriteLine("Test");
            Assert.Pass("This test passed");
        }

        public ExTest(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger, string baseUrl) : base(cache, serializer, errorLogger, baseUrl)
        {
        }
    }
}
