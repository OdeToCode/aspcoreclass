using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtTheMovies.Entities;

namespace AtTheMovies.Services
{
    public interface IMovieData
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        Movie Save(Movie updatedMovie);
    }

    public class InMemoryMovieData : IMovieData
    {
        private static List<Movie> _movies = new List<Movie>
        {
            new Movie() {Id = 1, Title = "Star Wars", Length = 120},
            new Movie() {Id = 2, Title = "Lord of the Rings", Length = 400},
            new Movie() {Id = 3, Title = "Deadpool", Length = 130}
        };

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public Movie Get(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie Save(Movie updatedMovie)
        {
            var movie = _movies.First(m => m.Id == updatedMovie.Id);
            movie.Title = updatedMovie.Title;
            movie.Length = updatedMovie.Length;
            return movie;
        }
    }
}
