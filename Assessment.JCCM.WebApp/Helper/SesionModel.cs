using Assessment.JCCM.DataTypes.Response;
using System.Web;

namespace Assessment.JCCM.WebApp.Helper
{
    public class SesionModel
    {
        private static UserAuthenticationResponseDto _DatosSesion;
        public static UserAuthenticationResponseDto DatosSesion
        {
            get
            {
                var session = (UserAuthenticationResponseDto)HttpContext.Current.Session["DatosSesion"];
                if (session == null) session = new UserAuthenticationResponseDto();
                _DatosSesion = session;
                return _DatosSesion;
            }
            set
            {
                HttpContext.Current.Session["DatosSesion"] = value;
            }
        }

    }
}