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
    public class GetMessagesRepository
    {
        private readonly string _connectionString;
        public GetMessagesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Master");
        }

        public async Task<Response<IEnumerable<MESSAGE>>> GetAllMessagesAsync()
        {
            var query = $"SELECT * FROM MESSAGES WHERE ACTIVE = 1 AND ENDDATE > @Date";

            IEnumerable<MESSAGE> messages;
            using (var context = InteractiveMessagesFactory.GetContext(_connectionString))
            {
                messages = await context.QueryAsync<MESSAGE>(query, new { Date = DateTime.Now });
            }

            if (messages == null)
            {
                return new Response<IEnumerable<MESSAGE>>("Query returned no results");
            }

            return new Response<IEnumerable<MESSAGE>>(messages);
        }

        public async Task<Response<IEnumerable<TARGET_MESSAGE>>> GetTargetedMessagesForUserAsync(string Uid)
        {
            IEnumerable<TARGET_MESSAGE> targetedMessages;

            using (var context = InteractiveMessagesFactory.GetContext(_connectionString))
            {
                targetedMessages = await context.QueryAsync<TARGET_MESSAGE>("select UID = @Uid", new { Uid });
            }

            if (targetedMessages == null || !targetedMessages.Any())
            {
                return new Response<IEnumerable<TARGET_MESSAGE>>("Query returned no results");
            }

            return new Response<IEnumerable<TARGET_MESSAGE>>(targetedMessages);
        }
    }
}
