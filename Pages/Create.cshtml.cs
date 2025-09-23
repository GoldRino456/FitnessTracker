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
