using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace invert_api.controllertests
{
    public class BlobControllerTests : IClassFixture<Fixture>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BlobControllerTests(Fixture factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Can_Upload_Image_Success()
        {
            var client = _factory.CreateClient();

            var requestContent = new ByteArrayContent(await File.ReadAllBytesAsync(Environment.CurrentDirectory + "/avatar.png"));

            requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");

            var response = await client.PutAsync("/api/Blob?type=1", requestContent);

            response.IsSuccessStatusCode.Should().BeTrue();

            var content = await response.Content.ReadAsStringAsync();

            long.Parse(content).Should().BeGreaterThan(0);
        }
    }
}
