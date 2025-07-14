using Dapper;
using Exercise_Tracker.Data;
using Exercise_Tracker.Models;
using Microsoft.Data.SqlClient;

namespace Exercise_Tracker.Repository;

public class ExerciseRepository : IExerciseRepository<Exercise>
{
    private readonly DataConnection _connection;

    public ExerciseRepository(DataConnection connection)
    {
        _connection = connection;
    }

    public List<Exercise> GetAllExercises()
    {
        using (var connection = new SqlConnection(_connection.ConnectionString))
        {
            connection.Open();

            var selectQuery = "SELECT * FROM Exercises";

            var exercises = connection.Query<Exercise>(selectQuery).ToList();

            return exercises;
        }
    }

    public Exercise GetExerciseById(int id)
    {
        using (var connection = new SqlConnection(_connection.ConnectionString))
        {
            connection.Open();

            var selectQuery = "SELECT * FROM Exercises WHERE Id = @Id";

            var exercises = connection.Query<Exercise>(selectQuery, new { Id = id });

            return exercises.FirstOrDefault();
        }
    }

    public void AddExercise(Exercise exercise)
    {
        using (var connection = new SqlConnection(_connection.ConnectionString))
        {
            connection.Open();

            var insertQuery =
                @"
                INSERT INTO Exercises (StartTime, EndTime, Comments)
                VALUES (@StartTime, @EndTime, @Comments)
                ";

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

    public void UpdateExercise(Exercise exercise)
    {
        using (var connection = new SqlConnection(_connection.ConnectionString))
        {
            connection.Open();

            var updateQuery =
                @"
                UPDATE Exercises 
                SET StartTime = @StartTime, EndTime = @EndTime, Comments = @Comments
                WHERE Id = @Id
                ";

            connection.Execute(
                updateQuery,
                new
                {
                    exercise.StartTime,
                    exercise.EndTime,
                    exercise.Comments,
                    exercise.Id,
                }
            );
        }
    }

    public void DeleteExercise(int id)
    {
        using (var connection = new SqlConnection(_connection.ConnectionString))
        {
            connection.Open();

            var deleteQuery = "DELETE FROM Exercises WHERE Id = @Id";

            connection.Execute(deleteQuery, new { Id = id });
        }
    }
}
