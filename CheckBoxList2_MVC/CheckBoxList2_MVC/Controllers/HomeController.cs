using CheckBoxList2_MVC.Models;
using CheckBoxList2_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckBoxList2_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CourseDBEntities courseDBEntities = new CourseDBEntities();

            StudentCoursesViewModel objCoursesViewModel = new StudentCoursesViewModel()
            {
                ListOfStudents = (from objStudent in courseDBEntities.Students
                                  select new SelectListItem()
                                  {
                                      Text = objStudent.StudentName,
                                      Value = objStudent.StudentId.ToString()
                                  }).ToList(),

                ListOfCourses = (from objCourses in courseDBEntities.Languages
                                 select new CoursesViewModel()
                                 {
                                     CourseId = objCourses.LanguageId,
                                     CourseName = objCourses.LanguageName,
                                     IsSelected = false

                                 }).ToList()
            };

            return View(objCoursesViewModel);
        }

        [HttpPost]
        public JsonResult Index(int studentId, List<int> listOfCourseId)
        {
            CourseDBEntities courseDBEntities = new CourseDBEntities();

            foreach (var item in listOfCourseId)
            {
                StudentCourses objStudentCourse = new StudentCourses();
                objStudentCourse.StudentId = studentId; 
                objStudentCourse.CourseId= item;
                courseDBEntities.StudentCourses.Add(objStudentCourse);
                courseDBEntities.SaveChanges();
            }

            return Json(new {success=true, message= "data successfully added"}, JsonRequestBehavior.AllowGet);
        }

    }
}