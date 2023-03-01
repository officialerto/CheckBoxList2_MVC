using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CheckBoxList2_MVC.ViewModel
{
    public class StudentCoursesViewModel
    {
        [Display(Name ="Student")]
        public int StudentId { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public IEnumerable<SelectListItem> ListOfStudents { get; set; }
        public IEnumerable<CoursesViewModel> ListOfCourses { get; set; }
    }
}