using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using invert_api.Domains;
using invert_api.Models;
using invert_api.Models.Request;
using invert_api.Models.Response;

namespace invert_api.Services
{
    public class MessagesService
    {

        private readonly GetMessages _getMessages;
        private readonly AddOrUpdateMessage _addOrUpdateMessage;

        public MessagesService(GetMessages getMessages, AddOrUpdateMessage addOrUpdateMessage)
        {
            _getMessages = getMessages;
            _addOrUpdateMessage = addOrUpdateMessage;
        }

        public async Task<Response<MessagesResponse>> GetMessagesForUser(string uid)
        {
            var messages = await _getMessages.GetMesssgesForUser(uid,
                new MessageType[]
                {
                   MessageType.Banner,
                   MessageType.Popup,
                   MessageType.Acknowledgement,
                   MessageType.Marketing
                });

            if (!messages.Success)
            {
                return new Response<MessagesResponse>(messages.Error);
            }

            return new Response<MessagesResponse>(messages.Data);
        }

        public async Task<Response<List<MESSAGE>>> GetAllMessages()
        {
            var messages = await _getMessages.GetAllMesssges();

            if (!messages.Success)
            {
                return new Response<List<MESSAGE>>(messages.Error);
            }

            return new Response<List<MESSAGE>>(messages.Data);
        }

        public async Task<Response<MESSAGE>> GetMessage(long messageId)
        {
            Response<MESSAGE> message = await _getMessages.GetMesssge(messageId);

            if (!message.Success)
            {
                return new Response<MESSAGE>(message.Error);
            }

            return new Response<MESSAGE>(message.Data);
        }

        public async Task<Response<long>> AddOrUpdateMessage(MESSAGE message)
        {
            var result = await _addOrUpdateMessage.AddOrUpdateAsync(message);

            if (!result.Success)
            {
                return new Response<long>(result.Error);
            }

            return new Response<long>(result.Data);
        }

        public async Task<Response> AddTargetedList(TargetRequest targets)
        {
            var result = await _addOrUpdateMessage.AddTargetedList(targets);

            if (!result.Success)
            {
                return new Response(result.Error);
            }

            return new Response();
        }
    } 
}
