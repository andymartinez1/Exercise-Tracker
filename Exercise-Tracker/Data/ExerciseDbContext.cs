using Exercise_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Tracker.Data;

public class ExerciseDbContext : DbContext
{
    public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options)
        : base(options) { }

    public DbSet<Exercise> Exercises { get; set; }
}
