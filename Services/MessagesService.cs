using System;
using System.Threading.Tasks;
using invert_api.Domains;
using invert_api.Models;
using invert_api.Models.Response;

namespace invert_api.Services
{
    public class MessagesService
    {

        GetMessages _getMessages;

        public MessagesService(GetMessages getMessages)
        {
            _getMessages = getMessages;
        }

        public async Task<Response<MessagesResponse>> GetAllMessages(string uid)
        {
           var messages = await _getMessages.GetAllMesssges(uid,
               new MessageType[]
               {
                   MessageType.Banner,
                   MessageType.Popup,
                   MessageType.Acknowledgement,
                   MessageType.Marketing
               });

            if(!messages.Success)
            {
                return new Response<MessagesResponse>(messages.Error);
            }

            return new Response<MessagesResponse>(messages.Data);
        }
    }
}
