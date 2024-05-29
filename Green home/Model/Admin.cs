using Microsoft.Identity.Client;

namespace Green_home.Model
{
    public class Admin
    {

        private int _admin_Id;
        private string _navn;
        private string _efternavn;
        private int _tlf_nr;
        private string _username;
        private string _password;

        public int Admin_Id { get; set; }

        public string Navn { get; set; }

        public string Efternavn { get; set; }

        public int Tlf_nr { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Admin(int admin_id, string navn, string efternavn, int tlf_nr, string username, string password)
        {
            Admin_Id = admin_id;
            Navn = navn;
            Efternavn = efternavn;
            Tlf_nr = tlf_nr;
            Username = username;
            Password = password;
        }

        public Admin()
        {

        }

        public override string ToString()
        {
            return $"{{{nameof(Admin_Id)}={Admin_Id.ToString()}, {nameof(Navn)}={Navn}, {nameof(Efternavn)}={Efternavn}, {nameof(Tlf_nr)}={Tlf_nr.ToString()}, {nameof(Username)}={Username}, {nameof(Password)}={Password}}}";
        }
    }
}
