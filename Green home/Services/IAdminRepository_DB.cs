
using Green_home.Model;

namespace Green_home.Services
{
    public interface IAdminRepository_DB
    {
        public Admin ReadLogin(string username, string password);
        
    }
}
