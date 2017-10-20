﻿using System;
using System.Threading.Tasks;
using FakeItEasy;
using WebUntisNet.Net;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;
using Xunit;

namespace WebUntisNet.Tests
{
    public class ResponseDeserialization
    {
        [Fact]
        public async Task CanDeserializeAuthenticationResult()
        {
            const string responseText = "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":\r\n{\"sessionId\":\"644AFBF2C1B592B68C6B04938BD26965\",\"personType\":2,\"personId\":17}}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.AuthenticateAsync("school", new AuthenticationRequest("", "", ""));

            Assert.Equal("644AFBF2C1B592B68C6B04938BD26965", result.result.sessionId);
            Assert.Equal(2, result.result.personType);
            Assert.Equal(17, result.result.personId);
        }

        [Fact]
        public async Task CanDeserializeGetTeachersResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":[{\"id\":1,\"name\":\"Bach\",\"foreName\":\"Ingeborg\",\"longName\":\"Bachmann\",\"foreColor\":\"000000\",\"backColor\":\"000000\"},{\"id\":2,\"name\":\"Foss\",\"foreName\":\"Dian\",\"longName\":\"Fossey\",\"foreColor\":\"000000\",\"backColor\":\"000000\"}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetTeachersAsync(new TeachersRequest(), "session");

            Assert.True(result.result.Count == 2);
            Assert.True(result.result[0].name == "Bach");
            Assert.True(result.result[0].longName == "Bachmann");
            Assert.True(result.result[1].longName == "Fossey");
        }

        [Fact]
        public async Task CanDeserializeGetStudentsResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"1\",\"result\":[{\"id\":1,\"key\":\"1234567\",\"name\":\"MüllerAle\",\"foreName\":\"Alexander\",\"longName\":\"Müller\",\"gender\":\"male\"},{\"id\":2,\"key\":\"7654321\",\"name\":\"SchmidAme\",\"foreName\":\"Amelie\",\"longName\":\"Schmidt\",\"gender\":\"female\"}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetStudentsAsync(new StudentsRequest(), "session");

            Assert.True(result.result.Count == 2);
            Assert.True(result.result[0].name == "MüllerAle");
            Assert.True(result.result[0].longName == "Müller");
            Assert.True(result.result[1].longName == "Schmidt");
        }

        [Fact]
        public async Task CanDeserializeGetClassesResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":[{\"id\":71,\"name\":\"1A\",\"longName\":\"Klasse 1A\",\"foreColor\":\"000000\",\"backColor\":\"000000\",did:2}, {\"id\":72,\"name\":\"1B\",\"longName\":\"Klasse 1B\",\"foreColor\":\"000000\",\"backColor\":\"000000\"}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetClassesAsync(new ClassesRequest(), "session");

