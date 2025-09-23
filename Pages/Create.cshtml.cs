using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FitnessTracker.Data.Models;

namespace FitnessTracker.Pages
{
    public class CreateModel : PageModel
    {
        private readonly FitnessTracker.Data.ExerciseLogDbContext _context;

        public CreateModel(FitnessTracker.Data.ExerciseLogDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LogEntryData LogEntryData { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if(LogEntryData.IsTimeBasedExercise)
            {
                if(LogEntryData.Time == null || LogEntryData.Time <= 0)
                {
                    ModelState.AddModelError("LogEntryData.Time", "Time cannot be empty and must be greater than 0.");
                }

                LogEntryData.Reps = null;
            }
            else
            {
                if (LogEntryData.Reps == null || LogEntryData.Reps <= 0)
                {
                    ModelState.AddModelError("LogEntryData.Reps", "Reps cannot be empty and must be greater than 0.");
                }

                LogEntryData.Time = null;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ExcerciseLogEntries.Add(LogEntryData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
