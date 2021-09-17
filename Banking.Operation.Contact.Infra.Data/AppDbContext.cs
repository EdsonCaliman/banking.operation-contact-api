using Microsoft.EntityFrameworkCore;

namespace Banking.Operation.Contact.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
