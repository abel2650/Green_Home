using Green_home.Model;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_home.Pages
{
    public class UpdateEjendomModel : PageModel
    {
        private readonly IEjendommeRepository_DB _ejendommeRepository;

        [BindProperty]
        public Ejendomme Ejendom { get; set; }

        public UpdateEjendomModel(IEjendommeRepository_DB ejendommeRepository)
        {
            _ejendommeRepository = ejendommeRepository;
        }

        public IActionResult OnGet(int id)
        {
            Admin admin = null;
            try { admin = SessionHelper.Get<Admin>(admin, HttpContext); }
            catch { return RedirectToPage("/Green_Home"); }

            Ejendom = _ejendommeRepository.GetAll().FirstOrDefault(e => e.Id == id);
            if (Ejendom == null)
            {
                return RedirectToPage("/DeleteEjendom");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ejendommeRepository.UpdateEjendomme(Ejendom.Id, Ejendom);
            return RedirectToPage("/DeleteEjendom");
        }
    }
}