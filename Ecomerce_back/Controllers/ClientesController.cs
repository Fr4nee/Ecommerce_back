
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Ecomerce_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        public static string ConnectionString = "data source=localhost; Initial Catalog=ecommerce; Integrated Security=True";

        [HttpGet]
        public object ListarClientes()
        {
            DataSet ds = new DataSet();
            string response;
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = @"select * from Clientes_deff";
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
                return null;
            }

            response = ds.GetXml();
            var doc = XDocument.Parse(response);
            //return Task.FromResult(JsonConvert.SerializeXNode(doc, Newtonsoft.Json.Formatting.None, omitRootObject: true));
            Object jsonn = logicas.dataSetToJSON(ds);
            return JsonConvert.SerializeObject(jsonn);
        }




        [HttpPost]
        public void RegistrarCliente(string nombre, string apellido, string email, string telefono, string direccion, string contraseña)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@nombre", nombre));
                        command.Parameters.Add(new SqlParameter("@apellido", apellido));
                        command.Parameters.Add(new SqlParameter("@email", email));
                        command.Parameters.Add(new SqlParameter("@telefono", telefono));
                        command.Parameters.Add(new SqlParameter("@direccion", direccion));
                        command.Parameters.Add(new SqlParameter("@contraseña", contraseña));

                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = @"insert into Clientes_deff (nombre, apellido, email, telefono, direccion)
                        values (@nombre, @apellido, @email, @telefono, @direccion)";
                        command.ExecuteNonQuery();

                        SqlDataAdapter da = new SqlDataAdapter(command);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
