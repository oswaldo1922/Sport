using Npgsql;
using System.Data;

namespace SportBarca.Models
{
    public class Evento : Conexion
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int IdInscripcion { get; set; }
        public int IdLogro { get; set; }

        public Evento()
        {
        }

        public Evento(int idEvento, string nombreEvento, string descripcion, DateTime fechaInicion, DateTime fechaFin, decimal latitud, decimal longitud, int idInscripcion, int idLogro)
        {
            IdEvento = idEvento;
            NombreEvento = nombreEvento;
            Descripcion = descripcion;
            FechaInicio = fechaInicion;
            FechaFin = fechaFin;
            Latitud = latitud;
            Longitud = longitud;
            IdInscripcion = idInscripcion;
            IdLogro = idLogro;
        }
        
        public List<Evento> GetEventos()
        {
            const string sql = "SELECT * FROM evento;";
            DataTable tabla = GetQuery(sql);
            List<Evento> lstEvento = new List<Evento>(); 

            if (tabla.Rows.Count < 1)
            {
                return lstEvento; 
            }

            foreach (DataRow fila in tabla.Rows) 
            {
                lstEvento.Add(new Evento(
                    (int)fila["id_evento"],
                    (string)fila["nombre_evento"],
                    (string)fila["descripcion"],
                    (DateTime)fila["fecha_inicio"],
                    (DateTime)fila["fecha_fin"],
                    (decimal)fila["latitud"],
                    (decimal)fila["longitud"],
                    (int)fila["id_inscripcion"],
                    (int)fila["id_logro"]
                ));
            }
            return lstEvento;
        }

        public void AddEvento(Evento personita) 
        {
            const string sql = "Insert into evento(nombre_evento,descripcion,fecha_inicio,fecha_fin,latitud,longitud,id_inscripcion,id_logro) values (:nome, :desc, :fechin, :fechfin, :lati, :long, :idins, :idlog);";
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>();
            NpgsqlParameter paramNombreEvento = new NpgsqlParameter(":nome", personita.NombreEvento);
            NpgsqlParameter paramDescripcion = new NpgsqlParameter(":desc", personita.Descripcion);
            NpgsqlParameter paramFechaInicio = new NpgsqlParameter(":fechin", personita.FechaInicio);
            NpgsqlParameter paramFechaFin = new NpgsqlParameter(":fechfin", personita.FechaFin);
            NpgsqlParameter paramLatitud = new NpgsqlParameter(":lati", personita.Latitud);
            NpgsqlParameter paramLongitud = new NpgsqlParameter(":long", personita.Longitud);
            NpgsqlParameter paramIdInscripcion = new NpgsqlParameter(":idins", personita.IdInscripcion);
            NpgsqlParameter paramIdLogro = new NpgsqlParameter(":idlog", personita.IdLogro);
            lstParams.Add(paramNombreEvento); lstParams.Add(paramDescripcion); lstParams.Add(paramFechaInicio); lstParams.Add(paramFechaFin); lstParams.Add(paramLatitud);
            lstParams.Add(paramLongitud); lstParams.Add(paramIdInscripcion); lstParams.Add(paramIdLogro);
            GetQuery(sql, lstParams);
        }

        public void EditEvento(Evento person)
        {
            const string SQL = "Update evento set nombre_evento=:nome, descripcion=:desc, fecha_inicio=:fechin, fecha_fin=:fechfin, latitud=:lati, longitud=:long, id_inscripcion=:idins, id_logro=:idlog where id_evento=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", person.IdEvento);
            NpgsqlParameter paramNombreEvento = new NpgsqlParameter(":nome", person.NombreEvento);
            NpgsqlParameter paramDescripcion = new NpgsqlParameter(":desc", person.Descripcion);
            NpgsqlParameter paramFechaInicio = new NpgsqlParameter(":fechin", person.FechaInicio);
            NpgsqlParameter paramFechaFin = new NpgsqlParameter(":fechfin", person.FechaFin);
            NpgsqlParameter paramLatitud = new NpgsqlParameter(":lati", person.Latitud);
            NpgsqlParameter paramLongitud = new NpgsqlParameter(":long", person.Longitud);
            NpgsqlParameter paramIdInscripcion = new NpgsqlParameter(":idins", person.IdInscripcion);
            NpgsqlParameter paramIdLogro = new NpgsqlParameter(":idlog", person.IdEvento);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId, paramNombreEvento, paramDescripcion, paramFechaInicio, paramFechaFin, paramLatitud, paramLongitud, paramIdInscripcion, paramIdLogro };
            GetQuery(SQL, lstParams);
        }

        public Evento GetEventoById(int id)
        {
            const string SQL = "Select * From evento where id_evento = :id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", id);
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { paramId };
            DataTable tabla = GetQuery(SQL, lstParameter);
            if (tabla.Rows.Count < 1) return new Evento();
            foreach (DataRow row in tabla.Rows)
            {
                Evento person = new Evento();
                person.IdEvento = (int)row["id_evento"];
                person.NombreEvento = (string)row["nombre_evento"];
                person.Descripcion = (string)row["descripcion"];
                person.FechaInicio = (DateTime)row["fecha_inicio"];
                person.FechaFin = (DateTime)row["fecha_fin"];
                person.Latitud = (decimal)row["latitud"];
                person.Longitud = (decimal)row["longitud"];
                person.IdInscripcion = (int)row["id_inscripcion"];
                person.IdLogro = (int)row["id_logro"];
                return person;
            }
            return new Evento();
        }

        public void EliminarEvento(int IdEvento)
        {
            const string SQL = "DELETE FROM evento WHERE id_evento=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", IdEvento);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId };
            GetQuery(SQL, lstParams);
        }
    }
    }