using Banking.Operation.Contact.Domain.Contact.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Contact.Infra.Data
{
    [ExcludeFromCodeCoverage]
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
