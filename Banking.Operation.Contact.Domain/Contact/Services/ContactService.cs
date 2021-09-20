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

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<ResponseContactDto> GetAll(Guid clientid)
        {
            var queryables = _contactRepository.Get();

            var contactList = queryables.Where(c => c.ClientId == clientid);

            return contactList.Select(c => new ResponseContactDto(c)).ToList();
        }

        public async Task<ResponseContactDto> GetOne(Guid clientid, Guid id)
        {
            var contact = await _contactRepository.FindOne(c => c.ClientId == clientid && c.Id == id);

            return new ResponseContactDto(contact);
        }

        public async Task<ResponseContactDto> Save(Guid clientid, RequestContactDto contact)
        {
            var contactEntity = new ContactEntity(contact.Name, clientid);


            if (await _contactRepository.FindOne(c => c.ClientId == clientid && c.Name == contact.Name) != null)
            {
                throw new BussinessException("Operation not performed", "Contact already registered");
            }

            await _contactRepository.Add(contactEntity);

            var contactDto = new ResponseContactDto(contactEntity);

            return contactDto;
        }

        public async Task<ResponseContactDto> Update(Guid clientid, Guid id, RequestContactDto contact)
        {
            var contactEntity = await _contactRepository.FindOne(c => c.ClientId == clientid && c.Id == id);

            contactEntity.Name = contact.Name;

            _contactRepository.Update(contactEntity);

            return new ResponseContactDto(contactEntity);
        }

        public async Task Delete(Guid clientid, Guid id)
        {
            var contact = await _contactRepository.FindOne(c => c.ClientId == clientid && c.Id == id);

            if (contact is null)
            {
                return;
            }

            _contactRepository.Delete(contact);
        }
    }
}
