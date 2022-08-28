using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Movies.Domain;

namespace Movies.Infrastructure.Services;

public class MovieServices : IMovies
{
    private IMovies _service;

    public MovieServices(IMovies service){
        _service = service;
    }

    public bool save(Movie movie)
    {
        return _service.save(movie);
    }

    public bool update(Movie movie)
    {
        return _service.update(movie);
    }

    public bool delete(int id)
    {
        return _service.delete(id);
    }

    public Movie GetMovie(int id)
    {
        return _service.GetMovie(id);
    }

    public List<Movie> GetAllMovies()
    {
        return _service.GetAllMovies();
    }
}