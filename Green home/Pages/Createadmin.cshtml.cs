using Green_home.Model;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_home.Pages
{
    public class CreateAdminModel : PageModel
    {
        private readonly IAdminRepository_DB _repo;

        public CreateAdminModel(IAdminRepository_DB repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Admin NewAdmin { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.CreateAdmin(NewAdmin);
            return RedirectToPage("/Green_Home");
        }
    }
}