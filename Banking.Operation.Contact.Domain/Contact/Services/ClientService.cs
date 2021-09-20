using Banking.Operation.Client.Domain.Client.Services;
using Banking.Operation.Contact.Domain.Contact.Entities;
using Banking.Operation.Contact.Domain.Contact.Repositories;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Domain.Contact.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientEntity> GetOne(Guid id)
        {
            return await _clientRepository.FindOne(c => c.Id == id);
        }
    }
}
