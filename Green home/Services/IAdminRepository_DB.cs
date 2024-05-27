
using Green_home.Model;

namespace Green_home.Services
{
    public interface IAdminRepository_DB
    {
        List<Admin> GetAll();
        public Admin ReadLogin(string username, string password);
        void CreateAdmin(Admin admin);
    }
}
