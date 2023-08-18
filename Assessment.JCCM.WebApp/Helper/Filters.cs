using System.Web.Mvc;
using System.Web.Routing;

namespace Assessment.JCCM.WebApp.Helper
{
    public class Filters
    {
        public class SessionExpiredFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Validar la información que se encuentra en la sesión.
                if (SesionModel.DatosSesion == null || SesionModel.DatosSesion.Id == 0)
                {
                    // Si la información es nula, redireccionar a 
                    // página de error u otra página deseada.
                    var route = filterContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                       {
                           { "action", "Login" },
                           { "controller", "Authentication" },
                           { "Area", string.Empty },
                           { "returnUrl", route }
                       });
                }

                base.OnActionExecuting(filterContext);
            }
        }
    }
}