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
        public AdminViewModel NewAdmin { get; set; } = new AdminViewModel();

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
                Tlf_nr = NewAdmin.Tlf_nr ?? 0,
                Username = NewAdmin.Username,
                Password = NewAdmin.Password,
            };

            _repo.CreateAdmin(admin);
            return RedirectToPage("/Green_Home");
        }

        public class AdminViewModel
        {
            public int Admin_Id { get; set; }

            [Required(ErrorMessage = "Indtast venligst fornavn.")]
            [StringLength(1000, MinimumLength = 2, ErrorMessage = "Fornavnet skal være mindst 2 tegn")]
            public string Navn { get; set; }

            [Required(ErrorMessage = "Indtast venligst efternavn.")]
            [StringLength(1000, MinimumLength = 2, ErrorMessage = "Efternavnet skal være mindst 2 tegn")]
            public string Efternavn { get; set; }

            [Required(ErrorMessage = "Indtast venligst telefonnummer.")]
            [Range(10000000, 99999999, ErrorMessage = "Telefonnummer skal være 8 cifre.")]
            public int? Tlf_nr { get; set; }

            [Required(ErrorMessage = "Indtast venligst et brugernavn.")]
            [StringLength(30, MinimumLength = 3, ErrorMessage = "Brugernavnet skal være på mellem 3 og 30 tegn")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Indtast venligst et kodeord.")]
            [StringLength(30, MinimumLength = 3, ErrorMessage = "Kodeordet skal være på mellem 3 og 30 tegn")]
            public string Password { get; set; }
        }
    }
}
