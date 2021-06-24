namespace LockStep.Library.Persistence.Migrations
{
    using LockStep.Library.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Authors.Add(new Author { Name = "Тестовый автор 1" });
            context.Authors.Add(new Author { Name = "Тестовый автор 2" });
            context.Authors.Add(new Author { Name = "Тестовый автор 3" });
            context.Genres.Add(new Genre { Name = "Тестовый жанр 1" });
            context.Genres.Add(new Genre { Name = "Тестовый жанр 2" });
            context.Genres.Add(new Genre { Name = "Тестовый жанр 3" });
            context.Books.Add(new Book { Name = "Тестовая книга 1" });
            context.Books.Add(new Book { Name = "Тестовая книга 2" });
            context.Books.Add(new Book { Name = "Тестовая книга 3" });
        }
    }
}
