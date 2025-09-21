using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Data;
using FitnessTracker.Data.Models;

namespace FitnessTracker.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly FitnessTracker.Data.ExerciseLogDbContext _context;

        public DeleteModel(FitnessTracker.Data.ExerciseLogDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LogEntryData LogEntryData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logentrydata = await _context.ExcerciseLogEntries.FirstOrDefaultAsync(m => m.Id == id);

            if (logentrydata is not null)
            {
                LogEntryData = logentrydata;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logentrydata = await _context.ExcerciseLogEntries.FindAsync(id);
            if (logentrydata != null)
            {
                LogEntryData = logentrydata;
                _context.ExcerciseLogEntries.Remove(LogEntryData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
