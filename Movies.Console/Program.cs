using Movies.Domain;
using Movies.Infrastructure.Services;
using Movies.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

void ConfigureServices(IServiceCollection services){
    services.AddScoped<IMovies, MovieServices>()
            .AddScoped<IMovies, SQLiteMoviesRepository>();
}

void main()
{
    var serviceCollection = new ServiceCollection();
    ConfigureServices(serviceCollection);
    var serviceProvider = serviceCollection.BuildServiceProvider();

    var eventService = serviceProvider.GetService<IMovies>();


    // See https://aka.ms/new-console-template for more information
    Console.WriteLine("Hello, World!");

    Movie movie = new Movie(0, "Matrix Revolution", 2001);

    eventService.save(movie);

    movie = new Movie(2, "Matrix Reload", 2001);

    eventService.update(movie);

    movie = new Movie(0, "Matrix Catatal", 2001);

    eventService.delete(3);

    movie = eventService.GetMovie(2);

    Console.WriteLine($"Id: {movie.Id} - Nome: {movie.Name} - Ano: {movie.Year}");

    var movies = eventService.GetAllMovies();

    foreach (var m in movies)
    {
        Console.WriteLine($"Id: {m.Id} - Nome: {m.Name} - Ano: {m.Year}");
    }
}

main();