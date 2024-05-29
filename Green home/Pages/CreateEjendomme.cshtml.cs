using System.ComponentModel.DataAnnotations;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_home.Model;

namespace Green_home.Pages
{
    public class CreateEjendommeModel : PageModel
    {
        private readonly IEjendommeRepository_DB _ejendommeRepository;

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Indtast venligst ejendommens pris")]
        public float? Pris { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Indtast venligst ejendommens energimærke")]
        [RegularExpression("^[a-cA-C]$", ErrorMessage = "Energimærke skal være enten 'A', 'B' eller 'C'.")]
        public string Energimærke { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Indtast venligst en Kvadratmeter på ejendommen.")]
        [Range(1, int.MaxValue, ErrorMessage = "Værdien skal være et positivt tal")]
        public int? Kvm { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Indtast venligst ejendommens Post nr.")]
        [Range(1000, 9999, ErrorMessage = "Post nr. skal være mellem 1000 og 9999.")]
        public int? Post_nr { get; set; }

        public CreateEjendommeModel(IEjendommeRepository_DB ejendommeRepository)
        {
            _ejendommeRepository = ejendommeRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Ejendomme ejendomme = new Ejendomme
            {
                Pris = Pris ?? 0,
                Kvm = Kvm ?? 0,
                Energimærke = Energimærke.ToUpper(),
                Post_nr = Post_nr ?? 0,
            };

            _ejendommeRepository.AddEjendomme(ejendomme);

            return RedirectToPage("/EjendommeSite");
        }
    }
}