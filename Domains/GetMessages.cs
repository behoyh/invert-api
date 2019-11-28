using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using invert_api.Models;
using invert_api.Models.Response;
using invert_api.Repositories;

namespace invert_api.Domains
{
    public class GetMessages
    {
        GetMessagesRepository _getMessagesRepository;
        public GetMessages(GetMessagesRepository getMessagesRepository)
        {
            _getMessagesRepository = getMessagesRepository;
        }

        public async Task<Response<MessagesResponse>> GetAllMesssges(string uid, params MessageType[] messageTypes)
        {
            var result = await _getMessagesRepository.GetAllMessagesAsync();

            if (!result.Success)
            {
                return new Response<MessagesResponse>("Error Getting Messages");
            }

            var messages = result.Data;

            messages = await GetTargetedMesages(uid, messages);

            var messagesResponse = new MessagesResponse()
            {
                Banner = GetPriorityMessageOfType(messages.Where(x => x.TYPE == messageTypes[0])),
                Popup = GetPriorityMessageOfType(messages.Where(x => x.TYPE == messageTypes[1])),
                Acknowledgment = GetPriorityMessageOfType(messages.Where(x => x.TYPE == messageTypes[2])),
                Marketing = messages.Where(x => x.TYPE == messageTypes[3]).Take(3).ToList()
            };

            return new Response<MessagesResponse>(messagesResponse);
        }

        private async Task<IEnumerable<MESSAGE>> GetTargetedMesages(string uid, IEnumerable<MESSAGE> messages)
        {
            var combinedMessages = new List<MESSAGE>();

           var targets = await _getMessagesRepository.GetTargetedMessagesForUserAsync(uid);

            if (!targets.Data.Any())
            {
                return messages.Where(x => x.ISTARGETED == false);
            }

            var targetedMessages = messages.Where(x => x.ISTARGETED && targets.Data.Where(y => y.MessageID == x.ID && !y.ACKNOWLEDGED).Any());

            combinedMessages.AddRange(messages.Where(x => x.ISTARGETED == false));
            combinedMessages.AddRange(targetedMessages);

            return combinedMessages;
        }

        private MESSAGE GetPriorityMessageOfType(IEnumerable<MESSAGE> messages)
        {
            // Priority Queue: standard->targeted->urgent->targeted urgent

            var targetedUrgent = messages.OrderByDescending(x => x.ENDDATE).Where(x => x.URGENT && x.ISTARGETED).FirstOrDefault();

            if (targetedUrgent!=null)
            {
                return targetedUrgent;
            }

            var urgent = messages.OrderByDescending(x => x.ENDDATE).Where(x => x.URGENT).FirstOrDefault();

            if (urgent != null)
            {
                return urgent;
            }

            var targeted = messages.OrderByDescending(x => x.ENDDATE).Where(x => x.ISTARGETED).FirstOrDefault();

            if (targeted != null)
            {
                return targeted;
            }

            return messages.FirstOrDefault();
        }
    }
}
