using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.DataTypes.Response;
using System.Threading.Tasks;

namespace Assessment.JCCM.DAL.Interfaces
{
    public interface IAuthenticationDA
    {
        Task<UserAuthenticationResponseDto> LoginByUsernameAndPassword(UserAuthenticationRequestDto userAuthentication);
    }
}
