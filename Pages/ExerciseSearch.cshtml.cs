using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitnessTracker.Pages
{
    public class ExerciseSearchModel : PageModel
    {
        private readonly ILogger<ExerciseSearchModel> _logger;

        public ExerciseSearchModel(ILogger<ExerciseSearchModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
