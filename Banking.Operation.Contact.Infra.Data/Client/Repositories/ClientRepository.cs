using Banking.Operation.Contact.Domain.Contact.Entities;
using Banking.Operation.Contact.Domain.Contact.Repositories;
using Banking.Operation.Contact.Infra.Data.Repositories;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Infra.Data.Client.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ClientRepository : BaseRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(AppDbContext context)
            : base(context) { }

        public async Task<ClientEntity> FindByAccount(int account)
        {
            return await FindOne(c => c.Account == account);
        }
    }
}
