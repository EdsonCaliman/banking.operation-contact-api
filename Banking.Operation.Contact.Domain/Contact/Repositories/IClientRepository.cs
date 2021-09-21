using Banking.Operation.Contact.Domain.Abstractions.Repositories;
using Banking.Operation.Contact.Domain.Contact.Entities;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Domain.Contact.Repositories
{
    public interface IClientRepository : IBaseRepository<ClientEntity>
    {
        Task<ClientEntity> FindByAccount(int account);
    }
}
