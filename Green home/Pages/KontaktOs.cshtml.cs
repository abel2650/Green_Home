using Green_home.Model;
using Green_home.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Green_home.Pages
{
    public class KontaktOsModel : PageModel
    {
        private readonly IAdminRepository_DB _adminRepository;

        public KontaktOsModel(IAdminRepository_DB adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public List<Admin> AdminList { get; set; }

        public void OnGet()
        {
            AdminList = _adminRepository.GetAll();
        }
    }
}
