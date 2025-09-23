using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Data.Models;

public class LogEntryData
{
    public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime Date { get; set; }

    [Display(Name = "Exercise")]
    public string ExerciseName { get; set; }

    public string ExerciseId { get; set; }

    [Range(0, int.MaxValue)]
    public int Sets { get; set; }

    [Range(0, int.MaxValue)]
    public int Reps { get; set; }

    [Range(0, float.MaxValue)]
    public float Time {  get; set; }

    public bool IsTimeBasedExercise { get; set; } = false;
}
