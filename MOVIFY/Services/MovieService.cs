using Microsoft.EntityFrameworkCore;
using MOVIFY.Data;
using MOVIFY.Data.Data;
using MOVIFY.Model;
using System.Collections.Generic;
using System.Linq;

namespace MOVIFY.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Director)
                .ToList();
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}