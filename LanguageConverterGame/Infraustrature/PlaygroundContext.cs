using LanguageConverterGame.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguageConverterGame.Infraustrature
{
    public partial class PlaygroundContext : DbContext
    {

        public PlaygroundContext(DbContextOptions<PlaygroundContext> options) : base(options)
        {
        }
        public virtual DbSet<MessageBoard> MessageBoard { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}
