using Banking.Operation.Contact.Domain.Contact.Entities;
using System;

namespace Banking.Operation.Contact.Domain.Contact.Dtos
{
    public class ResponseContactDto
    {
        public ResponseContactDto(ContactEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            CreatedAt = entity.CreatedAt;
            CreatedBy = entity.CreatedBy;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
