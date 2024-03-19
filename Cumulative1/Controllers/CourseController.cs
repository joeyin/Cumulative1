using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class CourseController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View(); //Default
        }

        //GET : /Class/List
        public ActionResult List()
        {
            CourseDataController controller = new CourseDataController();

            TempData["n"] = Request.QueryString["n"];
            TempData["v"] = Request.QueryString["v"];

            IEnumerable<Course> Classes = controller.ListClasses(
                Request.QueryString["n"],
                Request.QueryString["v"]
            );

            return View(Classes);
        }

        //GET : /Class/Show/{id}
        public ActionResult Show(int id)
        {
            CourseDataController controller = new CourseDataController();
            Course NewClass = controller.FindClass(id);

            return View(NewClass);
        }
    }
}