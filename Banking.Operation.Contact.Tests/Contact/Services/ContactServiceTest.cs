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

        [SetUp]
        public void SetUp()
        {
            _contactRepository = new Mock<IContactRepository>();
            _contactService = new ContactService(_contactRepository.Object);
        }

        [Test]
        public void ShouldReturnContact()
        {
            var idClient = Guid.NewGuid();
            var idContact = Guid.NewGuid();
            var contact = new ContactEntity("Test", idClient);
            _contactRepository.Setup(c => c.FindOne(c => c.ClientId == idClient && c.Id == idContact)).Returns(Task.FromResult(contact));

            var ContactSaved = _contactService.GetOne(idClient, idContact);

            Assert.IsNotNull(ContactSaved);
        }

        [Test]
        public void ShouldReturnAllContacts()
        {
            var idClient = Guid.NewGuid();
            var contactList = new List<ContactEntity> {
                new ContactEntity("Test", idClient),
                new ContactEntity("Test", idClient)
                }.AsQueryable();
            _contactRepository.Setup(c => c.Get()).Returns(contactList);

            var contactListSaved = _contactService.GetAll(idClient);

            Assert.IsNotNull(contactListSaved);
            Assert.AreEqual(2, contactListSaved.Count);
        }

        [Test]
        public void ShouldSaveContact()
        {
            var idClient = Guid.NewGuid();
            var contact = new RequestContactDto { Name = "test" };

            var contactSaved = _contactService.Save(idClient, contact);

            Assert.IsNotNull(contactSaved);
            _contactRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>()));
            _contactRepository.Verify(c => c.Add(It.IsAny<ContactEntity>()));
        }

        [Test]
        public async Task ShouldUpdateContact()
        {
            var idClient = Guid.NewGuid();
            var idContact = Guid.NewGuid();
            var contact = new RequestContactDto { Name = "test" };
            var contactSaved = new ContactEntity("other", idContact);
            _contactRepository.Setup(c => c.FindOne(c => c.ClientId == idClient && c.Id == idContact)).Returns(Task.FromResult(contactSaved));

            var ContactUpdated = await _contactService.Update(idClient, idContact, contact);

            Assert.IsNotNull(ContactUpdated);
            Assert.AreEqual(contact.Name, ContactUpdated.Name);
            _contactRepository.Verify(c => c.Update(It.IsAny<ContactEntity>()));
        }

        [Test]
        public void ShouldDeleteContact()
        {
            var idClient = Guid.NewGuid();
            var idContact = Guid.NewGuid();
            var Contact = new ContactEntity("Test", idContact);
            _contactRepository.Setup(c => c.FindOne(c => c.ClientId == idClient && c.Id == idContact)).Returns(Task.FromResult(Contact));

            _contactService.Delete(idClient, idContact);

            _contactRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>()));
            _contactRepository.Verify(c => c.Delete(It.IsAny<ContactEntity>()));
        }

        [Test]
        public void ShouldNotDeleteInexistentContact()
        {
            var idClient = Guid.NewGuid();
            var idContact = Guid.NewGuid();

            _contactService.Delete(idClient, idContact);

            _contactRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ContactEntity, bool>>>()));
            _contactRepository.Verify(c => c.Delete(It.IsAny<ContactEntity>()), Times.Never);
        }
    }
}
