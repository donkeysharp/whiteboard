using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Whiteboard.Web {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GoToClass",
                url: "course/courseclass/{id}",
                defaults: new { controller = "CourseClass", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteClass",
                url: "course/class/delete",
                defaults: new { controller = "Course", action = "DeleteClass", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DeleteStudent",
                url: "course/student/delete",
                defaults: new { controller = "Course", action = "DeleteStudent", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CourseAddClass",
                url: "course/addclass",
                defaults: new { controller = "Course", action = "AddClass", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CourseAddStudent",
                url: "course/addstudent",
                defaults: new { controller = "Course", action = "AddStudent", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CoursesStudents",
                url: "course/students",
                defaults: new { controller = "Course", action = "Students", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CoursesTeachers",
                url: "course/teachers",
                defaults: new { controller = "Course", action = "Teachers", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CoursesEdit",
                url: "course/edit",
                defaults: new { controller = "Course", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CoursesList",
                url: "course/list",
                defaults: new { controller = "Course", action = "List", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CourseInfo",
                url: "course/{id}",
                defaults: new { controller = "Course", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}