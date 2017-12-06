using Xunit;

namespace TaurusSoftware.WebUntisNet.Tests
{
    public class UntisClientTest
    {
        [Fact]
        public void LoginAndLogout()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Schueler", "");
            Assert.True(client.IsLoggedIn);
            client.Dispose();
            Assert.False(client.IsLoggedIn);
        } 

    }
}
