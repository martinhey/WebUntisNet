﻿using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace WebUntisNet.Tests
{
    public class WhenGetCurrentSchoolYearIsExecuted 
    {
        [Fact]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Lehrer", "", "CLIENT");
            var result = await client.GetCurrentSchoolYearAsync(new CancellationToken());

            Assert.NotNull(result);
        }
    }
}