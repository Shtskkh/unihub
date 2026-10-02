using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application;

public static class IdentityApplicationExtensions
{
    extension(IServiceCollection services)
    {
        public void AddIdentityApplication()
        {
            services.AddRequestHandlers();
        }

        private void AddRequestHandlers()
        {
        }
    }
}