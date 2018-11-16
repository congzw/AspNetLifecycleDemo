using System;
using System.Web.Mvc;

namespace HttpLifecycleDemo.Controllers
{
    public class EmptyController : Controller
    {
        public ActionResult Index()
        {
            return Content("Empty Index");
        }

        public ActionResult IndexEx()
        {
            throw new ArgumentException("shit happens!");
        }
    }
}