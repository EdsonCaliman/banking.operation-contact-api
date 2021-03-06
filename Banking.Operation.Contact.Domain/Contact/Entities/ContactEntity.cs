using Banking.Operation.Contact.Domain.Abstractions.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Contact.Domain.Contact.Entities
{
    public class ContactEntity
    {
        public ContactEntity()
        {
        }

        public ContactEntity(string name, ClientEntity client, int account)
        {
            Name = name;
            Client = client;
            Account = account;
            CreatedAt = DateTime.Now;
            CreatedBy = CreatorHelper.GetEntityCreatorIdentity();
        }

        [Key]
        public Guid Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public int Account { get; set; }
        public ClientEntity Client { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
