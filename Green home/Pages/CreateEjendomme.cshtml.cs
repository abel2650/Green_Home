using System.ComponentModel.DataAnnotations;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_home.Model;

namespace Green_home.Pages
{
    public class CreateEjendomme : PageModel
    {
        private readonly EjendommeRepository_DB _ejendommeRepository;

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet"), MaxLength(50)]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public float Pris { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet"), MaxLength(1)]
        public string Energimærke { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public int Kvm { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public int By_id { get; set; }

        public CreateEjendomme(EjendommeRepository_DB ejendommeRepository)
        {
            _ejendommeRepository = ejendommeRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Green_home.Model.Ejendomme ejendomme = new Green_home.Model.Ejendomme(Id, Pris, Kvm, Energimærke, By_id);
            _ejendommeRepository.AddEjendomme(ejendomme);

            return RedirectToPage("/EjendommeModel");
        }
    }
}