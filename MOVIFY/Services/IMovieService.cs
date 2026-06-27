using MOVIFY.Model;
using System.Collections.Generic;

namespace MOVIFY.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        void AddMovie(Movie movie);
        Movie GetMovieById(int id);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
