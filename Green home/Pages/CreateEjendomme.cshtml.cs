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
        //[Required(ErrorMessage = "Feltet er påkrævet")]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public float Pris { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        [RegularExpression("^[a-cA-C]$", ErrorMessage = "Energimærke skal være enten 'A', 'B' eller 'C'.")]
        public string Energimærke { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        [Range(1, int.MaxValue, ErrorMessage = "Værdien skal være et positivt tal")]
        public int Kvm { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste et Post nr.")]
        [Range(1000, 9999, ErrorMessage = "Post nr. skal være mellem 1000 og 9999.")]
        public int Post_nr { get; set; }

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
                Pris = Pris,
                Kvm = Kvm,
                Energimærke = Energimærke.ToUpper(),
                Post_nr = Post_nr
            };

            _ejendommeRepository.AddEjendomme(ejendomme);

            return RedirectToPage("/EjendommeSite");
        }
    }
}