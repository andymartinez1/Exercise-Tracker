using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Exercise_Tracker.Models;
using Exercise_Tracker.Views;
using Spectre.Console;

namespace Exercise_Tracker.Utils;

public static class Helpers
{
    public static string? GetDisplayName(this Enum enumValue)
    {
        return enumValue
            .GetType()
            .GetMember(enumValue.ToString())
            .First()
            ?.GetCustomAttribute<DisplayAttribute>()
            ?.Name;
    }

    public static int GetExerciseId(List<Exercise> exercises)
    {
        UserInterface.ShowAllExercises(exercises);

        if (exercises.Count <= 0)
        {
            AnsiConsole.MarkupLine("[red]Please create an exercise to continue.[/]");
        }
        else
        {
            var exerciseArray = exercises.Select(e => e.Id).ToArray();

            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<int>()
                    .Title("Select an exercise to view details:")
                    .AddChoices(exerciseArray)
            );

            return userChoice;
        }

        return 0;
    }
}
