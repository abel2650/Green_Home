using Green_home.Model;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Green_home.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAdminRepository_DB _repo; 

        public LoginModel(IAdminRepository_DB db)
        {
            _repo = db; 
        }

        // Properties
        [BindProperty]
        public string Brugernavn { get; set; }
        [BindProperty]
        public string Kodeord { get; set; }
        [BindProperty]
        public string ErrMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Fjern ErrMessage fra ModelState for at undgå valideringsproblemer
            ModelState.Remove("ErrMessage");

            // Kontroller om modeltilstanden er gyldig
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Kontroller om login er gyldigt
                Admin admin = _repo.ReadLogin(Brugernavn, Kodeord);

                if (admin != null)
                {
                    // Sæt admin-data i session
                    SessionHelper.Set(admin, HttpContext);

                    // Redirect til en anden side
                    return RedirectToPage("/Green_Home");
                }
                else
                {
                    ErrMessage = "Ugyldigt brugernavn eller kodeord";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Log fejlen (brug din foretrukne logging framework)
                Console.WriteLine($"Error during login: {ex.Message}");

                // Sæt en generisk fejlmeddelelse
                ErrMessage = "Der opstod en fejl under login. Prøv venligst igen senere.";
                return Page();
            }
        }

        public IActionResult OnPostLogout()
        {
            // Fjern admin-data fra session
            Admin a = null!;
            a = SessionHelper.Get<Admin>(a, HttpContext);
            SessionHelper.Clear<Admin>(a, HttpContext);

            // Redirect til forsiden eller login siden
            return RedirectToPage("/Green_Home");
        }
    }
}
