using System;
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

        public async Task<Response<LoginMessageResponse>> GetAllMessages()
        {
            Response<LoginMessageResponse> result = await _getLoginMessages.GetAllMessages();

            return result;
        }

        public async Task<Response<int>> AddOrUpdateMessage(LoginMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
