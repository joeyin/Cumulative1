﻿using School.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View(); //Default
        }

        //GET : /Teacher/List
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();

            TempData["n"] = Request.QueryString["n"];
            TempData["v"] = Request.QueryString["v"];

            IEnumerable<Teacher> Teachers = controller.ListTeachers(
                Request.QueryString["n"],
                Request.QueryString["v"]
            );

            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        
    }
}