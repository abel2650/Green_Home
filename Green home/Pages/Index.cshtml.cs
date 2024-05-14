using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_home.Pages;

public class Ejendomme : PageModel
{
    private readonly ILogger<Ejendomme> _logger;

    public Ejendomme(ILogger<Ejendomme> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}