            Assert.True(result.result.Count == 2);
            Assert.True(result.result[0].name == "1A");
            Assert.True(result.result[0].longName == "Klasse 1A");
            Assert.True(result.result[1].longName == "Klasse 1B");
        }

        [Fact]
        public async Task CanDeserializeGetSubjectsResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":[{\"id\":1,\"name\":\"RK\",\"longName\":\"Kath.Religion\",\"foreColor\":\"000000\",\"backColor\":\"000000\"},{\"id\":2,\"name\":\"RE\",\"longName\":\"Evang. Religion\",\"foreColor\":\"000000\",\"backColor\":\"000000\"}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetSubjectsAsync(new SubjectsRequest(), "session");

            Assert.True(result.result.Count == 2);
            Assert.True(result.result[0].name == "RK");
            Assert.True(result.result[0].longName == "Kath.Religion");
            Assert.True(result.result[1].longName == "Evang. Religion");
        }

        [Fact]
        public async Task CanDeserializeGetRoomsResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":[{\"id\":1,\"name\":\"R1A\",\"longName\":\"1A\",\"foreColor\":\"000000\",\"backColor\":\"000000\"},{\"id\":2,\"name\":\"R1B\",\"longName\":\"1B\",\"foreColor\":\"000000\",\"backColor\":\"000000\"}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetRoomsAsync(new RoomsRequest(), "session");

            Assert.True(result.result.Count == 2);
            Assert.True(result.result[0].name == "R1A");
            Assert.True(result.result[0].longName == "1A");
            Assert.True(result.result[1].longName == "1B");
        }

        [Fact]
        public async Task CanDeserializeGetDepartmentsResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":[{\"id\":1,\"name\":\"A1\",\"longName\":\"AAA1\"},{\"id\":2,\"name\":\"A2\",\"longName\":\"AAA2\"}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetDepartmentsAsync(new DepartmentsRequest(), "session");

            Assert.True(result.result.Count == 2);
            Assert.True(result.result[0].name == "A1");
            Assert.True(result.result[0].longName == "AAA1");
            Assert.True(result.result[1].longName == "AAA2");
        }


        [Fact]
        public async Task CanDeserializeGetHolidaysResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":[{\"id\":44,\"name\":\"Natio\",\"longName\":\"Nationalfeiertag\",\"startDate\":20101026,\"endDate\":20101026},{\"id\":42,\"name\":\"Allerheiligen\",\"longName\":\"Allerheiligen\",\"startDate\":20101101,\"endDate\":20101101}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetHolidaysAsync(new HolidaysRequest(), "session");

            Assert.True(result.result.Count == 2);
            Assert.True(result.result[0].name == "Natio");
            Assert.True(result.result[0].longName == "Nationalfeiertag");
            Assert.True(result.result[1].longName == "Allerheiligen");
        }

        [Fact]
        public async Task CanDeserializeGetTimegridResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"ID\",\"result\":[{\"day\":0,\"timeUnits\":[{\"startTime\":800,\"endTime\":850},{\"startTime\":855,\"endTime\":945},{\"startTime\":1000,\"endTime\":1050}]}, {\"day\":1,\"timeUnits\":[{\"startTime\":800,\"endTime\":850}]}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetTimegridAsync(new TimegridRequest(), "session");

            Assert.True(result.result.Count == 2);
        }

        [Fact]
        public async Task CanDeserializeGetStatusDataResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"req-002\",\"result\":{\"lstypes\":[{\"ls\":{\"foreColor\":\"000000\",\"backColor\":\"ee7f00\"}},{\"oh\":{\"foreColor\":\"e6e3e1\",\"backColor\":\"250eee\"}},{\"sb\":{\"foreColor\":\"000000\",\"backColor\":\"1feee7\"}},{\"bs\":{\"foreColor\":\"000000\",\"backColor\":\"c03b6e\"}},{\"ex\":{\"foreColor\":\"000000\",\"backColor\":\"fdc400\"}}],\r\n\"codes\":[{\"cancelled\":{\"foreColor\":\"000000\",\"backColor\":\"b1b3b4\"}},{\"irregular\":{\"foreColor\":\"e3e33b\",\"backColor\":\"77649a\"}}]}}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetStatusDataAsync(new StatusDataRequest(), "session");

            Assert.True(result.result.lstypes.Count == 5);
        }

        [Fact]
        public async Task CanDeserializeGetCurrentSchoolYearResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"req-002\",\"result\":[{\"id\":10,\"name\":\"2010/2011\",\"startDate\":20100830,\"endDate\":20110731}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetCurrentSchoolYearAsync(new CurrentSchoolYearRequest(), "session");

            Assert.True(result.result.Count == 1);
            Assert.True(result.result[0].name == "2010/2011");
        }

        [Fact]
        public async Task CanDeserializeGetSchoolYearsResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"req-002\",\"result\":[{\"id\":10,\"name\":\"2010/2011\",\"startDate\":20100830,\"endDate\":20110731},{\"id\":11,\"name\":\"2011/2012\",\"startDate\":20110905,\"endDate\":20120729}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var result = await sut.GetSchoolYearsAsync(new SchoolYearsRequest(), "session");

            Assert.True(result.result.Count == 2);
            Assert.True(result.result[0].name == "2010/2011");
        }

        [Fact]
        public async Task CanDeserializeGetTimetableResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"req-002\",\"result\":[{\"id\":125043,\"date\":20110117,\"startTime\":800,\"endTime\":850, \"kl\":[{\"id\":71}],\"te\":[{\"id\":23}],\"su\":[{\"id\":13}],\"ro\":[{\"id\":1}]},{\"id\":125127,\"date\":20110117,\"startTime\":1055,\"endTime\":1145,\"kl\":[{\"id\":71}],\"te\":[{\"id\":41}],\"su\":[{\"id\":19}],\"ro\":[{\"id\":31}]}]}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var request = new SimpleTimetableRequest();
            request.@params.id = 71;
            request.@params.type = 1;

            var result = await sut.GetTimetableAsync(request, "session");

            Assert.True(result.result.Count == 2);
        }

        [Fact]
        public async Task CanDeserializeGetExamTypesResult()
        {
            const string responseText =
                "{\"jsonrpc\":\"2.0\",\"id\":\"req-002\",\"result\":{}}";

            var httpClient = A.Fake<IHttpClient>();
            A.CallTo(() => httpClient.SendAsync(A<Uri>._, A<string>._, A<string>._, A<int>._))
                .Returns(Task.FromResult(responseText));

            var sut = new RpcClient(httpClient, "http://localhost");
            var request = new ExamTypesRequest();

            var result = await sut.GetExamTypesAsync(request, "session");
        }
    }
}


