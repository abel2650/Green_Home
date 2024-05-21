using Green_home.Model; // Importerer namespace for ejendomsmodellen.
using Green_home.Services;
using Microsoft.Data.SqlClient;

namespace Green_home.Services 
{
    // Dette er en repository-klasse, der håndterer databasen for ejendomme.
    public class EjendommeRepository_DB : IEjendommeRepository_DB
    {
        public EjendommeRepository_DB() { 
        
        }

        // Metode til at hente alle ejendomme fra databasen.
        public List<Ejendomme> GetAll()
        {
            string query = "SELECT * FROM EJENDOMME";

            List<Ejendomme> ejendommeList = new List<Ejendomme>();

            // Opretter forbindelse til databasen.
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                // Læser resultaterne fra databasen og opretter ejendommeobjekter.
                while (reader.Read())
                {
                    Ejendomme ejendomme = ReadEjendomme(reader);
                    ejendommeList.Add(ejendomme);
                }

                connection.Close();
            }
            // Returnerer listen over ejendomme.
            return ejendommeList;
        }

        // Metode til at tilføje en ny ejendom til databasen.
        public void AddEjendomme(Ejendomme addEjendomme)
        {
            string query = "INSERT INTO EJENDOMME(Pris, Kvm, Energimærke, Post_nr) VALUES(@Pris, @Kvm, @Energimærke, @Post_nr)";
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Pris", addEjendomme.Pris);
                cmd.Parameters.AddWithValue("@Kvm", addEjendomme.Kvm);
                cmd.Parameters.AddWithValue("@Energimærke", addEjendomme.Energimærke);
                cmd.Parameters.AddWithValue("@Post_nr", addEjendomme.Post_nr);

                int rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Ejendomme was not added =" + addEjendomme);
                }

                connection.Close();
            }
        }

        // Metode til at slette en ejendom fra databasen baseret på dens ID.
        public void DeleteEjendomme(int id)
        {
            string query = "DELETE FROM EJENDOMME WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                int rows = cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        // Metode til at opdatere en ejendom i databasen baseret på dens ID.
        public void UpdateEjendomme(int id, Ejendomme updateEjendomme)
        {
            string query = "INSERT INTO EJENDOMME VALUES(@Id, @Pris, @Kvm, @Energimærke, @Post_nr)";
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", updateEjendomme.Id);
                cmd.Parameters.AddWithValue("@Pris", updateEjendomme.Pris);
                cmd.Parameters.AddWithValue("@Kvm", updateEjendomme.Kvm);
                cmd.Parameters.AddWithValue("@Energimærke", updateEjendomme.Energimærke);
                cmd.Parameters.AddWithValue("@Post_nr", updateEjendomme.Post_nr);
                int row = cmd.ExecuteNonQuery();
                Console.WriteLine("Rows ændret " + row);

                connection.Close();
            }
        }

        // Metode til at hente ejendomme fra databasen baseret på deres energimærke.
        public List<Ejendomme> GetByEnergimaerke(string energimaerke)
        {
            string query = "SELECT * FROM EJENDOMME WHERE Energimærke = @Energimærke";
            List<Ejendomme> ejendommeList = new List<Ejendomme>();

            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Energimærke", energimaerke);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ejendomme ejendomme = ReadEjendomme(reader);
                    ejendommeList.Add(ejendomme);
                }
                connection.Close();
            }
            return ejendommeList;
        }

        // Hjælpemetode til at læse en ejendom fra en SqlDataReader og returnere den.
        private Ejendomme ReadEjendomme(SqlDataReader reader)
        {
            Ejendomme e = new Ejendomme();
            e.Id = reader.GetInt32(0);
            e.Pris = reader.GetDouble(1);
            e.Kvm = reader.GetInt32(2);
            e.Energimærke = reader.GetString(3);
            e.Post_nr = reader.GetInt32(4); 
            return e;
        }
    }
}
