using Banking.Operation.Contact.Domain.Contact.Entities;
using Banking.Operation.Contact.Domain.Contact.Repositories;
using Banking.Operation.Contact.Infra.Data.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Contact.Infra.Data.Contact.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ContactRepository : BaseRepository<ContactEntity>, IContactRepository
    {
        public ContactRepository(AppDbContext context)
            : base(context) { }
    }
}
