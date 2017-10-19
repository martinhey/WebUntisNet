﻿using System.Threading.Tasks;
using WebUntisNet.Net;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;
using Xunit;

namespace WebUntisNet.Tests
{
    public class WhenAuthenticateIsExecuted
    {
        [Fact]
        public async Task DataShouldBeReturned()
        {
            var client = new RpcClient(new HttpClient(), "https://demo.webuntis.com/WebUntis/jsonrpc.do");
            var request = new AuthenticationRequest("Schueler", "", "CLIENT");
            var response = await client.AuthenticateAsync("demo_inf", request);

            Assert.Null(response.error);
            Assert.NotEmpty(response.result.sessionId);
            Assert.True(response.result.personId > 0);
            Assert.True(response.result.personType > 0);
        }
    }
}
