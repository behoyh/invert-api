using System;
using Microsoft.Extensions.Configuration;

namespace invert_api.Infrastructure
{
    public class InteractiveMessagesContextFactory : IDisposable
    {
        private readonly InteractiveMessagesContext _interactiveMessagesContext;
        public InteractiveMessagesContextFactory(IConfiguration configuration)
        {
            _interactiveMessagesContext = new InteractiveMessagesContext();
            _interactiveMessagesContext.ConnectionString = configuration.GetConnectionString("TargetDB");
        }

        public InteractiveMessagesContext GetContext()
        {
            return _interactiveMessagesContext;
        }

        public void Dispose()
        {
            _interactiveMessagesContext.Close();
            _interactiveMessagesContext.Dispose();
        }
    }
}
