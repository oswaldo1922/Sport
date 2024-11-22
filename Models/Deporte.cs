using Npgsql;
using System.Data;

namespace SportBarca.Models
{
    public class Deporte : Conexion
    {
        public int IdDeporte { get; set; }
        public string NombreDeporte { get; set; }
        public string Descripcion { get; set; }
        public int IdEvento { get; set; }

        public Deporte(int idDeporte, string nombreDeporte, string descripcion, int idEvento)
        {
            IdDeporte = idDeporte;
            NombreDeporte = nombreDeporte;
            Descripcion = descripcion;
            IdEvento = idEvento;
        }

        public Deporte()
        {
        }

        public List<Deporte> GetDeportes()
        {
            const string sql = "SELECT * FROM deporte;";
            DataTable tabla = GetQuery(sql);
            List<Deporte> lstPersona = new List<Deporte>(); 
            if (tabla.Rows.Count < 1)
            {
                return lstPersona; 
            }
            foreach (DataRow fila in tabla.Rows) 
            {
                lstPersona.Add(new Deporte((int)fila["id_deporte"], (string)fila["nombre_deporte"], (string)fila["descripcion"], (int)fila["id_evento"]));
            } 
            return lstPersona;
        }

        public void AddDeporte(Deporte personita) 
        {
            const string sql = "Insert into deporte(nombre_deporte,descripcion,id_evento) values (:nomdep, :desc, :ideve);"; 
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>(); 
            NpgsqlParameter paramNombreDeporte = new NpgsqlParameter(":nomdep", personita.NombreDeporte); 
            NpgsqlParameter paramDescripcion = new NpgsqlParameter(":desc", personita.Descripcion);
            NpgsqlParameter paramIdEvento = new NpgsqlParameter(":ideve", personita.IdEvento);
            lstParams.Add(paramNombreDeporte); lstParams.Add(paramDescripcion); lstParams.Add(paramIdEvento); 
            GetQuery(sql, lstParams); 
        }

        public void EditDeporte(Deporte person)
        {
            const string SQL = "Update deporte set nombre_deporte=:nomdep, descripcion=:desc, id_deporte=:ideve where id_deporte=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", person.IdDeporte);
            NpgsqlParameter paramNombreDeporte = new NpgsqlParameter(":nomdep", person.NombreDeporte);
            NpgsqlParameter paramDescripcion = new NpgsqlParameter(":desc", person.Descripcion);
            NpgsqlParameter paramIdEvento = new NpgsqlParameter(":ideve", person.IdEvento);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId, paramNombreDeporte, paramDescripcion, paramIdEvento };
            GetQuery(SQL, lstParams);
        }

        public Deporte GetDeporteById(int id)
        {
            const string SQL = "Select * From deporte where id_deporte = :id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", id);
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { paramId };
            DataTable tabla = GetQuery(SQL, lstParameter);
            if (tabla.Rows.Count < 1) return new Deporte();
            foreach (DataRow row in tabla.Rows)
            {
                Deporte person = new Deporte();
                person.IdDeporte = (int)row["id_deporte"];
                person.NombreDeporte = (string)row["nombre_deporte"];
                person.Descripcion = (string)row["descripcion"];
                person.IdEvento = (int)row["id_evento"];
                return person;
            }
            return new Deporte();
        }

        public void EliminarDeporte(int IdDeporte)
        {
            const string SQL = "DELETE FROM deporte WHERE id_deporte=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", IdDeporte);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId };
            GetQuery(SQL, lstParams);
        }
    }
}