using LockStep.Library.Domain;
using LockStep.Library.Domain.Finance;
using System.Data.Entity;

namespace LockStep.Library.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookVote> BookVotes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Price> Prices { get; set; }

        public System.Data.Entity.DbSet<LockStep.Library.Domain.BookComment> BookComments { get; set; }

        public System.Data.Entity.DbSet<LockStep.Library.Domain.Product> Products { get; set; }
        //public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
    }
}
