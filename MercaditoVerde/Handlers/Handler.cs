using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace MercaditoVerde.Handlers
{
    public abstract class Handler <T>
    {
        protected SqlConnection connection;
        private string connectionUri;


        public Handler()
        {
            connectionUri = ConfigurationManager.ConnectionStrings["BDMercaditoVerde"].ToString();
            connection = new SqlConnection(connectionUri);
        }

        public abstract void Crear(T nuevo);
        public abstract T Obtener(int id);
        public abstract List<T> ObtenerTodos();
        public abstract void Modificar(int id, T Nuevo);
        public abstract void Borrar(int id);

        protected byte[] getBytes(HttpPostedFileBase file)
        {
            byte[] bytes;
            BinaryReader reader = new BinaryReader(file.InputStream);
            bytes = reader.ReadBytes(file.ContentLength);
            return bytes;
        }
    }
}