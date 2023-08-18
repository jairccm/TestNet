using Assessment.JCCM.BL;
using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.WebApp.Helper;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Assessment.JCCM.WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            var userAuthentication = new UserAuthenticationRequestDto();
            return View(userAuthentication);
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserAuthenticationRequestDto userAuthentication)
        {
            try
            {
                var loginResponse = await AuthenticationBL.UserLogin(userAuthentication);

                if (loginResponse != null)
                {
                    SesionModel.DatosSesion = loginResponse;
                    return RedirectToAction("Index", "OlympicVenue");
                }

                ViewBag.ErrorMessage = "El usuario o contreseña es incorrecto!";
                return View(userAuthentication);

            }
            catch (Exception e)
            {

                ViewBag.ErrorMessage = "A ocurrido un Error";
            }
            return View(userAuthentication);
        }

        public ActionResult Logout()
        {
            SesionModel.DatosSesion = null;

            return RedirectToAction( "Login", "Authentication");
        }
    }
}