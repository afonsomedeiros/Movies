using System.Collections.Generic;

namespace Movies.Domain;


public interface IMovies {
    public bool save(Movie movie);

    public bool update(Movie movie);

    public bool delete(int id);

    public Movie GetMovie(int id);

    public List<Movie> GetAllMovies();
}