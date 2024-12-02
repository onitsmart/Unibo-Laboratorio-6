using Microsoft.AspNetCore.Mvc;

namespace Laboratorio6.Web.Features.Esercizio
{
    public partial class EsercizioController : Controller
    {
        public EsercizioController()
        {
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            var model = new IndexViewModel();

            return View(model);
        }
    }
}
