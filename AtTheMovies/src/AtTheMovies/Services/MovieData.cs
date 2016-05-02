using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtTheMovies.Entities;
using Microsoft.Data.Entity;

namespace AtTheMovies.Services
{
    public interface IMovieData
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        Movie Save(Movie updatedMovie);
        Movie Create(Movie movie);
    }

    public class MovieDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }

    public class SqlMovieData : IMovieData
    {
        private readonly MovieDb _db;

        public SqlMovieData(MovieDb db)
        {
            _db = db;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _db.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return _db.Movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie Save(Movie updatedMovie)
        {
            _db.Update(updatedMovie);
            _db.SaveChanges();
            return updatedMovie;
        }

        public Movie Create(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return movie;
        }
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

        public Movie Create(Movie movie)
        {
            _movies.Add(movie);
            movie.Id = _movies.Count;
            return movie;
        }
    }
}
