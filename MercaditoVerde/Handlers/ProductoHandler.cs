using MercaditoVerde.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MercaditoVerde.Handlers
{
    public class ProductoHandler : Handler<ProductoModel>
    {
        public override void Crear(ProductoModel nuevo)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCTO(nombre, categoria, unidad, precio, imagen, tipo) " +
                "VALUES(@nombre, @categoria, @unidad, @precio, @imagen, @tipo)", connection))
                
            {
                cmd.Parameters.AddWithValue("@nombre", nuevo.nombre); 
                cmd.Parameters.AddWithValue("@categoria", nuevo.categoria);
                cmd.Parameters.AddWithValue("@unidad", nuevo.tipoUnidad);
                cmd.Parameters.AddWithValue("@precio", nuevo.precio);
                cmd.Parameters.AddWithValue("@imagen", getBytes(nuevo.imagen));
                cmd.Parameters.AddWithValue("@tipo", nuevo.imagen.ContentType);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }

        }

        public override ProductoModel Obtener(int id)
        {
            ProductoModel producto = new ProductoModel();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM  PRODUCTO WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            producto = new ProductoModel
                            (
                                Convert.ToInt32(reader["id"]),
                                reader["nombre"].ToString(),
                                reader["categoria"].ToString(),
                                reader["unidad"].ToString(),
                                float.Parse(reader["precio"].ToString()),
                                reader["imagen"] as byte[],
                                reader["tipo"].ToString()
                            );
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }

            }
            return producto;
        }

        public override List<ProductoModel> ObtenerTodos()
        {
            List<ProductoModel> productos = new List<ProductoModel>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM  PRODUCTO", connection))
            {
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
                                    reader["tipo"].ToString()
                                )
                            );
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
                try 
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
                catch(SqlException e)
                {
                    throw e;
                }
                
            }

            return unidades;
        }

        public List<string> TraerCategorias()
        {
            List<string> categorias = new List<string>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM  CATEGORIAS", connection))
            {
                try
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
                catch(SqlException e)
                {
                    throw e;
                }
                
            }

            return categorias;
        }
    }
}