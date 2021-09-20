using Banking.Operation.Contact.Domain.Contact.Entities;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Client.Domain.Client.Services
{
    public interface IClientService
    {
        Task<ClientEntity> GetOne(Guid id);
    }
}
