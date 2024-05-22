using Microsoft.Identity.Client;

namespace Green_home.Model
{
    public class Admin
    {
        // Instans felter

        private int _admin_Id;
        private string _navn;
        private string _efternavn;
        private int _tlf_nr;
        private string _username;
        private string _password;

        // Proberties

        public int Admin_Id
        {
            get { return _admin_Id; }
            private set { _admin_Id = value; }
        }

        public string Navn 
        {   
            get { return _navn; } 
            set { _navn = value; }
        }

        public string Efternavn 
        { 
            get { return _efternavn;} 
            set { _efternavn = value; }
        }

        public int Tlf_nr 
        { 
            get { return _tlf_nr; } 
            set { _tlf_nr = value;}
        }

        public string Username 
        { 
            get { return _username; }
            set { _username = value; }
        }

        public string Password 
        { 
            get { return _password; }
            set { _password = value; }
        }

        public Admin(int admin_id, string navn, string efternavn, int tlf_nr, string username, string password)
        {
            Admin_Id = admin_id;
            Navn = navn;
            Efternavn = efternavn;
            Tlf_nr = tlf_nr;
            Username = username;
            Password = password;
        }

        public Admin() :this (1, "","",11223344,"","")
        {

        }

        public override string ToString()
        {
            return $"{{{nameof(Admin_Id)}={Admin_Id.ToString()}, {nameof(Navn)}={Navn}, {nameof(Efternavn)}={Efternavn}, {nameof(Tlf_nr)}={Tlf_nr.ToString()}, {nameof(Username)}={Username}, {nameof(Password)}={Password}}}";
        }
    }
}
