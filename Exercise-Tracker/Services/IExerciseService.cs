using Exercise_Tracker.Models;

namespace Exercise_Tracker.Services;

public interface IExerciseService
{
    List<Exercise> GetAllExercises();

    Exercise GetExerciseById(int id);

    void AddExercise(Exercise exercise);

    void UpdateExercise(Exercise exercise);

    void DeleteExercise(int id);
}
