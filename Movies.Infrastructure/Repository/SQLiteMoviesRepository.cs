using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Movies.Domain;

namespace Movies.Infrastructure.Repository;

public class SQLiteMoviesRepository : IMovies
{
    public bool save(Movie movie)
    {
        int rows = 0;
        using (var connection = new SqliteConnection("Data Source=db.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO Movies (Name, Year) VALUES ($Name, $Year);
            ";
            command.Parameters.AddWithValue("$Name", movie.Name);
            command.Parameters.AddWithValue("$Year", movie.Year);

            rows = command.ExecuteNonQuery();
        }
        return rows > 0;
    }

    public bool update(Movie movie)
    {
        int rows = 0;
        using (var connection = new SqliteConnection("Data Source=db.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                UPDATE Movies SET
                    Name = $Name,
                    Year = $Year
                WHERE Id = $Id;
            ";
            command.Parameters.AddWithValue("$Id", movie.Id);
            command.Parameters.AddWithValue("$Name", movie.Name);
            command.Parameters.AddWithValue("$Year", movie.Year);

            rows = command.ExecuteNonQuery();
        }
        return rows > 0;
    }

    public bool delete(int id)
    {
        int rows = 0;
        using (var connection = new SqliteConnection("Data Source=db.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                DELETE FROM Movies WHERE Id = $Id;
            ";
            command.Parameters.AddWithValue("$Id", id);

            rows = command.ExecuteNonQuery();
        }
        return rows > 0;
    }

    public Movie GetMovie(int id)
    {
        Movie movie = null;
        using (var connection = new SqliteConnection("Data Source=db.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT Id, Name, Year FROM Movies
                WHERE Id = $Id;
            ";
            command.Parameters.AddWithValue("$Id", id);

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    movie = new Movie(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2)
                    );
                }
            }
        }
        return movie;
    }

    public List<Movie> GetAllMovies()
    {
        List<Movie> movies = new List<Movie>();
        using (var connection = new SqliteConnection("Data Source=db.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT Id, Name, Year FROM Movies;";

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(
                        new Movie(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2)
                        )
                    );
                    }
                }
            }
        }
        return movies;
    }
}