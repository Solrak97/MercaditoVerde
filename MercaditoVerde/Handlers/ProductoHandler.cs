using MercaditoVerde.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MercaditoVerde.Handlers
{
    public class ProductoHandler : Handler<ProductoModel>
    {
        public override void Crear(ProductoModel nuevo)
        {

        }

        public override ProductoModel Obtener(int id)
        {
            return new ProductoModel();
        }

        public override List<ProductoModel> ObtenerTodos()
        {
            return new List<ProductoModel>();
        }

        public override void Modificar(int id, ProductoModel Nuevo)
        {

        }

        public override void Borrar(int id)
        {

        }

        public List<string> TraerUnidades()
        {
            List<string> unidades = new List<string>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM UNIDADES", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        unidades.Add(reader["unidad"].ToString());
                    }
                }
            }

            return unidades;
        }

        public List<string> TraerCategorias()
        {
            List<string> categorias = new List<string>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM  CATEGORIAS   ", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        categorias.Add(reader["categoria"].ToString());
                    }
                }
            }

            return categorias;
        }
    }
}