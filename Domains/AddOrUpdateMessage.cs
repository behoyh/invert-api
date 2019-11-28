using System.Collections.Generic;
using System.Threading.Tasks;
using invert_api.Models;
using invert_api.Models.Response;
using invert_api.Repositories;

namespace invert_api.Domains
{
    public class AddOrUpdateMessage
    {
        private readonly InsertMessageRepository _insertMessageRepository;
        private readonly UpdateMessageRepository _updateMessageRepository;

        public AddOrUpdateMessage(InsertMessageRepository insertMessageRepository, UpdateMessageRepository updateMessageRepository)
        {
            _insertMessageRepository = insertMessageRepository;
            _updateMessageRepository = updateMessageRepository;
        }

        public async Task<Response<long>> AddOrUpdateAsync(MESSAGE message)
        {
            long Id;

            if (message.ID >= 0)
            {
                var result = await _insertMessageRepository.UploadMessageAsync(message);

                if (!result.Success)
                {
                    return new Response<long>(result.Error);
                }

                Id = result.Data;
            }
            else
            {
                var result = await _updateMessageRepository.UpdateMessageAsync(message);

                if (!result.Success)
                {
                    return new Response<long>(result.Error);
                }

                Id = result.Data;
            }

            return new Response<long>(Id);
        }

        public async Task<Response> AddTargetedList(List<TARGET_MESSAGE> targets)
        {
            var result = await _insertMessageRepository.UploadTargetedListAsync(targets);

            if(!result.Success)
            {
                return new Response(result.Error);
            }

            return new Response();
        }
    }
}
