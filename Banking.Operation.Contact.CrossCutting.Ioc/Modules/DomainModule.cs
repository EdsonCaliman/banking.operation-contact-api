using Banking.Operation.Contact.Domain.Contact.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Net.Core.Template.CrossCutting.Ioc.Modules
{
    public static class DomainModule
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
