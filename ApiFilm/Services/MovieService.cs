using ApiFilm.DataBaseContext;
using ApiFilm.Interfaces;
using ApiFilm.Models;

namespace ApiFilm.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public Movie UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return null;

            movie.Title = updatedMovie.Title;
            movie.Description = updatedMovie.Description;
            movie.Genre = updatedMovie.Genre;
            movie.ReleaseDate = updatedMovie.ReleaseDate;
            movie.Rating = updatedMovie.Rating;

            _context.SaveChanges();
            return movie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
