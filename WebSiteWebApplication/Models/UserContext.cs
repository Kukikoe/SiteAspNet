using System.Data.Entity;

namespace BookingStoreWebApplication.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}