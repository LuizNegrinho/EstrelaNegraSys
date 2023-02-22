using Dapper;
using EstrelaNegra.API.Interfaces;
using EstrelaNegra.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace EstrelaNegra.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionStringModel _connection;
        private readonly IConfiguration _configuration;

        public UserRepository(IOptions<ConnectionStringModel> connection, IConfiguration configuration)
        {
            _connection = connection.Value;
            _configuration = configuration;
            _connection.Connection = _configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<UserModel> GetUsers()
        {
            
            var query = @"SELECT 
USR_ID AS UserId
,USR_NM AS UserName
,USR_EML AS UserEmail
,PSWD AS UserPassword
,FLL_NM AS UserFullName
,JOIN_DT AS UserJoinDate
FROM USER_DATA";

            using var sql = new SqlConnection(_connection.Connection);
            var result = sql.Query<UserModel>(query).ToList();
            return result;            
        }
    }
}
