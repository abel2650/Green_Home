using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_home.Pages.Shared;

public class Ejendomme : PageModel
{
    private readonly ILogger<Model.Ejendomme> _logger;
    private readonly EjendommeRepository_DB _ejendommeRepositoryDb;

    public Ejendomme(ILogger<Model.Ejendomme> logger, EjendommeRepository_DB ejendommeRepositoryDb)
    {
        _logger = logger;
        _ejendommeRepositoryDb = ejendommeRepositoryDb;
    }

    [BindProperty]
    public string? Search { get; set; }
    
    public List<Model.Ejendomme> Ejedomme { get; set; }
    
    public void OnGet()
    {
        Ejedomme = _ejendommeRepositoryDb.GetAll();
    }
    
    
}