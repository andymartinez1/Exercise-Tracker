using Exercise_Tracker.Controllers;
using Exercise_Tracker.Data;
using Exercise_Tracker.Repository;
using Exercise_Tracker.Services;
using Exercise_Tracker.Views;
using Microsoft.Extensions.DependencyInjection;

// Configuring the Dependency Injection container
var services = new ServiceCollection();

// Registering the dependencies
services.AddDbContext<ExerciseDbContext>();
services.AddScoped(typeof(IExerciseRepository<>), typeof(ExerciseRepository<>));
services.AddScoped<IExerciseService, ExerciseService>();
services.AddScoped<ExerciseController>();
services.AddScoped<Menu>();

// Building the service provider
var serviceProvider = services.BuildServiceProvider();

// Set up database
using (var scope = serviceProvider.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ExerciseDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

// Get the main menu and run the app
var menu = serviceProvider.GetRequiredService<Menu>();
menu.MainMenu();

// Dispose of the service provider
serviceProvider.Dispose();
