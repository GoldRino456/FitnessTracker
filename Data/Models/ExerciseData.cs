using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Data.Models;

public class ExerciseData
{
    public string exerciseId { get; set; }
    public string name { get; set; }
    public string gifUrl { get; set; }
    public List<string> targetMuscles { get; set; }
    public List<string> bodyParts { get; set; }
    public List<string> equipments { get; set; }
    public List<string> secondaryMuscles { get; set; }
    public List<string> instructions { get; set; }
}

public class Metadata
{
    public int totalExercises { get; set; }
    public int totalPages { get; set; }
    public int currentPage { get; set; }
    public string previousPage { get; set; }
    public string nextPage { get; set; }
}

public class multiExerciseJsonResponse
{
    public bool success { get; set; }
    public Metadata metadata { get; set; }
    public List<ExerciseData> data {  get; set; }
}

public class singleExerciseJsonResponse
{
    public bool success { get; set; }
    public ExerciseData data { get; set; }
}
