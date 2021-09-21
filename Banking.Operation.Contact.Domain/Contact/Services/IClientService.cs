using Banking.Operation.Contact.Domain.Contact.Entities;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Domain.Contact.Services
{
    public interface IClientService
    {
        Task<ClientEntity> GetOne(Guid id);

        Task<ClientEntity> FindByAccount(int account);
    }
}
