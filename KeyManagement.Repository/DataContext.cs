using KeyManagement.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyManagement.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Key> Keys { get; set; }
        public DbSet<KeySet> KeySets { get; set; }
        public DbSet<KeyEvent> KeyEvents { get; set; }
    }
}
