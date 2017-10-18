using System.Threading.Tasks;
using NUnit.Framework;

namespace WebUntisNet.Tests
{
    public class UntisClientTest
    {
        [Test]
        public void LoginAndLogout()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Schueler", "");
            Assert.IsTrue(client.IsLoggedIn);
            client.Dispose();
            Assert.IsFalse(client.IsLoggedIn);
        } 

    }
}
