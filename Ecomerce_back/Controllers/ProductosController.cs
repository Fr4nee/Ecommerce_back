﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Ecomerce_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : Controller
    {
        public static string ConnectionString = "data source=localhost; Initial Catalog=ecommerce; Integrated Security=True";

        [HttpGet("ListarProductos")]
        public object ListarProductos()
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = @"select * from Productos_deff";
                        command.ExecuteNonQuery();

                        SqlDataAdapter da = new SqlDataAdapter(command);

                        using (da)
                        {
                            da.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }

            Object jsonn = logicas.dataSetToJSON(ds);
            return jsonn;
        }

        [HttpPost("CargarProducto")]
        public string CargarProducto(string nombre, long precio, string imagen, string categoria, int stock, string descripcion)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@nombre", nombre));
                        command.Parameters.Add(new SqlParameter("@precio", precio));
                        command.Parameters.Add(new SqlParameter("@imagen", imagen));
                        command.Parameters.Add(new SqlParameter("@categoria", categoria));
                        command.Parameters.Add(new SqlParameter("@stock", stock));
                        command.Parameters.Add(new SqlParameter("@descripcion", descripcion));

                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = @"insert into Productos_deff (nombre, precio, imagen, categoria, stock, descripcion)
                        values (@nombre, @precio, @imagen, @categoria, @stock, @descripcion)";
                        command.ExecuteNonQuery();

                        SqlDataAdapter da = new SqlDataAdapter(command);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "El producto se cargo correctamente.";
        }

        [HttpPost("EditarProducto")]
        public string EditarCliente(string nombre, long precio, string imagen, string categoria, int stock, string descripcion, int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@nombre", nombre));
                        command.Parameters.Add(new SqlParameter("@precio", precio));
                        command.Parameters.Add(new SqlParameter("@imagen", imagen));
                        command.Parameters.Add(new SqlParameter("@categoria", categoria));
                        command.Parameters.Add(new SqlParameter("@stock", stock));
                        command.Parameters.Add(new SqlParameter("@descripcion", descripcion));
                        command.Parameters.Add(new SqlParameter("@id", id));

                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = @"update Productos_deff set nombre = @nombre , precio = @precio, imagen = @imagen , categoria = @categoria, stock = @stock, descripcion = @descripcion where id = @id";
                        command.ExecuteNonQuery();

                        SqlDataAdapter da = new SqlDataAdapter(command);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "El producto se editó correctamente.";
        }

        [HttpPost("DeleteProducto")]
        public string EliminarProducto(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@id", id));

                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = @"Delete from Productos_deff where id = @id";
                        command.ExecuteNonQuery();

                        SqlDataAdapter da = new SqlDataAdapter(command);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "El producto se eliminó correctamente.";
        }

        [HttpGet("DevolverProducto")]
        public object DevolverProducto(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@id", id));

                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = @"select * from Productos_deff where id = @id";
                        command.ExecuteNonQuery();

                        SqlDataAdapter da = new SqlDataAdapter(command);

                        using (da)
                        {
                            da.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex;
            }

            var jsonn = logicas.dataSetToJSON(ds);
            return jsonn;
        }
    }

}
