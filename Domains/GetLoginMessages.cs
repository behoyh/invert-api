using System;
using System.Linq;
using System.Threading.Tasks;
using invert_api.Models;
using invert_api.Models.Response;
using invert_api.Repositories;

namespace invert_api.Domains
{
    public class GetLoginMessages
    {
        private readonly GetLoginMessageRepository _messageRepository;
        public GetLoginMessages(GetLoginMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Response<LoginMessage>> GetAllMessages()
        {
            var result = await _messageRepository.GetLoginMessagesAsync();

            if (!result.Success)
            {
                return new Response<LoginMessage>(result.Error);
            }

            LoginMessage message = new LoginMessage();

            var loginMessages = result.Data.ToList();

            foreach (var m in loginMessages)
            {
                if (m.ENDTIME != null)
                {
                    if (m.ENDTIME > DateTime.Now)
                    {
                        continue;
                    }
                }

                if (m.STARTTIME != null)
                {
                    if (m.STARTTIME < DateTime.Now)
                    {
                        continue;
                    }
                }

                if(m.TYPE == LoginMessageType.Blocked)
                {

                }
                if (m.TYPE == LoginMessageType.OptionalUpdate)
                {

                }
                if (m.TYPE == LoginMessageType.Re)
                {

                }
            }


            return new Response<LoginMessage>(message);
        }
    }
}
