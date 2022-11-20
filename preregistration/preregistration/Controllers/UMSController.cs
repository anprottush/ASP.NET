using preregistration.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace preregistration.Controllers
{
    public class UMSController : Controller
    {
        // GET: UMS
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult studentList()
        {
            var db = new PREREG_BEntities();
            var students = db.Students;
            return View(students);
        }
        [HttpGet]
        public ActionResult AddStudents()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudents(Student sd)
        {
            var db = new PREREG_BEntities();
            db.Students.Add(sd);
            db.SaveChanges();
            return RedirectToAction("studentList");
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var db = new PREREG_BEntities();
            var sd = (from std in db.Students
                      where std.Id == id
                      select std).SingleOrDefault();

            return View(sd);
        }
        [HttpPost]
        public ActionResult EditStudent(Student sd)
        {
            var db = new PREREG_BEntities();
            var student = (from std in db.Students
                           where std.Id == sd.Id
                           select std).SingleOrDefault();
            student.Name = sd.Name;
            student.Cgpa = sd.Cgpa;
            db.SaveChanges();
            return View("studentList");
        }
        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var db = new PREREG_BEntities();
            var sd = (from std in db.Students
                      where std.Id == id
                      select std).SingleOrDefault();
            var crStudent = (from crs in db.CourseStudents
                             where crs.StudentId == id
                             select crs).ToList();
            foreach (var cdstudent in crStudent)
            {
                db.CourseStudents.Remove(cdstudent);
            }
            db.Students.Remove(sd);
            db.SaveChanges();
            return RedirectToAction("studentList");
        }

        public ActionResult CourseList()
        {
            var db = new PREREG_BEntities();
            var courses = db.Courses;
            return View(courses);
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Cours cr)
        {
            var db = new PREREG_BEntities();
            db.Courses.Add(cr);
            db.SaveChanges();
            return RedirectToAction("CourseList");
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var db = new PREREG_BEntities();
            var cr = (from crs in db.Courses
                      where crs.Id == id
                      select crs).SingleOrDefault();

            return View(cr);
        }
        [HttpPost]
        public ActionResult EditCourse(Cours cr)
        {
            var db = new PREREG_BEntities();
            var course = (from crs in db.Courses
                          where crs.Id == cr.Id
                          select crs).SingleOrDefault();
            course.Name = cr.Name;
            course.PreReq = cr.PreReq;
            db.SaveChanges();
            return RedirectToAction("CourseList");
        }
        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var db = new PREREG_BEntities();
            var course = (from crs in db.Courses
                          where crs.Id == id
                          select crs).SingleOrDefault();
            var crStudent = (from crs in db.CourseStudents
                                 where crs.CourseId == id
                                 select crs).ToList();
            foreach (var cdstudent in crStudent)
            {
                db.CourseStudents.Remove(cdstudent);
            }
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("CourseList");
        }
        [HttpGet]
        public ActionResult PreRegistration(int id)
        {
            List<Cours> preRegList = new List<Cours>();
            CourseStudent coursestdnt = new CourseStudent();
            var db = new PREREG_BEntities();
            var sd = (from std in db.Students
                      where std.Id == id
                      select std).SingleOrDefault();
            var courseStudents = (from cr in db.CourseStudents
                                  where cr.StudentId == id
                                  select cr).ToList();
            foreach (var course in db.Courses)
            {
                bool status = false;
                foreach (var courseStudent in courseStudents)
                {
                    coursestdnt = courseStudent;
                    if (course.Id == courseStudent.CourseId)
                    {
                        status = true;
                        if (coursestdnt.Status == "Complete")
                        {
                            goto Repeat;
                        }
                        else if (coursestdnt.Status == "Retakeable")
                        {
                            preRegList.Add(course);
                            goto Repeat;
                        }
                        else if (coursestdnt.Status == "Dropped")
                        {
                            preRegList.Add(course);
                            goto Repeat;
                        }
                    }
                }
                if (!status)
                {
                    if (course.PreReq == null)
                    {
                        preRegList.Add(course);
                        goto Repeat;
                    }
                    foreach (var courseStudent in courseStudents)
                    {
                        
                        if(course.PreReq == courseStudent.CourseId)
                        {
                            if(courseStudent.Grade != "W")
                            {
                                preRegList.Add(course);
                                goto Repeat;
                            }
                        }
                    }
                }

                Repeat:;
            }
            return View(preRegList);
        }
    }
}