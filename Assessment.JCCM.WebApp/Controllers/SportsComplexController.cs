using Assessment.JCCM.BL;
using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.WebApp.Helper;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Assessment.JCCM.WebApp.Controllers
{
    [Filters.SessionExpiredFilter]
    public class SportsComplexController : Controller
    {
        // GET: SportsComplex
        public async Task<ActionResult> Index()
        {

                var response = await SportsComplexBL.GetAll();

                return View(response);
        }


        // GET: SportsComplex/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: SportsComplex/Create
        [HttpPost]
        public async Task<ActionResult> Create(SportsComplexRequestDto request)
        {
            try
            {
                var response = await SportsComplexBL.Create(request);
                var Message = response ? "El complejo deportivo se creó correctamente!" : "Error: No se pudo crear el registro";
                
                return Json(new {Message, isSuccess = response }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Message="A ocurrido un error en el servidor", isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: SportsComplex/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await SportsComplexBL.FindById(id);

            return View(response);
        }

        // POST: SportsComplex/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, SportsComplexRequestDto request)
        {
            try
            {
                var response = await SportsComplexBL.Update(id,request);
                var Message = response ? "El complejo deportivo se actualizó correctamente!" : "Error: No se pudo actualizar el registro";

                return Json(new { Message, isSuccess = response }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Message = "A ocurrido un error en el servidor", isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }


        // POST: SportsComplex/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await SportsComplexBL.Delete(id);
                var Message = response ? "El complejo deportivo se eliminó correctamente!" : "Error: No se pudo eliminar el registro";

                return Json(new { Message, isSuccess = response }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Message = "A ocurrido un error en el servidor", isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
