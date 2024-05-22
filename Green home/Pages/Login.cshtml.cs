using Green_home.Model;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_home.Pages
{
    public class LoginModel : PageModel
    {
        IAdminRepository_DB _repo; 
        public LoginModel(IAdminRepository_DB db)
        {
            _repo = db; 
        }

        //Proberties

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
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
                bool validLogin = _repo.ReadLogin(Username, Password) != null;

                if (validLogin)
                {
                    // Hent admin-data
                    Admin admin = _repo.ReadLogin(Username, Password);

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

        //public IActionResult OnPost() 
        //{
        //    ModelState.Remove("ErrMessage"); 
        //    if (!ModelState.IsValid)
        //    {
        //        return Page(); 
        //    }
        //    Admin admin = null!;
        //    bool validlogin = _repo.ReadLogin(Username, Password) != null; 
        //    if (validlogin)
        //    {
        //        admin = _repo.ReadLogin(Username, Password); 
        //        SessionHelper.Set(admin, HttpContext);
        //        RedirectToPage("/Green_Home");
        //    }
        //    ErrMessage = "Ugyldigt brugernavn eller kodeord"; 
        //    return Page(); 

        //}
    }
}
