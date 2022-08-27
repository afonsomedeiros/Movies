using Movies.Domain;
using Movies.Repository.Services;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Movie movie = new Movie(0, "Matrix Revolution", 2001);
var repository = new MovieServices();

repository.save(movie);

movie = new Movie(2, "Matrix Reload", 2001);

repository.update(movie);

movie = new Movie(0, "Matrix Catatal", 2001);

repository.delete(3);

movie = repository.GetMovie(2);

Console.WriteLine($"Id: {movie.Id} - Nome: {movie.Name} - Ano: {movie.Year}");

var movies = repository.GetAllMovies();

foreach (var m in movies){
    Console.WriteLine($"Id: {m.Id} - Nome: {m.Name} - Ano: {m.Year}");
}
