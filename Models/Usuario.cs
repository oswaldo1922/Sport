using Npgsql;
using System.Data;

namespace SportBarca.Models
{
    public class Usuario : Conexion
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set;  }
        public string Contrasena { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public int CodigoPostal { get; set; }
        public int NoInterior { get; set; }
        public int NoExterior { get; set; }
        public int IdInscripcion { get; set; }
        public int IdLogro { get; set; }

        public Usuario()
        {
        }
        public Usuario(int idUsuario, string nombre, string apellidos, string correo, string contrasena, string calle, string colonia, int codigoPostal, int noInterior, int noExterior, int idInscripcion, int idLogro)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellidos = apellidos;
            Correo = correo;
            Contrasena = contrasena;
            Calle = calle;
            Colonia = colonia;
            CodigoPostal = codigoPostal;
            NoInterior = noInterior;
            NoExterior = noExterior;
            IdInscripcion = idInscripcion;
            IdLogro = idLogro;
        }
        public List<Usuario> GetUsuarios()
        {
            const string sql = "SELECT * FROM usuario;";
            DataTable tabla = GetQuery(sql);
            List<Usuario> lstPersona = new List<Usuario>();
            if (tabla.Rows.Count < 1)
            {
                return lstPersona;
            }
            foreach (DataRow fila in tabla.Rows) 
            {
                lstPersona.Add(new Usuario((int)fila["id_usuario"], (string)fila["nombre"], (string)fila["apellidos"], (string)fila["correo"], (string)fila["contrasena"], (string)fila["calle"], (string)fila["colonia"], (int)fila["codigo_postal"], (int)fila["no_interior"], (int)fila["no_exterior"], (int)fila["id_inscripcion"], (int)fila["id_logro"]));
            } 
            return lstPersona;
        }
        public void AddUsuario(Usuario personita) 
        {
            const string sql = "Insert into usuario(nombre,apellidos,correo,contrasena,calle,colonia,codigo_postal,no_interior,no_exterior,id_inscripcion,id_logro) values (:nom, :ap, :email, :contra, :call, :colo, :cp, :noin, :noext, :idins, :idlog);";
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>(); 
            NpgsqlParameter paramNombre = new NpgsqlParameter(":nom", personita.Nombre); 
            NpgsqlParameter paramAp = new NpgsqlParameter(":ap", personita.Apellidos);
            NpgsqlParameter paramCorreo = new NpgsqlParameter(":email", personita.Correo);
            NpgsqlParameter paramContrasena = new NpgsqlParameter(":contra", personita.Contrasena);
            NpgsqlParameter paramCalle = new NpgsqlParameter(":call", personita.Calle);
            NpgsqlParameter paramColonia = new NpgsqlParameter(":colo", personita.Colonia);
            NpgsqlParameter paramCodigoPostal = new NpgsqlParameter(":cp", personita.CodigoPostal);
            NpgsqlParameter paramNoInterior = new NpgsqlParameter(":noin", personita.NoInterior);
            NpgsqlParameter paramNoExterior = new NpgsqlParameter(":noext", personita.NoExterior);
            NpgsqlParameter paramIdInscripcion = new NpgsqlParameter(":idins", personita.IdInscripcion);
            NpgsqlParameter paramIdLogro = new NpgsqlParameter(":idlog", personita.IdLogro);
            lstParams.Add(paramNombre); lstParams.Add(paramAp); lstParams.Add(paramCorreo); lstParams.Add(paramContrasena); lstParams.Add(paramCalle); lstParams.Add(paramColonia); 
            lstParams.Add(paramCodigoPostal); lstParams.Add(paramNoInterior); lstParams.Add(paramNoExterior); lstParams.Add(paramIdInscripcion); lstParams.Add(paramIdLogro);
            GetQuery(sql, lstParams); 
        }

        public void EditUsuario(Usuario person)
        {
            const string SQL = "Update usuario set nombre=:nom, apellidos=:ap, correo=:email, contrasena=:contra, calle=:call, colonia=:colo, codigo_postal=:cp, no_interior=:noin, no_exterior=:noext, id_inscripcion=:idins, id_logro=:idlog where id_usuario=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", person.IdUsuario);
            NpgsqlParameter paramNom = new NpgsqlParameter(":nom", person.Nombre);
            NpgsqlParameter paramAp = new NpgsqlParameter(":ap", person.Apellidos);
            NpgsqlParameter paramCorreo = new NpgsqlParameter(":email", person.Correo);
            NpgsqlParameter paramContrasena = new NpgsqlParameter(":contra", person.Contrasena);
            NpgsqlParameter paramCalle = new NpgsqlParameter(":call", person.Calle);
            NpgsqlParameter paramColonia = new NpgsqlParameter(":colo", person.Colonia);
            NpgsqlParameter paramCodigoPostal = new NpgsqlParameter(":cp", person.CodigoPostal);
            NpgsqlParameter paramNoInterior = new NpgsqlParameter(":noin", person.NoInterior);
            NpgsqlParameter paramNoExterior = new NpgsqlParameter(":noext", person.NoExterior);
            NpgsqlParameter paramIdInscripcion = new NpgsqlParameter(":idins", person.IdInscripcion);
            NpgsqlParameter paramIdLogro = new NpgsqlParameter(":idlog", person.IdLogro);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId, paramNom, paramAp, paramCorreo, paramContrasena, paramCalle, paramColonia, paramCodigoPostal, paramNoInterior, paramNoExterior, paramIdInscripcion, paramIdLogro };
            GetQuery(SQL, lstParams);
        }

        public Usuario GetUsuarioById(int id)
        {
            const string SQL = "Select * From usuario where id_usuario = :id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", id);
            List<NpgsqlParameter> lstParameter = new List<NpgsqlParameter>() { paramId };
            DataTable tabla = GetQuery(SQL, lstParameter);
            if (tabla.Rows.Count < 1) return new Usuario();
            foreach (DataRow row in tabla.Rows)
            {
                Usuario person = new Usuario();
                person.IdUsuario = (int)row["id_usuario"];
                person.Nombre = (string)row["nombre"];
                person.Apellidos = (string)row["apellidos"];
                person.Correo = (string)row["correo"];
                person.Contrasena = (string)row["contrasena"];
                person.Calle = (string)row["calle"];
                person.Colonia = (string)row["colonia"];
                person.CodigoPostal = (int)row["codigo_postal"];
                person.NoInterior = (int)row["no_interior"];
                person.NoExterior = (int)row["no_exterior"];
                person.IdInscripcion = (int)row["id_inscripcion"];
                person.IdLogro = (int)row["id_logro"];
                return person;
            }
            return new Usuario();
        }

        public void EliminarUsuario(int IdUsuario)
        {
            const string SQL = "DELETE FROM usuario WHERE id_usuario=:id;";
            NpgsqlParameter paramId = new NpgsqlParameter(":id", IdUsuario);
            List<NpgsqlParameter> lstParams = new List<NpgsqlParameter>() { paramId };
            GetQuery(SQL, lstParams);
        }
    }
}