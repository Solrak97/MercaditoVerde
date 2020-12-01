using System.Configuration;
using System.Data.SqlClient;


namespace Mercadito_Verde.Handlers
{
    public abstract class Handler<T>
    {
        protected SqlConnection connection;
        private string connectionUri;

        public Handler()
        {
            connectionUri = ConfigurationManager.ConnectionStrings["BD-comunidad-practica"].ToString();
            connection = new SqlConnection(connectionUri);
        }

        public abstract void Crear(T nuevo);
        public abstract T Traer(int id);
        public abstract void Modificar(int id, T nuevo);
        public abstract void Borrar(int id);

    }
}