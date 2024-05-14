using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Green_home.Model; // Import the namespace for Ejendomme model
using Green_home.Services; // Import the namespace for IEjendommeRepository_DB

namespace Green_home.Pages
{
        public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
       

        // Inject the logger and repository interface
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // Property to hold the list of Ejendomme objects
    
        // Handler for the GET request
        public void OnGet()
        {
            // Retrieve the list of Ejendomme objects from the repository
        }
    }
}