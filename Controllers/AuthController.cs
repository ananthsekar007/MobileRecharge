using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MobileRecharge.Models;

namespace MobileRecharge.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        IConfiguration _configuration;
        SqlConnection _connection;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpPost("isadmin")]
        public bool IsAdmin(User user)
        {
            _connection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM AspNetUserRoles WHERE UserId= '{user.userId}'",_connection);
            
            SqlDataReader reader = sqlCommand.ExecuteReader();

            bool isAdmin = reader.HasRows;
            while(reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }


            _connection.Close();

            return isAdmin;
        }
    }
}
