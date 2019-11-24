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
        private readonly IConfiguration _configuration;
        public GetMessagesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response<IEnumerable<MESSAGE>>> GetAllMessagesAsync()
        {
            var query = "SELECT * FROM MESSAGES WHERE ACTIVE = 1;";

            IEnumerable<MESSAGE> messages;
            using (var context = InteractiveMessagesContextFactory.GetContext(_configuration.GetConnectionString("TargetDB")))
            {
                messages = await context.QueryAsync<MESSAGE>(query);
            }

            if (messages == null || !messages.Any())
            {
                return new Response<IEnumerable<MESSAGE>>("Query returned no results");
            }

            return new Response<IEnumerable<MESSAGE>>(messages);
        }

        public async Task<Response<IEnumerable<TARGET_MESSAGE>>> GetTargetedMessagesForUser(string Uid)
        {
            IEnumerable<TARGET_MESSAGE> targetedMessages;

            using (var context = InteractiveMessagesContextFactory.GetContext(_configuration.GetConnectionString("TargetDB")))
            {
                targetedMessages = await context.QueryAsync<TARGET_MESSAGE>("ENDDATE < @EndDate, UID = @Uid", new { EndDate = DateTime.Now, Uid });
            }

            if (targetedMessages == null || !targetedMessages.Any())
            {
                return new Response<IEnumerable<TARGET_MESSAGE>>("Query returned no results");
            }

            return new Response<IEnumerable<TARGET_MESSAGE>>(targetedMessages);
        }
    }
}
