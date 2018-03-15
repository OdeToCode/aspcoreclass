using Microsoft.EntityFrameworkCore;
using Movies.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Services
{
    public interface IMovieDb
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        Movie Create(Movie newMovie);
        Movie Delete(int id);
        Movie Update(Movie updatedMovie);
    }

    public class SqlMovieDb : IMovieDb
    {
        private readonly MovieContext context;

        public SqlMovieDb(MovieContext context)
        {
            this.context = context;
        }

        public Movie Create(Movie newMovie)
        {
            context.Movies.Add(newMovie);
            context.SaveChanges();
            return newMovie;
        }

        public Movie Delete(int id)
        {
            var movie = Get(id);
            if(movie != null)
            {
                context.Remove(movie);
                context.SaveChanges();
            }
            return movie;
        }

        public Movie Get(int id)
        {
            return context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return context.Movies.OrderBy(m => m.Title).ToList();
        }

        public Movie Update(Movie updatedMovie)
        {
            var entry = context.Attach(updatedMovie);

            entry.Property(m => m.ReleaseYear).IsModified = true;


            context.SaveChanges();
            return updatedMovie;
        }
    }

    public class InMemoryMovieDb : IMovieDb
    {
        List<Movie> movies = new List<Movie>();

        public InMemoryMovieDb()
        {
            movies = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Star Wars", ReleaseYear=1977 },
                new Movie { Id = 2, Title = "STar Trek", ReleaseYear=1984 },
                new Movie { Id = 3, Title = "The Matrix", ReleaseYear=1992 }
            };
        }

        public Movie Create(Movie newMovie)
        {
            newMovie.Id = movies.Max(m => m.Id) + 1;
            movies.Add(newMovie);            
            return newMovie;
        }

        public Movie Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if(movie != null)
            {
                movies.Remove(movie);
            }
            return movie;
        }

        public Movie Get(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return movies.OrderBy(m => m.Title);
        }

        public Movie Update(Movie updatedMovie)
        {
            var movie = Get(updatedMovie.Id);
            if (movie != null)
            {
                movie.Title = updatedMovie.Title;
                movie.ReleaseYear = updatedMovie.ReleaseYear;
            }
            return movie;
        }
    }
}
