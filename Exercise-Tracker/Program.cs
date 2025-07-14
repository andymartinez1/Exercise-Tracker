using Exercise_Tracker.Controllers;
using Exercise_Tracker.Data;
using Exercise_Tracker.Repository;
using Exercise_Tracker.Services;
using Exercise_Tracker.Views;

DataConnection connection = new DataConnection();

connection.CreateDatabase();

Menu menu = new Menu(
    new ExerciseController(new ExerciseService(new ExerciseRepository(connection)))
);

menu.MainMenu();
