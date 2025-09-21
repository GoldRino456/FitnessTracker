using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Data;
using FitnessTracker.Data.Models;

namespace FitnessTracker.Pages
{
    public class EditModel : PageModel
    {
        private readonly FitnessTracker.Data.ExerciseLogDbContext _context;

        public EditModel(FitnessTracker.Data.ExerciseLogDbContext context)
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

            var logentrydata =  await _context.ExcerciseLogEntries.FirstOrDefaultAsync(m => m.Id == id);
            if (logentrydata == null)
            {
                return NotFound();
            }
            LogEntryData = logentrydata;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LogEntryData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogEntryDataExists(LogEntryData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LogEntryDataExists(int id)
        {
            return _context.ExcerciseLogEntries.Any(e => e.Id == id);
        }
    }
}
