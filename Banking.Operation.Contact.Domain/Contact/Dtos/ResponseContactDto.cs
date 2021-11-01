using Banking.Operation.Contact.Domain.Contact.Entities;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Contact.Domain.Contact.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ResponseContactDto
    {
        public ResponseContactDto(ContactEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Account = entity.Account;
            CreatedAt = entity.CreatedAt;
            CreatedBy = entity.CreatedBy;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Account { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
