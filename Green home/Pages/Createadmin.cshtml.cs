using Green_home.Model;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

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
        public Admin NewAdmin { get; set; } = new Admin();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Admin admin = new Admin
            {
                Navn = NewAdmin.Navn,
                Efternavn = NewAdmin.Efternavn,
                Tlf_nr = NewAdmin.Tlf_nr,
                Username = NewAdmin.Username,
                Password = NewAdmin.Password,
            };

            _repo.CreateAdmin(admin);
            return RedirectToPage("/Green_Home");
        }
        public class AdminViewModel
        {
            public int Admin_Id { get; set; }

            [Required(ErrorMessage = "Feltet er påkrævet")]
            public string Navn { get; set; }

            [Required(ErrorMessage = "Feltet er påkrævet")]
            public string Efternavn { get; set; }

            [Required(ErrorMessage = "Feltet er påkrævet")]
            public int Tlf_nr { get; set; }

            [Required(ErrorMessage = "Feltet er påkrævet")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Feltet er påkrævet")]
            public string Password { get; set; }
        }
    }
}