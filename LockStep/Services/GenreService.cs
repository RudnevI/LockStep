using LockStep.Library.Domain;
using System.Linq;
using System.Collections.Generic;

namespace LockStep.Web.Services
{
    public static class GenreService
    {
        private static List<Genre> Genres = new List<Genre>
            {
                new Genre { Id=1, Name="Жанр 1"},
                new Genre { Id=2, Name="Жанр 2"},
                new Genre { Id=3, Name="Жанр 3"},
                new Genre { Id=4, Name="Жанр 4"},
                new Genre { Id=5, Name="Жанр 5"},
            };
        public static List<Genre> GetList() => Genres;
        public static Genre GetItem(int id) => Genres.FirstOrDefault(p=>p.Id == id);
    }
}