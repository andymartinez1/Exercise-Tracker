using Exercise_Tracker.Services;
using Exercise_Tracker.Utils;
using Exercise_Tracker.Views;

namespace Exercise_Tracker.Controllers;

public class ExerciseController
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    public void GetAllExercises()
    {
        var exercises = _exerciseService.GetAllExercises();

        UserInterface.ShowAllExercises(exercises);
    }

    public void GetExerciseById()
    {
        var exercises = _exerciseService.GetAllExercises();

        var exerciseId = Helpers.GetExerciseId(exercises);

        var selectedExercise = _exerciseService.GetExerciseById(exerciseId);

        if (exercises.Count > 0)
            UserInterface.ShowExerciseDetails(selectedExercise);
        else
            return;
    }

    public void AddExercise()
    {
        _exerciseService.AddExercise();
    }

    public void UpdateExercise()
    {
        var exercises = _exerciseService.GetAllExercises();

        var exerciseId = Helpers.GetExerciseId(exercises);

        var exerciseToUpdate = _exerciseService.GetExerciseById(exerciseId);

        if (exercises.Count > 0)
            _exerciseService.UpdateExercise(exerciseToUpdate);
        else
            return;
    }

    public void DeleteExercise()
    {
        var exercises = _exerciseService.GetAllExercises();

        var exerciseId = Helpers.GetExerciseId(exercises);

        if (exercises.Count > 0)
            _exerciseService.DeleteExercise(exerciseId);
        else
            return;
    }
}
