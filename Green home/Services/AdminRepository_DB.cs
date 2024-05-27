using Green_home.Model;
using Microsoft.Data.SqlClient;

namespace Green_home.Services
{
    public class AdminRepository_DB : IAdminRepository_DB
    {
        public AdminRepository_DB()
        {

        }

        public List<Admin> GetAll()
        {
            string query = "SELECT * FROM Mægler_Admin";

            List<Admin> AdminList = new List<Admin>();

            // Opretter forbindelse til databasen.
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                // Læser resultaterne fra databasen og opretter adminobjekter.
                while (reader.Read())
                {
                    Admin admin = ReadAdmin(reader);
                    AdminList.Add(admin);
                }

                connection.Close();
            }
            // Returnerer listen over admin.
            return AdminList;
        }
        public Admin ReadLogin(string username, string password)
        {
            Admin admin = null!;
            string query = "SELECT * FROM Mægler_Admin WHERE [Username] = @UID AND Kodeord = @KID"; 
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UID", username);
                    command.Parameters.AddWithValue("@KID", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            admin = new Admin
                            {
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.GetString(reader.GetOrdinal("Kodeord"))
                            };
                        }
                    }
                }
            }
            return admin; 
        }

        public void CreateAdmin(Admin admin)
        {
            string query = "INSERT INTO Mægler_Admin (Navn, Efternavn, Tlf_nr, Username, Kodeord) VALUES (@Navn,@Efternavn,@Tlf_nr,@Username, @Kodeord)";
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Navn", admin.Navn);
                    command.Parameters.AddWithValue("@Efternavn", admin.Efternavn);
                    command.Parameters.AddWithValue("@Tlf_nr", admin.Tlf_nr);
                    command.Parameters.AddWithValue("@Username", admin.Username);
                    command.Parameters.AddWithValue("@Kodeord", admin.Password);

                    command.ExecuteNonQuery();
                }
            }
        }
        private Admin ReadAdmin(SqlDataReader reader)
        {
            Admin a = new Admin();
            a.Admin_Id = reader.GetInt32(0);
            a.Navn = reader.GetString(1);
            a.Efternavn = reader.GetString(2);
            a.Tlf_nr = reader.GetInt32(3);
            a.Username = reader.GetString(4);
            a.Password = reader.GetString(5);
            return a;
        }
    }
}
