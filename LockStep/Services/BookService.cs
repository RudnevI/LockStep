using LockStep.Library.Domain;
using System.Collections.Generic;

namespace LockStep.Web.Services
{
    public static class BookService
    {
        public static List<Book> GetList()
        {
            return new List<Book>
            {
                new Book { Id=1, Name="Книга 1", Authors=GetBook1Authors(), Genres=GetBook1Genres()  },
                new Book { Id=2, Name="Книга 2", Authors=GetBook2Authors(), Genres=GetBook2Genres() },
                new Book { Id=3, Name="Книга 3", Authors=GetBook3Authors(), Genres=GetBook3Genres() },
                new Book { Id=4, Name="Книга 4", Authors=GetBook4Authors(), Genres=GetBook4Genres() },
                new Book { Id=5, Name="Книга 5", Authors=GetBook5Authors(), Genres=GetBook5Genres() },
            };
        }

        #region BookAuthors
        private static List<Author> GetBook1Authors() =>
            new List<Author>
            {
                new Author { Id=3, Name="Автор 3"},
                new Author { Id=4, Name="Автор 4"}
            };
        private static List<Author> GetBook2Authors() =>
            new List<Author>
            {
                new Author { Id=3, Name="Автор 1"},
                new Author { Id=4, Name="Автор 4"}
            };
        private static List<Author> GetBook3Authors() =>
            new List<Author>
            {
                new Author { Id=2, Name="Автор 2"},
                new Author { Id=3, Name="Автор 3"},
            };
        private static List<Author> GetBook4Authors() =>
            new List<Author>
            {
                new Author { Id=4, Name="Автор 4"},
                new Author { Id=5, Name="Автор 5"},
            };
        private static List<Author> GetBook5Authors() =>
            new List<Author>
            {
                new Author { Id=1, Name="Автор 1"},
                new Author { Id=2, Name="Автор 2"},
            };
        #endregion

        #region BookGenres
        private static List<Genre> GetBook1Genres() =>
            new List<Genre>
            {
                new Genre { Id=3, Name="Жанр 3"},
                new Genre { Id=4, Name="Жанр 4"}
            };
        private static List<Genre> GetBook2Genres() =>
            new List<Genre>
            {
                new Genre { Id=3, Name="Жанр 1"},
                new Genre { Id=4, Name="Жанр 4"}
            };
        private static List<Genre> GetBook3Genres() =>
            new List<Genre>
            {
                new Genre { Id=2, Name="Жанр 2"},
                new Genre { Id=3, Name="Жанр 3"},
            };
        private static List<Genre> GetBook4Genres() =>
            new List<Genre>
            {
                new Genre { Id=4, Name="Жанр 4"},
                new Genre { Id=5, Name="Жанр 5"},
            };
        private static List<Genre> GetBook5Genres() =>
            new List<Genre>
            {
                new Genre { Id=1, Name="Жанр 1"},
                new Genre { Id=2, Name="Жанр 2"},
            };
        #endregion
    }
}