using Green_home.Model;
using Green_home.Services;
using Microsoft.Data.SqlClient;

namespace Green_home.Services 
{
    public class EjendommeRepository_DB : IEjendommeRepository_DB
    {
        public EjendommeRepository_DB() { 
        
        }

        public List<Ejendomme> GetAll()
        {
            string query = "SELECT * FROM EJENDOMME";

            List<Ejendomme> ejendommeList = new List<Ejendomme>();

            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ejendomme ejendomme = ReadEjendomme(reader);
                    ejendommeList.Add(ejendomme);
                }

                connection.Close();
            }
          //  ejendommeList.Sort(new EjendommeSortByPris());
            return ejendommeList;
        }

        public void AddEjendomme(Ejendomme addEjendomme)
        {
            string query = "INSERT INTO EJENDOMME(Pris, Kvm, Energimærke, By_Id) VALUES(@Pris, @Kvm, @Energimærke, @By_Id)";
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Pris", addEjendomme.Pris);
                cmd.Parameters.AddWithValue("@Kvm", addEjendomme.Kvm);
                cmd.Parameters.AddWithValue("@Energimærke", addEjendomme.Energimærke);
                cmd.Parameters.AddWithValue("@By_Id", addEjendomme.By_id);

                int rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Ejendomme was not added =" + addEjendomme);
                }

                connection.Close();
            }
        }

        public void DeleteEjendomme(int id)
        {
            string query = "DELETE FROM EJENDOMME WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 0)
                {
                    throw new ArgumentException("Kunne ikke slette Ejendomme med id=" + id);
                }

                connection.Close();
            }
        }

        public void UpdateEjendomme(int id, Ejendomme updateEjendomme) // Corrected method name
        {
            string query = "INSERT INTO EJENDOMME VALUES(@Id, @Pris, @Kvm, @Energimærke, @By_Id)";
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", updateEjendomme.Id);
                cmd.Parameters.AddWithValue("@Pris", updateEjendomme.Pris);
                cmd.Parameters.AddWithValue("@Kvm", updateEjendomme.Kvm);
                cmd.Parameters.AddWithValue("@Energimærke", updateEjendomme.Energimærke);
                cmd.Parameters.AddWithValue("@By_Id", updateEjendomme.By_id); // Corrected parameter name
                int row = cmd.ExecuteNonQuery();
                Console.WriteLine("Rows ændret " + row);

                connection.Close();
            }
        }

        private Ejendomme ReadEjendomme(SqlDataReader reader)
        {
            Ejendomme e = new Ejendomme();
            e.Id = reader.GetInt32(0);
            e.Pris = (float)reader.GetDouble(1);
            e.Kvm = reader.GetInt32(2);
            e.Energimærke = reader.GetString(3);
            e.By_id = reader.GetInt32(4); 
            return e;
        }
    }
}
