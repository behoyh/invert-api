using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using invert_api.Domains;
using invert_api.Models;
using invert_api.Models.Response;

namespace invert_api.Services
{
    public class LoginMessageService
    {
        private readonly GetLoginMessages _getLoginMessages;
        public LoginMessageService(GetLoginMessages getLoginMessages)
        {
            _getLoginMessages = getLoginMessages;
        }

        public async Task<Response<LoginMessage>> GetAllMessages()
        {
            Response<LoginMessage> result = await _getLoginMessages.GetAllMessages();

            return result;
        }

        public async Task<Response<int>> AddOrUpdateMessage(LoginMessage data)
        {
            throw new NotImplementedException();
        }
    }
}
