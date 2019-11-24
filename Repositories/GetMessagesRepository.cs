using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using invert_api.Infrastructure;
using invert_api.Models;
using invert_api.Models.Response;

namespace invert_api.Repositories
{
    public class GetMessagesRepository
    {
        private readonly InteractiveMessagesContextFactory _interactiveMessagesContextFactory;
        public GetMessagesRepository(InteractiveMessagesContextFactory interactiveMessagesContextFactory)
        {
            _interactiveMessagesContextFactory = interactiveMessagesContextFactory;
        }

        public async Task<Response<IEnumerable<MESSAGE>>> GetAllMessagesAsync()
        {
            IEnumerable<MESSAGE> messages;
            using (var context = _interactiveMessagesContextFactory.GetContext())
            {
                messages = await context.QueryAsync<MESSAGE>("SELECT ACTIVE = 1");
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

            using (var context = _interactiveMessagesContextFactory.GetContext())
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
