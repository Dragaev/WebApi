using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class PersonItemContext: DbContext
    {
        public PersonItemContext(DbContextOptions<PersonItemContext> options)
        : base(options)
        {
        }

        public DbSet<PersonItem> PersonItems { get; set; } = null!;
    }
}
