using Hospital_Parcial_Rio.Models;
using Microsoft.Data.SqlClient;

namespace Hospital_Parcial_Rio.Data
{
    public class BaseDatos
    {
        private string conexionString = "Server=(localdb)\\mssqllocaldb;Database=Hospital_Parcial_Rio;Trusted_Connection=True;MultipleActiveResultSets=True";


        public List<Obra_Social> ObtenerObras_Sociales(int obra_socialBusq)
        {
            List<Obra_Social> lista = new List<Obra_Social>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "SELECT * FROM Obras_sociales";
                if (obra_socialBusq > 0)
                    query = "SELECT * FROM Obras_sociales WHERE id = " + obra_socialBusq;

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Obra_Social
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }

            return lista;

        }
        public List<Sintoma> ObtenerSintomas(int sintomaBusq)
        {
            List<Sintoma> lista = new List<Sintoma>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "SELECT * FROM Sintomas";
                if (sintomaBusq > 0)
                    query = "SELECT * FROM Sintomas WHERE id = " + sintomaBusq;

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Sintoma
                    {
                        Id = (int)reader["Id"],
                        Descripcion = reader["Descripcion"].ToString()
                    });
                }
            }

            return lista;

        }
        public List<Paciente> ObtenerPacientes(int idBusqueda)
        {
            List<Paciente> lista = new List<Paciente>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "SELECT * FROM Pacientes";
                if (idBusqueda > 0)
                    query = $"SELECT * FROM Pacientes WHERE id = {idBusqueda}";

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Paciente
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Edad = (int)reader["Edad"],
                        Obra_SocialId = (int)reader["Obra_SocialId"],
                        obra_social = ObtenerObras_Sociales((int)reader["Obra_SocialId"]).FirstOrDefault(),
                        SintomaId = (int)reader["SintomaId"],
                        sintoma = ObtenerSintomas((int)reader["SintomaId"]).FirstOrDefault()
                    });
                }
            }

            return lista;
        }
        public string GuardarPaciente(Paciente paciente)
        {
            List<Paciente> lista = new List<Paciente>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                try
                {
                    string query = $"INSERT INTO Pacientes (Nombre, Edad, Obra_SocialId, SintomaId)";
                    query += $" VALUES ('{paciente.Nombre}', '{paciente.Edad}', '{paciente.Obra_SocialId}', '{paciente.SintomaId}')";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    return "Ocurrió un error al guardar el paciente: " + ex.Message;
                    throw;
                }
            }

            return "";
        }
        public string GuardarSintomas(Sintoma sintoma)
        {
            List<Sintoma> lista = new List<Sintoma>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                try
                {
                    string query = $"INSERT INTO Sintomas (Descripcion)";
                    query += $" VALUES ('{sintoma.Descripcion}')";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    return "Ocurrió un error al guardar el sintoma: " + ex.Message;
                    throw;
                }
            }

            return "";
        }
    }
}
