using Green_home.Model;
using Microsoft.Data.SqlClient;

namespace Green_home.Services
{
    public class AdminRepository_DB : IAdminRepository_DB
    {
        public AdminRepository_DB()
        {

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
    }
}
