using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Green_home.Model; // Import the namespace for Ejendomme model
using Green_home.Services; // Import the namespace for IEjendommeRepository_DB

namespace Green_home.Pages
{
    public class EjendommeModel : PageModel
    {
        private readonly ILogger<EjendommeModel> _logger;
        private readonly IEjendommeRepository_DB _ejendommeRepositoryDb;

        // Inject the logger and repository interface
        public EjendommeModel(ILogger<EjendommeModel> logger, IEjendommeRepository_DB ejendommeRepositoryDb)
        {
            _logger = logger;
            _ejendommeRepositoryDb = ejendommeRepositoryDb;
        }

        // Property to hold the list of Ejendomme objects
        public List<Ejendomme> EjendommeList { get; set; }

        // Handler for the GET request
        public void OnGet()
        {
            // Retrieve the list of Ejendomme objects from the repository
            EjendommeList = _ejendommeRepositoryDb.GetAll();
        }
    }
}