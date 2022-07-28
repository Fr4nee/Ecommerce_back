using Ecomerce_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace Ecomerce_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        public static string ConnectionString = "data source=localhost; Initial Catalog=ecommerce; Integrated Security=True";
        
        [HttpGet("ValidoLogin")]
        public Task<bool> ValidoLogin(string nombre, string contraseña)
        {
            DataSet ds = new DataSet();
            bool res = true;
            
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Add(new SqlParameter("@nombre", nombre));
                        command.Parameters.Add(new SqlParameter("@contraseña", contraseña));

                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = @"select * from Clientes_deff where (nombre = @nombre and contraseña = @contraseña)";
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
                
            }
            Object jsonn = logicas.dataSetToJSON(ds);
            string jsasdf = jsonn.ToString();

            if (jsasdf != "[[]]")
            {
                res = true;
            }
            else
            {
                res = false;
            }
                   
            return Task.FromResult(res);
        }
    }
}
