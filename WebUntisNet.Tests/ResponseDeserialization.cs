﻿using System;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using WebUntisNet.Net;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Tests
{
    public class ResponseDeserialization
    {
        [Test]
        public async Task CanDeserializeAuthenticationResult()
        {
            const string responseText = "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":\r\n{\"sessionId\":\"644AFBF2C1B592B68C6B04938BD26965\",\"personType\":2,\"personId\":17}}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.AuthenticateAsync("school", new AuthenticationRequest("", "", ""));

            Assert.AreEqual("644AFBF2C1B592B68C6B04938BD26965", result.result.sessionId);
            Assert.AreEqual(2, result.result.personType);
            Assert.AreEqual(17, result.result.personId);
        }
    }
}
