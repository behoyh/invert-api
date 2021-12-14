using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentAssertions;
using invert_api.Models;
using invert_api.Models.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace invert_api.controllertests
{
    public class MessagesControllerTests : IClassFixture<Fixture>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public MessagesControllerTests(Fixture factory)
        {
            _factory = factory;
        }

        [Fact]
        // Needs a sql server to run. for docker, run
        //sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" \
        //    -p 1433:1433 --name sql1 -h sql1 \
        //    -d mcr.microsoft.com/mssql/server:2019-latest
        public async Task GetMessages_Returns_Correct_JSON_Format()
        {
            await AddMessages_Success();
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/messages/all");
            var contentStream = await response.Content.ReadAsStreamAsync();

            var MessageList = await JsonSerializer.DeserializeAsync<List<AcceptedFormatMessage>>(contentStream);

            MessageList.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task AddMessages_Empty_FailsWithCorrectMessage()
        {
            var client = _factory.CreateClient();

            var stringRequest = new StringContent(JsonSerializer.Serialize(""));
            stringRequest.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = await client.PostAsync("/api/messages/update", stringRequest);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("Message is not specified.");
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task<long> AddMessages_Success()
        {
            var client = _factory.CreateClient();

            var requestObj = new Request<AcceptedFormatMessage>();

            requestObj.Data = new AcceptedFormatMessage()
            {
                Active = true,
                BlobId = 0,
                Body = "hello",
                StartDate = DateTime.Now,
                Created = DateTime.Now,
                EndDate = DateTime.Now,
                Title = "hello",
                Type = MessageType.Banner,
                Modified = DateTime.Now
            };

            var stringRequest = new StringContent(JsonSerializer.Serialize(requestObj));
            stringRequest.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = await client.PostAsync("/api/messages/update", stringRequest);

            var content = await response.Content.ReadAsStringAsync();

            var id = long.Parse(content);

            id.Should().BeGreaterThan(0);
            response.IsSuccessStatusCode.Should().BeTrue();

            return id;
        }

        [Fact]
        public async Task AddMessages_Fails_IfDateIsNotEpoch()
        {
            var client = _factory.CreateClient();

            var requestObj = new Request<AcceptedFormatMessage>();

            requestObj.Data = new AcceptedFormatMessage()
            {
                Active = true,
                BlobId = 0,
                Body = "hello",
                StartDate = DateTime.Now,
                Created = DateTime.Now,
                EndDate = DateTime.Now,
                Title = "hello",
                Type = MessageType.Banner,
                Modified = DateTime.MinValue
            };

            var stringRequest = new StringContent(JsonSerializer.Serialize(requestObj));
            stringRequest.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = await client.PostAsync("/api/messages/update", stringRequest);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("SqlDateTime overflow. Must be between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM.");
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        private class AcceptedFormatMessage
        {
            public long Id { get; set; }
            public MessageType Type { get; set; }
            public bool Active { get; set; }
            public bool Urgent { get; set; }
            public bool IsTargeted { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public string Link { get; set; }
            public long BlobId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public DateTime Created { get; set; }
            public DateTime Modified { get; set; }
        }
    }
}
