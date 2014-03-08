﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public interface ICourseService:IService<Course>
    {
        IEnumerable<Course> Search(string data);

        IEnumerable<Course> GetPublicCourses();

        IEnumerable<CourseReport> GetCoursesBySchoolId(int schoolId);

        CourseReport GetCourseReport(int id);
    }
}
