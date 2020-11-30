using System.Configuration;
using System.Data.SqlClient;


namespace Mercadito_Verde.Handlers
{
    public class Handler<T>
    {
        protected SqlConnection connection;
        private string connectionUri;

        public Handler()
        {
            connectionUri = ConfigurationManager.ConnectionStrings["BD-comunidad-practica"].ToString();
            connection = new SqlConnection(connectionUri);
        }
    }
}