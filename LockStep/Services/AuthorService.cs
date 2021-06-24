using LockStep.Library.Domain;
using System.Collections.Generic;

namespace LockStep.Web.Services
{
    public static class AuthorService
    {
        public static List<Author> GetList()
        {
            return new List<Author>
            {
                new Author { Id=1, Name="Автор 1"},
                new Author { Id=2, Name="Автор 2"},
                new Author { Id=3, Name="Автор 3"},
                new Author { Id=4, Name="Автор 4"},
                new Author { Id=5, Name="Автор 5"},
            };
        }
    }
}