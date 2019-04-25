using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GacBootcampWebsite.Database
{
    public class SimpleDatabaseContext : DbContext
    {
        public SimpleDatabaseContext(DbContextOptions<SimpleDatabaseContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        [Key]
        public string FirstName { get; set; }
    }

}

