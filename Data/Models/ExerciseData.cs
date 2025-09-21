using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Data.Models;

public class ExerciseData
{
    public string ExerciseId { get; set; }
    public string Name { get; set; }
    public string GifUrl { get; set; }
    public List<string> TargetMuscles { get; set; }
    public List<string> BodyParts { get; set; }
    public List<string> Equipments { get; set; }
    public List<string> SecondaryMuscles { get; set; }
    public List<string> Instructions { get; set; }
}
