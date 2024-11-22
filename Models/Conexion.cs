using System.Data;
using Npgsql;

namespace SportBarca.Models
{
    public class Conexion
    {
        private string strConexion;
        protected Conexion()
        {
            strConexion = "Server=localhost;Username=postgres;Database=sportbarca;Password=root;";
        }
        protected DataTable GetQuery(string sql)
        {
            DataTable tabla = new DataTable(); 
            NpgsqlDataAdapter adaptador = new(); 
            try
            {
                using NpgsqlConnection _con = new(); 
                _con.ConnectionString = strConexion;
                _con.Open(); 
                using NpgsqlCommand comando = new(); 
                comando.Connection = _con; 
                comando.CommandText = sql; 
                adaptador.SelectCommand = comando;
                using NpgsqlDataReader lector = comando.ExecuteReader(); 
                if (lector.HasRows) 
                {
                    tabla.Load(lector); 
                }
                lector.Close();
                _con.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message); 
            }
            return tabla; 
        } 
        protected DataTable GetQuery(string sql, List<NpgsqlParameter> parametros) 
        {
            DataTable tabla = new DataTable(); 
            NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(); 
            using (NpgsqlConnection _con = new NpgsqlConnection()) 
            {
                _con.ConnectionString = strConexion; 
                _con.Open(); 
                using (NpgsqlCommand comando = new NpgsqlCommand())
                {
                    comando.Connection = _con; 
                    comando.CommandText = sql; 
                    comando.Parameters.Clear();
                    foreach (NpgsqlParameter param in parametros) 
                    {
                        comando.Parameters.Add(param);
                    }
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(tabla); 
                }
                _con.Close();
            }
            return tabla; 
        }
    } 
}