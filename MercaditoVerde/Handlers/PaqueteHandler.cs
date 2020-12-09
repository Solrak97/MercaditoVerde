using MercaditoVerde.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MercaditoVerde.Handlers
{
    public class PaqueteHandler : Handler<PaqueteModel>
    {
        public override void Crear(PaqueteModel nuevo)
        {

        }

        public override PaqueteModel Obtener(int id)
        {
            PaqueteModel paquete = new PaqueteModel(); ;

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM  PAQUETE WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            paquete = new PaqueteModel
                            (
                                Convert.ToInt32(reader["id"].ToString()),
                                reader["nombre"].ToString(),
                                float.Parse(reader["precio"].ToString()),
                                new List<ProductoModel>()
                            ) ;
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }

            paquete.productos = ListaProductos(paquete.id);
            paquete.autoSetAhorro();
            return paquete;
        }

        public override List<PaqueteModel> ObtenerTodos()
        {
            List<PaqueteModel> paquetes = new List<PaqueteModel>(); ;

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM  PAQUETE", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            paquetes.Add(new PaqueteModel
                            (
                                Convert.ToInt32(reader["id"].ToString()),
                                reader["nombre"].ToString(),
                                float.Parse(reader["precio"].ToString()),
                                new List<ProductoModel>()
                            ));
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }

            foreach(PaqueteModel paquete in paquetes)
            {
                paquete.productos = ListaProductos(paquete.id);
                paquete.autoSetAhorro();
            }

            return paquetes;
        }

        public override void Modificar(int id, PaqueteModel Nuevo)
        {

        }

        public override void Borrar(int id)
        {

        }

        private List<ProductoModel> ListaProductos(int id)
        {
            List<ProductoModel> productos = new List<ProductoModel>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTO JOIN PAQUETE_RELACION ON PAQUETE_RELACION.PRODUCTOID" +
                " = PRODUCTO.ID WHERE PAQUETE_RELACION.PAQUETEID = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            productos.Add(
                                new ProductoModel
                                (
                                    Convert.ToInt32(reader["id"]),
                                    reader["nombre"].ToString(),
                                    reader["categoria"].ToString(),
                                    reader["unidad"].ToString(),
                                    float.Parse(reader["precio"].ToString()),
                                    reader["imagen"] as byte[],
                                    reader["tipo"].ToString(),
                                    Convert.ToInt32(reader["cantidad"])
                                )
                            ) ;
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }

            }
            return productos;
        }
    }
}