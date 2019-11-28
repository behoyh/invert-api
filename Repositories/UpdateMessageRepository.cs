using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using invert_api.Infrastructure;
using invert_api.Models;
using invert_api.Models.Response;
using Microsoft.Extensions.Configuration;

namespace invert_api.Repositories
{
    public class UpdateMessageRepository
    {
        private readonly string _connectionString;
        public UpdateMessageRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Master");
        }

        public async Task<Response<long>> UpdateMessageAsync(MESSAGE message)
        {
            bool success = false;

            using (var context = InteractiveMessagesFactory.GetContext(_connectionString))
            {
                success = await context.UpdateAsync(message);
            }

            if (!success)
            {
                return new Response<long>("Insert Message Failed.");
            }

            return new Response<long>(message.ID);
        }
    }
}
