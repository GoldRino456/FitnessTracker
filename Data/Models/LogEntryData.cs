namespace FitnessTracker.Data.Models;

public class LogEntryData
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string ExerciseName { get; set; }
    public string ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public float Time {  get; set; }
    public bool IsTimeBasedExercise { get; set; }
}
