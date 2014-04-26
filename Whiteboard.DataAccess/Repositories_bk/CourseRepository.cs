using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Reports;

namespace Whiteboard.DataAccess.Repositories {
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {

        public IEnumerable<CourseReport> GetCoursesBySchoolId(int schoolId) {
            string sql = string.Format(@"select c.*, ifnull(t.Name,'No Teacher') as TeacherName
from course as c
left join courseteacher as ct on (ct.CourseId = c.Id)
left join profile as t on (t.id = ct.TeacherId)
where c.SchoolId = {0}", schoolId);

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            return result;
        }


        public CourseReport GetCourseReport(int id) {
            string sql = string.Format(@"select c.*, t.name as TeacherName, ifnull(t.Id,0) as TeacherId
from course as c
left join courseteacher as cs on (cs.CourseId = c.Id)
left join profile as t on (t.id = cs.TeacherId)
where c.id = {0}", id);

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            if (result.Count > 0) {
                return result[0];
            }
            return null;
        }


        public IEnumerable<CourseReport> GetCoursesByTeacherId(int id) {
            string sql = string.Format(@"select c.*, ifnull(t.Name,'No Teacher') as TeacherName
from course as c
left join courseteacher as ct on (ct.CourseId = c.Id)
left join profile as t on (t.id = ct.TeacherId)
where t.id = {0}", id);

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            return result;
        }


        public IEnumerable<CourseReport> GetCoursesByStudentId(int id) {
            string sql = string.Format(@"select c.*, ifnull(t.Name,'No Teacher') as TeacherName
from course as c
left join courseteacher as ct on (ct.CourseId = c.Id)
left join profile as t on (t.id = ct.TeacherId)
inner join coursestudent as cs on (cs.CourseId = c.Id)
inner join profile as s on (s.id = cs.StudentId)
where s.id = {0}", id);

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            return result;
        }


        public IEnumerable<CourseReport> GetPublicCourses() {
            string sql = string.Format(@"select c.*, ifnull(t.Name,'No Teacher') as TeacherName
from course as c
left join courseteacher as ct on (ct.CourseId = c.Id)
left join profile as t on (t.id = ct.TeacherId)
where c.ispublic = 1");

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            return result;
        }


        public IEnumerable<CourseReport> SearchPublic(string keyword) {
            string sql = string.Format(@"select c.*, ifnull(t.Name,'No Teacher') as TeacherName
from course as c
left join courseteacher as ct on (ct.CourseId = c.Id)
left join profile as t on (t.id = ct.TeacherId)
where c.ispublic = 1 and c.title like '%{0}%'", keyword);

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            return result;
        }


        public bool IsTeacherOfCourse(int courseId, int teacherId) {
            string sql = string.Format(@"select c.*, ifnull(t.Name,'No Teacher') as TeacherName
from course as c
left join courseteacher as ct on (ct.CourseId = c.Id)
left join profile as t on (t.id = ct.TeacherId)
where t.id = {0} and c.id = {1}", teacherId, courseId);

            List<CourseReport> result = context.Database.SqlQuery<CourseReport>(sql).ToList();
            return result.Count > 0;                
        }


        public IEnumerable<Course.Report> GetAttendingCourses(int userId) {
            string sql = string.Format(@"select c.*, p.name as teacherName
from course c 
inner join courseattendee ca on(ca.CourseId = c.id)
inner join profile p on(p.id = c.ownerId)
where ca.AttendeeId = {0}", userId);

            List<Course.Report> result = context.Database.SqlQuery<Course.Report>(sql).ToList();
            return result;
        }


        public IEnumerable<Course.Report> GetTeachingCourses(int userId) {
            string sql = string.Format(@"select c.*, p.name as TeacherName
from course c 
inner join profile p on(p.Id = c.OwnerId)
where c.ownerid = {0}", userId);

            List<Course.Report> result = context.Database.SqlQuery<Course.Report>(sql).ToList();
            return result;
        }
    }
}
