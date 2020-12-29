using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using invert_api.Infrastructure;
using invert_api.Models;
using invert_api.Models.Response;
using Microsoft.Extensions.Configuration;

namespace invert_api.Repositories
{
    public class InsertMessageRepository
    {
        private readonly string _connectionString;
        public InsertMessageRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public async Task<Response<long>> UploadMessageAsync(MESSAGE message)
        {
            int result = 0;

            using (var context = DbContextFactory.GetContext(_connectionString))
            {
                result = await context.InsertAsync(message);
            }

            if (result < 0)
            {
                return new Response<long>("Insert Message Failed.");
            }

            return new Response<long>(result);
        }

        public async Task<Response> UploadTargetedListAsync(IEnumerable<TARGET_MESSAGE> targets)
        {
            long result = 0;

            using (var context = DbContextFactory.GetContext(_connectionString))
            {
                result = await context.InsertAsync(targets);
            }

            if (result > 0)
            {
                return new Response("Insert Message Failed.");
            }

            return new Response();
        }
    }
}