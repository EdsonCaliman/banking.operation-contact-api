using Banking.Operation.Contact.Domain.Contact.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Domain.Contact.Services
{
    public interface IContactService
    {
        Task<List<ResponseContactDto>> GetAll(Guid clientid);
        Task<ResponseContactDto> GetOne(Guid clientid, Guid id);
        Task<ResponseContactDto> Save(Guid clientid, RequestContactDto contact);
        Task<ResponseContactDto> Update(Guid clientid, Guid id, RequestUpdateContactDto contact);
        Task Delete(Guid clientid, Guid id);
    }
}
