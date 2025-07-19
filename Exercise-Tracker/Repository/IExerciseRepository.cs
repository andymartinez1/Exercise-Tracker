namespace Exercise_Tracker.Repository;

public interface IExerciseRepository<T>
{
    List<T> GetAllExercises();

    T GetExerciseById(int id);

    void AddExercise(T exercise);

    void UpdateExercise(T exercise);

    void DeleteExercise(int id);
}
