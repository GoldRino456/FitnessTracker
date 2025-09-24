using FitnessTracker.Data.Models;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace FitnessTracker.Pages
{
    public class ExerciseSearchModel : PageModel
    {
        private readonly ILogger<ExerciseSearchModel> _logger;

        [BindProperty]
        public IList<ExerciseData> SearchResults { get; set; }

        [BindProperty]
        [DisplayName("Search")]
        public string SearchQuery { get; set; } = String.Empty;

        public ExerciseSearchModel(ILogger<ExerciseSearchModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            SearchResults ??= [];
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await FetchSearchResultsAsync(SearchQuery);
            return Page();
        }

        private async Task<bool> FetchSearchResultsAsync(string query)
        {
            var results = await ExerciseApiService.GetFuzzySearchResults(query);

            if(results != null && results.Count > 0)
            {
                SearchResults = results;
                return true;
            }

            return false;
        }
    }

}
