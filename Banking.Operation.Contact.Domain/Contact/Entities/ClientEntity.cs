using System;
using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Contact.Domain.Contact.Entities
{
    public class ClientEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Account { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public ClientEntity()
        {
        }
    }
}
