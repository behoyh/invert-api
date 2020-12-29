using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using invert_api.Infrastructure;
using invert_api.Models;
using invert_api.Models.Response;
using Microsoft.Extensions.Configuration;

namespace invert_api.Repositories
{
    public class GetLoginMessageRepository
    {
        private readonly string _connectionString;
        public GetLoginMessageRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

       public async Task<Response<IEnumerable<LOGIN_MESSAGE>>> GetLoginMessagesAsync()
        {
            var query = "SELECT * FROM LOGIN_MESSAGES WHERE ACTIVE = 1";

            IEnumerable<LOGIN_MESSAGE> loginMessages;
            using (var context = DbContextFactory.GetContext(_connectionString))
            {
                loginMessages = await context.QueryAsync<LOGIN_MESSAGE>(query);
            }

            if (loginMessages == null)
            {
                return new Response<IEnumerable<LOGIN_MESSAGE>>("Query returned no results");
            }

            return new Response<IEnumerable<LOGIN_MESSAGE>>(loginMessages);
        }
    }
}
