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
    public class IndexModel : PageModel
    {
        private readonly FitnessTracker.Data.ExerciseLogDbContext _context;

        public IndexModel(FitnessTracker.Data.ExerciseLogDbContext context)
        {
            _context = context;
        }

        public IList<LogEntryData> LogEntryData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LogEntryData = await _context.ExcerciseLogEntries.ToListAsync();
        }
    }
}
