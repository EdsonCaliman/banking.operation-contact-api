using Banking.Operation.Contact.Domain.Contact.Entities;
using Banking.Operation.Contact.Domain.Contact.Repositories;
using Banking.Operation.Contact.Infra.Data.Repositories;

namespace Banking.Operation.Contact.Infra.Data.Contact.Repositories
{
    public class ContactRepository : BaseRepository<ContactEntity>, IContactRepository
    {
        public ContactRepository(AppDbContext context)
            : base(context) { }
    }
}
