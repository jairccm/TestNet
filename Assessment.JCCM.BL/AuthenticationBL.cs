using Assessment.JCCM.DAL.Implementations;
using Assessment.JCCM.DAL.Interfaces;
using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.DataTypes.Response;
using System.Threading.Tasks;

namespace Assessment.JCCM.BL
{
    public class AuthenticationBL
    {

        public static async Task<UserAuthenticationResponseDto> UserLogin(UserAuthenticationRequestDto userAuthentication)
        {
            IAuthenticationDA _authenticationDA = new AuthenticationDA();
           return await _authenticationDA.LoginByUsernameAndPassword(userAuthentication);
        }
    }
}
