using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_home.Pages.Shared;

public class EjendommeModel : PageModel
{
    private readonly ILogger<Model.Ejendomme> _logger;
    private readonly IEjendommeRepository_DB _ejendommeRepositoryDb;

    public EjendommeModel(ILogger<Model.Ejendomme> logger, IEjendommeRepository_DB ejendommeRepositoryDb)
    {
        _logger = logger;
        _ejendommeRepositoryDb = ejendommeRepositoryDb;
    }

    

    public List<Model.Ejendomme> Ejedomme { get; set; }

    public void OnGet()
    {
        Ejedomme = _ejendommeRepositoryDb.GetAll();
    }

    public IActionResult OnPost(string sortorder)
    {
        if (sortorder == "ByID")
        {
            Ejedomme = _ejendommeRepositoryDb.GetAll();
            Ejedomme.Sort(new EjendommeSortById());
            return Page();
            
        }
        
        else if (sortorder == "ByPris")
        {
            Ejedomme = _ejendommeRepositoryDb.GetAll();
            Ejedomme.Sort(new EjendommeSortByPris());
        }
        
        else if (sortorder == "ByKvm")
        {
            Ejedomme = _ejendommeRepositoryDb.GetAll();
            Ejedomme.Sort(new EjendommeSortByKvm());
        }
        
        else if (sortorder == "ByEnergimærke")
        {
            Ejedomme = _ejendommeRepositoryDb.GetAll();
            Ejedomme.Sort(new EjendommeSortByEnergimærke());
        }
        
        
        return Page();
    }
    
}