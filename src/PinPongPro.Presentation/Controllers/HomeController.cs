using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace PinPongPro.Presentation.Controllers
{
    public class HomeController : Controller
    {
        [GET("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}