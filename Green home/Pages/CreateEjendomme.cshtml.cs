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
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public float Pris { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public string Energimærke { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public int Kvm { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
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
            Green_home.Model.Ejendomme ejendomme = new Green_home.Model.Ejendomme(Id, Pris, Kvm, Energimærke.ToUpper(), Post_nr);
            _ejendommeRepository.AddEjendomme(ejendomme);

            return RedirectToPage("/EjendommeSite");
        }
    }
}