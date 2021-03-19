using System.Web.Mvc;
using DIObject;

namespace Controllers
{
    public class UnityController : Controller
    {
        private readonly IObjectMessage _message;

        public UnityController(IObjectMessage message)
        {
            _message = message;
        }
        // GET: Unity
        public ActionResult Index()
        {
            ViewBag.Title = _message.Display();
            return View();
        }

        }
    }

