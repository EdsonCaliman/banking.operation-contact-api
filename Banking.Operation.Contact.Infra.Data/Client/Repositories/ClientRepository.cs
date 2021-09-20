using Banking.Operation.Contact.Domain.Contact.Entities;
using Banking.Operation.Contact.Domain.Contact.Repositories;
using Banking.Operation.Contact.Infra.Data.Repositories;

namespace Banking.Operation.Contact.Infra.Data.Client.Repositories
{
    public class ClientRepository : BaseRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(AppDbContext context)
            : base(context) { }
    }
}
