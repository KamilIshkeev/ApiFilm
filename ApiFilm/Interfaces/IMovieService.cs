using ApiFilm.Models;

namespace ApiFilm.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        Movie AddMovie(Movie movie);
        Movie UpdateMovie(int id, Movie updatedMovie);
        void DeleteMovie(int id);
    }
}
