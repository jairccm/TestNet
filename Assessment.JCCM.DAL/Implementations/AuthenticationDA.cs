using Assessment.JCCM.DAL.Interfaces;
using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.DataTypes.Response;
using Dapper;
using System.Threading.Tasks;

namespace Assessment.JCCM.DAL.Implementations
{
    public class AuthenticationDA : IAuthenticationDA
    {
        protected readonly IConnectionFactory _connectionFactory;

        public AuthenticationDA()
        {
            _connectionFactory = new ConnectionFactory();
        }
        public async Task<UserAuthenticationResponseDto> LoginByUsernameAndPassword(UserAuthenticationRequestDto userAuthentication)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@userName", userAuthentication.UserName);
                parameters.Add("@password", userAuthentication.Password);
                var response = await connection.QueryFirstOrDefaultAsync<UserAuthenticationResponseDto>("dbo.usp_login", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return response;
            }
        }
    }
}
