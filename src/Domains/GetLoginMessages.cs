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

        public async Task<Response<LoginMessageResponse>> GetAllMessages()
        {
            var result = await _messageRepository.GetLoginMessagesAsync();

            if (!result.Success)
            {
                return new Response<LoginMessageResponse>(result.Error);
            }

            LoginMessageResponse message = new LoginMessageResponse();

            var loginMessages = result.Data.ToList();

            foreach (var m in loginMessages)
            {
                if (m.EndTime != null)
                {
                    if (m.EndTime > DateTime.Now)
                    {
                        continue;
                    }
                }

                if (m.StartTime != null)
                {
                    if (m.StartTime < DateTime.Now)
                    {
                        continue;
                    }
                }

                if(m.TYPE == LoginMessageType.Blocked)
                {
                    message.android.alert.blocking = m.Android_Blocked;
                    message.ios.alert.blocking = m.Ios_Blocked;
                }
                if (m.TYPE == LoginMessageType.OptionalUpdate)
                {
                    message.android.optionalUpdate.optionalVersion = m.AndroidVersion;
                    message.ios.optionalUpdate.optionalVersion = m.IosVersion;
                }
                if (m.TYPE == LoginMessageType.RequiredUpdate)
                {
                    message.android.requiredUpdate.minimumVersion = m.AndroidVersion;
                    message.ios.requiredUpdate.minimumVersion = m.IosVersion;
                }
                message.android.alert.message = m.AndroidMessage;
                message.ios.alert.message = m.AndroidMessage;
            }


            return new Response<LoginMessageResponse>(message);
        }
    }
}
