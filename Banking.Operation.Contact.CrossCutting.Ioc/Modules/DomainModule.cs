using Banking.Operation.Contact.Domain.Contact.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Net.Core.Template.CrossCutting.Ioc.Modules
{
    [ExcludeFromCodeCoverage]
    public static class DomainModule
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
