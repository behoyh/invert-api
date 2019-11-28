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

        public async Task<Response<MessagesResponse>> GetMesssgesForUser(string uid, params MessageType[] messageTypes)
        {
            var result = await _getMessagesRepository.GetAllMessagesAsync();

            if (!result.Success)
            {
                return new Response<MessagesResponse>("Error Getting Messages");
            }

            var messages = result.Data;

            messages = await GetTargetedMesages(uid, messages);

            var messageTypesList = new Queue<MessageType>(messageTypes);


            var response = new MessagesResponse();

            while (messageTypesList.Any())
            {
                response.Banner = GetPriorityMessageOfType(messages.Where(x => x.TYPE == messageTypesList.Dequeue()));
                response.Popup = GetPriorityMessageOfType(messages.Where(x => x.TYPE == messageTypesList.Dequeue()));
                response.Acknowledgment = GetPriorityMessageOfType(messages.Where(x => x.TYPE == messageTypesList.Dequeue()));
                response.Marketing = messages.Where(x => x.TYPE == messageTypesList.Dequeue()).Take(3).ToList();
                // Add more if needed.
                break;
            }

            var messagesResponse = response;

            return new Response<MessagesResponse>(messagesResponse);
        }

        public async Task<Response<List<MESSAGE>>> GetAllMesssges()
        {
            var result = await _getMessagesRepository.GetAllMessagesAsync();

            if (!result.Success)
            {
                return new Response<List<MESSAGE>>("Error Getting Messages");
            }

            return new Response<List<MESSAGE>>(result.Data.ToList());
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
