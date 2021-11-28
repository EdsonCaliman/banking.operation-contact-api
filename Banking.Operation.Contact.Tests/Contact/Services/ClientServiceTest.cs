using Banking.Operation.Contact.Domain.Contact.Entities;
using Banking.Operation.Contact.Domain.Contact.Repositories;
using Banking.Operation.Contact.Domain.Contact.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Tests.Contact.Services
{
    public class ClientServiceTest
    {
        private IClientService _clientService;
        private Mock<IClientRepository> _clientRepository;

        [SetUp]
        public void SetUp()
        {
            _clientRepository = new Mock<IClientRepository>();

            _clientService = new ClientService(_clientRepository.Object);
        }

        [Test]
        public async Task ShouldFindByAccountWithSuccess()
        {
            var account = 123;
            var savedClient = new ClientEntity
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "test",
                Account = 123,
                CreatedAt = DateTime.Now,
                CreatedBy = "test"
            };
            _clientRepository.Setup(r => r.FindByAccount(account)).ReturnsAsync(savedClient);            

            var client = await _clientService.FindByAccount(account);

            Assert.AreEqual(savedClient.Name, client.Name);
            Assert.AreEqual(account, client.Account);
        }

        [Test]
        public async Task ShouldGetOneWithSuccess()
        {
            var savedClient = new ClientEntity
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "test",
                Account = 123,
                CreatedAt = DateTime.Now,
                CreatedBy = "test"
            };
            _clientRepository.Setup(r => r.FindOne(It.IsAny<Expression<Func<ClientEntity, bool>>>())).ReturnsAsync(savedClient);

            var client = await _clientService.GetOne(savedClient.Id);

            Assert.AreEqual(savedClient.Name, client.Name);
            Assert.AreEqual(savedClient.Account, client.Account);
        }
    }
}
