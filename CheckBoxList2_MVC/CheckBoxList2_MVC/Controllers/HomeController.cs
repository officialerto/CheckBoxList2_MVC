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

        

        public ActionResult Index()
        {
            CourseDBEntities courseDBEntities = new CourseDBEntities();

            StudentCoursesViewModel objCoursesViewModel = new StudentCoursesViewModel()
            {
                ListOfStudents = (from objStudent in courseDBEntities.Languages
                                  select new SelectListItem()
                                  {
                                      Text = objStudent.StudentName,
                                      Value=objStudent.StudentId.ToString()
                                  }).ToList(),

                ListOfCourses=(from objCourses in courseDBEntities.Languages
                               select new CoursesViewModel()
                               {
                                   CourseId=objCourses.LanguageId,
                                   CourseName=objCourses.LanguageName,

                               }).ToList()
            };

            return View(courseDBEntities);
        }
    }
}