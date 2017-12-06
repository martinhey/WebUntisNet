using System.Threading;
using System.Threading.Tasks;
using TaurusSoftware.WebUntisNet.Types;
using Xunit;

namespace TaurusSoftware.WebUntisNet.Tests
{
    public class WhenGetTimetableIsExecuted 
    {
        [Fact]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Lehrer", "", "CLIENT");
            var result = await client.GetTimetableAsync(ElementType.Student, 1497);

            Assert.NotNull(result);
        }
    }
}