using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Drawing;
using System.Drawing.Imaging;

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
        public async Task Can_Upload_And_Get_Image_Success()
        {
            var client = _factory.CreateClient();

            var requestContent = new ByteArrayContent(await File.ReadAllBytesAsync(Environment.CurrentDirectory + "/avatar.png"));

            requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");

            var response = await client.PutAsync("/api/Blob?type=1", requestContent);

            response.IsSuccessStatusCode.Should().BeTrue();

            var content = await response.Content.ReadAsStringAsync();

            long.Parse(content).Should().BeGreaterThan(0);

            await GetImage(long.Parse(content));
        }

        private async Task GetImage(long blobId)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/Blob?blobid=" + blobId);

            response.IsSuccessStatusCode.Should().BeTrue();

            var bytes = await response.Content.ReadAsByteArrayAsync();

            bytes.Length.Should().BeGreaterThan(0);

            ImageConverter converter = new ImageConverter();
            Image image = (Image)converter.ConvertFrom(bytes);
            image.Save(Environment.CurrentDirectory + "/avatar2.png", ImageFormat.Png);  
        }
    }
}
