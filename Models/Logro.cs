using Npgsql;
using System.Data;

namespace SportBarca.Models
{
    public class Logro : Conexion
    {
        public int IdLogro { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaLogro { get; set; }

        public Logro(int idLogro, string descripcion, DateTime fechaLogro)
        {
            IdLogro = idLogro;
            Descripcion = descripcion;
            FechaLogro = fechaLogro;
        }
        public Logro()
        {
        }

        public List<Logro> GetLogros()
        {
            const string sql = "SELECT * FROM logro;";
            DataTable tabla = GetQuery(sql);
            List<Logro> lstPersona = new List<Logro>(); 
            if (tabla.Rows.Count < 1)                             
            {
                return lstPersona; 
            }
            foreach (DataRow fila in tabla.Rows)
            {
                lstPersona.Add(new Logro((int)fila["id_logro"], (string)fila["descripcion"], (DateTime)fila["fecha_logro"]));
            } 
            return lstPersona;
        }

        public void AddLogro(Logro personita)
        {
            const string sql = "Insert into logro(descripcion,fecha_logro) values (:desc, :fechlog);";
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>(); 
            NpgsqlParameter paramDescripcion = new NpgsqlParameter(":desc", personita.Descripcion); 
            NpgsqlParameter paramFechaLogro = new NpgsqlParameter(":fechlog", personita.FechaLogro);
            lstParams.Add(paramDescripcion); lstParams.Add(paramFechaLogro); 
            GetQuery(sql, lstParams); 
        }

        public void EditLogro(Logro person)
        {
            const string SQL = "Update logro set descripcion=:desc, fecha_logro=:fechlog where id_logro=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", person.IdLogro);
            NpgsqlParameter paramDescripcion = new NpgsqlParameter(":desc", person.Descripcion);
            NpgsqlParameter paramFechaLogro = new NpgsqlParameter(":fechlog", person.FechaLogro);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId, paramDescripcion, paramFechaLogro };
            GetQuery(SQL, lstParams);
        }

        public Logro GetLogroById(int id)
        {
            const string SQL = "Select * From logro where id_logro = :id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", id);
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { paramId };
            DataTable tabla = GetQuery(SQL, lstParameter);
            if (tabla.Rows.Count < 1) return new Logro();
            foreach (DataRow row in tabla.Rows)
            {
                Logro person = new Logro();
                person.IdLogro = (int)row["id_logro"];
                person.Descripcion = (string)row["descripcion"];
                person.FechaLogro = (DateTime)row["fecha_logro"];

                return person;
            }
            return new Logro();
        }

        public void EliminarLogro(int IdLogro)
        {
            const string SQL = "DELETE FROM logro WHERE id_logro=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", IdLogro);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId };
            GetQuery(SQL, lstParams);
        }
    }
}