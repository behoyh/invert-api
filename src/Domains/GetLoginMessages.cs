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
                    message.android.alert.blocking = m.ANDROID_BLOCKED;
                    message.ios.alert.blocking = m.IOS_BLOCKED;
                }
                if (m.TYPE == LoginMessageType.OptionalUpdate)
                {
                    message.android.optionalUpdate.optionalVersion = m.ANDROID_VERSION;
                    message.ios.optionalUpdate.optionalVersion = m.IOS_VERSION;
                }
                if (m.TYPE == LoginMessageType.RequiredUpdate)
                {
                    message.android.requiredUpdate.minimumVersion = m.ANDROID_VERSION;
                    message.ios.requiredUpdate.minimumVersion = m.IOS_VERSION;
                }
                message.android.alert.message = m.ANDROID_MESSAGE;
                message.ios.alert.message = m.ANDROID_MESSAGE;
            }


            return new Response<LoginMessageResponse>(message);
        }
    }
}
