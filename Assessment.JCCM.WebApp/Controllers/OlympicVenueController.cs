using Assessment.JCCM.BL;
using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.WebApp.Helper;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Assessment.JCCM.WebApp.Controllers
{
    [Filters.SessionExpiredFilter]
    public class OlympicVenueController : Controller
    {
        // GET: OlympicVenue
        public async Task<ActionResult> Index()
        {

            var response = await OlympicVenueBL.GetAll();

            return View(response);
        }


        // GET: OlympicVenue/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OlympicVenue/Create
        [HttpPost]
        public async Task<ActionResult> Create(OlympicVenueRequestDto request)
        {
            try
            {
                var response = await OlympicVenueBL.Create(request);
                var Message = response ? "La sede olímpica se creó correctamente!" : "Error: No se pudo crear el registro";

                return Json(new { Message, isSuccess = response }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Message = "A ocurrido un error en el servidor", isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: OlympicVenue/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await OlympicVenueBL.FindById(id);

            return View(response);
        }

        // POST: OlympicVenue/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, OlympicVenueRequestDto request)
        {
            try
            {
                var response = await OlympicVenueBL.Update(id, request);
                var Message = response ? "La sede olímpica se actualizó correctamente!" : "Error: No se pudo actualizar el registro";

                return Json(new { Message, isSuccess = response }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Message = "A ocurrido un error en el servidor", isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }


        // POST: OlympicVenue/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await OlympicVenueBL.Delete(id);
                var Message = response ? "La sede olímpica se eliminó correctamente!" : "Error: No se pudo eliminar el registro";

                return Json(new { Message, isSuccess = response }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Message = "A ocurrido un error en el servidor", isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
