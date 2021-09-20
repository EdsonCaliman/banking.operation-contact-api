using Banking.Operation.Contact.Domain.Contact.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banking.Operation.Contact.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
    }
}
