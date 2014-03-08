using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public class CourseTeacherRepository:GenericRepository<CourseTeacher>,ICourseTeacherRepository
    {
        public int DeleteAllTeachersForCourse(int courseId) {
            string sql = string.Format("delete from courseteacher where courseid = {0}", courseId);
            return context.Database.ExecuteSqlCommand(sql);
        }
    }
}
