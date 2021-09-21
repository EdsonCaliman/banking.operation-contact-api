using Banking.Operation.Contact.Domain.Contact.Dtos;
using Banking.Operation.Contact.Domain.Contact.Entities;
using Banking.Operation.Contact.Domain.Contact.Repositories;
using Banking.Operation.Contact.Domain.Contact.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Tests.Contact.Services
{
    public class ContactServiceTest
    {
        private IContactService _contactService;
        private Mock<IContactRepository> _contactRepository;
        private Mock<IClientService> _clientService;
        private ClientEntity _client;
        private int _contactAccout;

        [SetUp]
        public void SetUp()
        {
            _contactRepository = new Mock<IContactRepository>();
            _clientService = new Mock<IClientService>();
            _contactService = new ContactService(_contactRepository.Object, _clientService.Object);

            var clientId = Guid.NewGuid();
            _contactAccout = 3452;
            _client = new ClientEntity { Id = clientId, Name = "Test", Email = "test", Account = 1324 };
            _clientService.Setup(c => c.GetOne(clientId)).Returns(Task.FromResult(_client));
            _clientService.Setup(c => c.FindByAccount(_contactAccout)).Returns(Task.FromResult(_client));
        }

        [Test]
        public void ShouldReturnContact()
        {
            var idContact = Guid.NewGuid();
            var contact = new ContactEntity("Test", _client, _contactAccout);
            _contactRepository.Setup(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>())).Returns(Task.FromResult(contact));

            var ContactSaved = _contactService.GetOne(_client.Id, idContact);

            Assert.IsNotNull(ContactSaved);
        }

        [Test]
        public async Task ShouldReturnAllContacts()
        {
            var contactList = new List<ContactEntity> {
                new ContactEntity("Test", _client, _contactAccout),
                new ContactEntity("Test", _client, _contactAccout)
                }.AsQueryable();
            _contactRepository.Setup(c => c.Get()).Returns(contactList);

            var contactListSaved = await _contactService.GetAll(_client.Id);

            Assert.IsNotNull(contactListSaved);
            Assert.AreEqual(2, contactListSaved.Count);
        }

        [Test]
        public void ShouldSaveContact()
        {
            var contact = new RequestContactDto { Name = "test", Account = _contactAccout };

            var contactSaved = _contactService.Save(_client.Id, contact);

            Assert.IsNotNull(contactSaved);
            _contactRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>()));
            _contactRepository.Verify(c => c.Add(It.IsAny<ContactEntity>()));
        }

        [Test]
        public async Task ShouldUpdateContact()
        {
            var idContact = Guid.NewGuid();
            var contact = new RequestContactDto { Name = "test" };
            var contactSaved = new ContactEntity("other", _client, _contactAccout);
            _contactRepository.Setup(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>())).Returns(Task.FromResult(contactSaved));

            var ContactUpdated = await _contactService.Update(_client.Id, idContact, contact);

            Assert.IsNotNull(ContactUpdated);
            Assert.AreEqual(contact.Name, ContactUpdated.Name);
            _contactRepository.Verify(c => c.Update(It.IsAny<ContactEntity>()));
        }

        [Test]
        public void ShouldDeleteContact()
        {
            var idContact = Guid.NewGuid();
            var contact = new ContactEntity { Name = "Test", Client = _client, Id = idContact };
            _contactRepository.Setup(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>())).Returns(Task.FromResult(contact));

            _contactService.Delete(_client.Id, idContact);

            _contactRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>()));
            _contactRepository.Verify(c => c.Delete(It.IsAny<ContactEntity>()));
        }

        [Test]
        public void ShouldNotDeleteInexistentContact()
        {
            var idContact = Guid.NewGuid();

            _contactService.Delete(_client.Id, idContact);

            _contactRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>()));
            _contactRepository.Verify(c => c.Delete(It.IsAny<ContactEntity>()), Times.Never);
        }
    }
}
