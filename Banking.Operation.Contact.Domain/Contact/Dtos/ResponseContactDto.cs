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
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
