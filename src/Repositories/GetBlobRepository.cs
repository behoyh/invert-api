using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using invert_api.Infrastructure;
using invert_api.Models;
using invert_api.Models.Response;
using Microsoft.Extensions.Configuration;

namespace invert_api.Repositories
{
    public class GetBlobRepository
    {
        private readonly string _connectionString;
        public GetBlobRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public async Task<Response<BLOB>> GetBlobAsync(long blobId)
        {
            var query = "SELECT * FROM BLOBS WHERE ID = @Id";

            BLOB blobInfo;
            using (var context = DbContextFactory.GetContext(_connectionString))
            {
                blobInfo = await context.QueryFirstOrDefaultAsync<BLOB>(query, new { Id = blobId });
            }

            if (blobInfo == null)
            {
                return new Response<BLOB>("Query returned no results");
            }

            return new Response<BLOB>(blobInfo);
        }
    }
}
