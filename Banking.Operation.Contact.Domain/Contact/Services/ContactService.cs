using Banking.Operation.Client.Domain.Client.Services;
using Banking.Operation.Contact.Domain.Abstractions.Exceptions;
using Banking.Operation.Contact.Domain.Contact.Dtos;
using Banking.Operation.Contact.Domain.Contact.Entities;
using Banking.Operation.Contact.Domain.Contact.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Domain.Contact.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IClientService _clientService;

        public ContactService(IContactRepository contactRepository, IClientService clientService)
        {
            _contactRepository = contactRepository;
            _clientService = clientService;
        }

        public async Task<List<ResponseContactDto>> GetAll(Guid clientid)
        {

            await ValidateClient(clientid);

            var queryables = _contactRepository.Get();

            var contactList = queryables.Where(c => c.Client.Id == clientid);

            return contactList.Select(c => new ResponseContactDto(c)).ToList();
        }

        private async Task<ClientEntity> ValidateClient(Guid clientid)
        {
            var client = await _clientService.GetOne(clientid);

            if (client is null)
            {
                throw new BussinessException("Operation not performed", "Client not registered");
            }

            return client;
        }

        public async Task<ResponseContactDto> GetOne(Guid clientid, Guid id)
        {
            await ValidateClient(clientid);

            var contact = await _contactRepository.FindOne(c => c.Client.Id == clientid && c.Id == id);

            return new ResponseContactDto(contact);
        }

        public async Task<ResponseContactDto> Save(Guid clientid, RequestContactDto contact)
        {
            var client = await ValidateClient(clientid);

            var contactEntity = new ContactEntity(contact.Name, client);

            if (await _contactRepository.FindOne(c => c.Client.Id == clientid && c.Name == contact.Name) != null)
            {
                throw new BussinessException("Operation not performed", "Contact already registered");
            }

            await _contactRepository.Add(contactEntity);

            var contactDto = new ResponseContactDto(contactEntity);

            return contactDto;
        }

        public async Task<ResponseContactDto> Update(Guid clientid, Guid id, RequestContactDto contact)
        {
            await ValidateClient(clientid);

            var contactEntity = await _contactRepository.FindOne(c => c.Client.Id == clientid && c.Id == id);

            contactEntity.Name = contact.Name;

            _contactRepository.Update(contactEntity);

            return new ResponseContactDto(contactEntity);
        }

        public async Task Delete(Guid clientid, Guid id)
        {
            await ValidateClient(clientid);

            var contact = await _contactRepository.FindOne(c => c.Client.Id == clientid && c.Id == id);

            if (contact is null)
            {
                return;
            }

            _contactRepository.Delete(contact);
        }
    }
}
