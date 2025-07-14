using Dapper;
using Exercise_Tracker.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Exercise_Tracker.Data;

public class DataConnection
{
    internal string ConnectionString =
        "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=exercise_db;Integrated Security=true;Trusted_Connection=True";

    private List<Exercise> _seedExerciseList = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            StartTime = new DateTime(2025, 7, 15, 8, 0, 0),
            EndTime = new DateTime(2025, 7, 15, 8, 45, 0),
            Comments = "Morning workout session.",
        },
        new Exercise
        {
            Id = 2,
            StartTime = new DateTime(2025, 7, 16, 13, 0, 0),
            EndTime = new DateTime(2025, 7, 16, 14, 0, 0),
            Comments = "Afternoon workout session.",
        },
        new Exercise
        {
            Id = 3,
            StartTime = new DateTime(2025, 7, 17, 21, 0, 0),
            EndTime = new DateTime(2025, 7, 17, 21, 30, 0),
            Comments = "Evening workout session.",
        },
    };

    internal void CreateDatabase()
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            // Check if table exists. If not, create one
            var createTableQuery =
                @"
                IF NOT EXISTS (SELECT * FROM exercises)
                CREATE TABLE exercises (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                StartTime DATETIME NOT NULL,
                EndTime DATETIME NOT NULL,
                Comments NVARCHAR(100) NOT NULL,
                )";

            connection.Execute(createTableQuery);
        }

        if (IsTableEmpty())
        {
            SeedExercises(_seedExerciseList);
        }
    }

    internal bool IsTableEmpty()
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Exercises");

            return count == 0;
        }
    }

    internal void SeedExercises(List<Exercise> exercises)
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            var insertQuery =
                @"
                INSERT INTO Exercises (StartTime, EndTime, Comments)
                VALUES (@StartTime, @EndTime, @Comments)
                ";

            foreach (var exercise in exercises)
            {
                connection.Execute(
                    insertQuery,
                    new
                    {
                        exercise.StartTime,
                        exercise.EndTime,
                        exercise.Comments,
                    }
                );
            }
        }
    }
}
