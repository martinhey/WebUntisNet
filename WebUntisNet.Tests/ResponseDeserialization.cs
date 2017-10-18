using System;
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

        [Test]
        public async Task CanDeserializeGetTeachersResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":[{\"id\":1,\"name\":\"Bach\",\"foreName\":\"Ingeborg\",\"longName\":\"Bachmann\",\"foreColor\":\"000000\",\"backColor\":\"000000\"},{\"id\":2,\"name\":\"Foss\",\"foreName\":\"Dian\",\"longName\":\"Fossey\",\"foreColor\":\"000000\",\"backColor\":\"000000\"}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetTeachersAsync(new TeachersRequest(), "session");

            Assert.IsTrue(result.result.Count == 2);
            Assert.IsTrue(result.result[0].name == "Bach");
            Assert.IsTrue(result.result[0].longName == "Bachmann");
            Assert.IsTrue(result.result[1].longName == "Fossey");
        }

        [Test]
        public async Task CanDeserializeGetStudentsResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"1\",\"result\":[{\"id\":1,\"key\":\"1234567\",\"name\":\"MüllerAle\",\"foreName\":\"Alexander\",\"longName\":\"Müller\",\"gender\":\"male\"},{\"id\":2,\"key\":\"7654321\",\"name\":\"SchmidAme\",\"foreName\":\"Amelie\",\"longName\":\"Schmidt\",\"gender\":\"female\"}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetStudentsAsync(new StudentsRequest(), "session");

            Assert.IsTrue(result.result.Count == 2);
            Assert.IsTrue(result.result[0].name == "MüllerAle");
            Assert.IsTrue(result.result[0].longName == "Müller");
            Assert.IsTrue(result.result[1].longName == "Schmidt");
        }
    }
}
