using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckBoxList2_MVC.ViewModel
{
    public class StudentCoursesViewModel
    {
        public int StudentId { get; set; }
        public IEnumerable<SelectListItem> ListOfStudents { get; set; }
        public IEnumerable<CoursesViewModel> ListOfCourses { get; set; }
    }
}