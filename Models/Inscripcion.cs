using Npgsql;
using System.Data;

namespace SportBarca.Models
{
    public class Inscripcion : Conexion
    {
        public int IdInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Estado { get; set; }

        public Inscripcion(int idInscripcion, DateTime fechaInscripcion, string estado)
        {
            IdInscripcion = idInscripcion;
            FechaInscripcion = fechaInscripcion;
            Estado = estado;
        }

        public Inscripcion()
        {
        }

        public List<Inscripcion> GetInscripciones()
        {
            const string sql = "SELECT * FROM inscripcion;";
            DataTable tabla = GetQuery(sql);
            List<Inscripcion> lstPersona = new List<Inscripcion>(); 
            if (tabla.Rows.Count < 1)
            {
                return lstPersona; 
            }
            foreach (DataRow fila in tabla.Rows) 
            {
                lstPersona.Add(new Inscripcion((int)fila["id_inscripcion"], (DateTime)fila["fecha_inscripcion"], (string)fila["estado"]));
            } 
            return lstPersona;
        }

        public void AddInscripcion(Inscripcion personita) 
        {
            const string sql = "Insert into inscripcion(fecha_inscripcion,estado) values (:fechins, :estado);"; 
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>(); 
            NpgsqlParameter paramFechaInscripcion = new NpgsqlParameter(":fechins", personita.FechaInscripcion); 
            NpgsqlParameter paramEstado = new NpgsqlParameter(":estado", personita.Estado);
            lstParams.Add(paramFechaInscripcion); lstParams.Add(paramEstado);
            GetQuery(sql, lstParams); 
        }

        public void EditInscripcion(Inscripcion person)
        {
            const string SQL = "Update inscripcion set fecha_inscripcion=:fechins, estado=:estado where id_inscripcion=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", person.IdInscripcion);
            NpgsqlParameter paramFechaInscripcion = new NpgsqlParameter(":fechins", person.FechaInscripcion);
            NpgsqlParameter paramEstado = new NpgsqlParameter(":estado", person.Estado);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId, paramFechaInscripcion, paramEstado };
            GetQuery(SQL, lstParams);
        }

        public Inscripcion GetInscripcionById(int id)
        {
            const string SQL = "Select * From inscripcion where id_inscripcion = :id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", id);
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { paramId };
            DataTable tabla = GetQuery(SQL, lstParameter);
            if (tabla.Rows.Count < 1) return new Inscripcion();
            foreach (DataRow row in tabla.Rows)
            {
                Inscripcion person = new Inscripcion();
                person.IdInscripcion = (int)row["id_inscripcion"];
                person.FechaInscripcion = (DateTime)row["fecha_inscripcion"];
                person.Estado = (string)row["estado"];
                return person;
            }
            return new Inscripcion();
        }

        public void EliminarInscripcion(int IdInscripcion)
        {
            const string SQL = "DELETE FROM inscripcion WHERE id_inscripcion=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", IdInscripcion);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId };
            GetQuery(SQL, lstParams);
        }
    }
}