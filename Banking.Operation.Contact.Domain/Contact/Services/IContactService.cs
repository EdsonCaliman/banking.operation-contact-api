using Banking.Operation.Contact.Domain.Contact.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Domain.Contact.Services
{
    public interface IContactService
    {
        List<ResponseContactDto> GetAll(Guid clientid);
        Task<ResponseContactDto> GetOne(Guid clientid, Guid id);
        Task<ResponseContactDto> Save(Guid clientid, RequestContactDto client);
        Task<ResponseContactDto> Update(Guid clientid, Guid id, RequestContactDto client);
        Task Delete(Guid clientid, Guid id);
    }
}
