using Exercise_Tracker.Models;
using Exercise_Tracker.Repository;

namespace Exercise_Tracker.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository<Exercise> _repository;

    public ExerciseService(IExerciseRepository<Exercise> repository)
    {
        _repository = repository;
    }

    public List<Exercise> GetAllExercises()
    {
        return _repository.GetAllExercises();
    }

    public Exercise GetExerciseById(int id)
    {
        return _repository.GetExerciseById(id);
    }

    public void AddExercise(Exercise exercise)
    {
        if (exercise == null)
        {
            throw new ArgumentNullException(nameof(exercise), "Exercise cannot be null");
        }

        _repository.AddExercise(exercise);
    }

    public void UpdateExercise(Exercise exercise)
    {
        if (exercise == null)
        {
            throw new ArgumentNullException(nameof(exercise), "Exercise cannot be null");
        }

        _repository.UpdateExercise(exercise);
    }

    public void DeleteExercise(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Invalid exercise ID", nameof(id));
        }

        _repository.DeleteExercise(id);
    }
}
