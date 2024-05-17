using Green_home.Model;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_home.Pages
{
    public class EjendommeSiteModel : PageModel
    {
        ILogger<Ejendomme> _logger;
        IEjendommeRepository_DB _ejendommeRepositoryDb;
        public EjendommeSiteModel(ILogger<Ejendomme> logger, IEjendommeRepository_DB repo)
        {
            _ejendommeRepositoryDb = repo;
            _logger = logger;
        }
        public List<Ejendomme> Ejendomme { get; set; }

        public void OnGet()
        {
            Ejendomme = _ejendommeRepositoryDb.GetAll();
        }

        public IActionResult OnPost(string sortorder)
        {
            if (sortorder == "ByID")
            {
                Ejendomme = _ejendommeRepositoryDb.GetAll();
                Ejendomme.Sort(new EjendommeSort.SortById());
                return Page();

            }

            else if (sortorder == "ByPris")
            {
                Ejendomme = _ejendommeRepositoryDb.GetAll();
                Ejendomme.Sort(new EjendommeSort.SortByPris());
            }

            else if (sortorder == "ByKvm")
            {
                Ejendomme = _ejendommeRepositoryDb.GetAll();
                Ejendomme.Sort(new EjendommeSort.SortByKvm());
            }

            else if (sortorder == "ByEnergimærke")
            {
                Ejendomme = _ejendommeRepositoryDb.GetAll();
                Ejendomme.Sort(new EjendommeSort.SortByEnergimaerke());
            }


            return Page();
        }
        

    }
}