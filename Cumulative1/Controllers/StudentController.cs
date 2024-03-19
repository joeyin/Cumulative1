using School.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(); //Default
        }

        //GET : /Student/List
        public ActionResult List()
        {
            StudentDataController controller = new StudentDataController();

            TempData["n"] = Request.QueryString["n"];
            TempData["v"] = Request.QueryString["v"];

            IEnumerable<Student> Students = controller.ListStudents(
                Request.QueryString["n"],
                Request.QueryString["v"]
            );

            return View(Students);
        }

        //GET : /Student/Show/{id}
        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);

            return View(NewStudent);
        }
    }
}