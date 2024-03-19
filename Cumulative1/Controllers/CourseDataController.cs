using School.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace School.Controllers
{
    public class CourseDataController : Controller
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the teachers table of our blog database.
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example>GET api/AuthorData/ListTeachers</example>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Course> ListClasses(string n, string v)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "SELECT * FROM classes";

            if (n != null && v != null)
            {
                //cmd.CommandText += " where " + n + " = " + v + ";";
                cmd.CommandText += " WHERE " + n + " = '" + v + "'";
            }

            cmd.CommandText += ";";

            //Debug.WriteLine("sql:" + cmd.CommandText);

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Course> Classes = new List<Course> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = int.Parse(ResultSet["classid"].ToString());
                string ClassCode = ResultSet["classcode"].ToString();
                string TeacherId = ResultSet["teacherid"].ToString();
                string StartDate = ResultSet["startdate"].ToString();
                string FinishDate = ResultSet["finishdate"].ToString();
                string ClassName = ResultSet["classname"].ToString();

                Course NewCourse = new Course();
                NewCourse.ClassId = ClassId;
                NewCourse.ClassCode = ClassCode;
                NewCourse.TeacherId = TeacherId;
                NewCourse.StartDate = StartDate;
                NewCourse.FinishDate = FinishDate;
                NewCourse.ClassName = ClassName;

                //Add the Student Name to the List
                Classes.Add(NewCourse);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Classes;
        }


        /// <summary>
        /// Finds an author in the system given an ID
        /// </summary>
        /// <param name="id">The author primary key</param>
        /// <returns>An author object</returns>
        [HttpGet]
        public Course FindClass(int id)
        {
            Course NewCourse = new Course();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "SELECT * From classes c JOIN teachers t ON t.teacherid = c.teacherid where c.classid = " + id;

            //Debug.WriteLine("sql:" + cmd.CommandText);

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = int.Parse(ResultSet["classid"].ToString());
                string ClassCode = ResultSet["classcode"].ToString();
                string TeacherId = ResultSet["teacherid"].ToString();
                string TeacherFName = ResultSet["teacherfname"].ToString();
                string StartDate = ResultSet["startdate"].ToString();
                string FinishDate = ResultSet["finishdate"].ToString();
                string ClassName = ResultSet["classname"].ToString();

                NewCourse.ClassId = ClassId;
                NewCourse.ClassCode = ClassCode;
                NewCourse.TeacherId = TeacherId;
                NewCourse.TeacherFName = TeacherFName;
                NewCourse.StartDate = StartDate;
                NewCourse.FinishDate = FinishDate;
                NewCourse.ClassName = ClassName;
            }


            return NewCourse;
        }
    }
}