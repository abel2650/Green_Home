using Green_home.Model;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_home.Pages;

public class DeleteEjendom : PageModel
{
    private readonly IEjendommeRepository_DB _ejendommeRepositoryDb;
    private readonly ILogger<DeleteEjendom> _logger;

    public DeleteEjendom (IEjendommeRepository_DB repo, ILogger<DeleteEjendom> logger)
    {
        _ejendommeRepositoryDb = repo;
        _logger = logger;
    }

    public List<Ejendomme> Ejendomme { get; set; }

    public void OnGet()
    {
        Ejendomme = _ejendommeRepositoryDb.GetAll();
    }

    public IActionResult OnPostDelete(int id)
    {
        try
        {
            _ejendommeRepositoryDb.DeleteEjendomme(id);
            return RedirectToPage("/DeleteEjendom");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Fejl ved at slette ejendom{id}: {ex.Message}");
            return Page();
        }
    }
}