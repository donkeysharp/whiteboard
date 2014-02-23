using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class CourseService:GenericService<Course>,ICourseService
    {
        private CourseService(ICourseRepository da):base(da)
        {
        }

        public static ICourseService GetInstance<T>() where T:ISchoolRepository
        {
            ICourseRepository da = (ICourseRepository)Activator.CreateInstance<T>();
            return new CourseService(da);
        }

        public IEnumerable<Course> GetSortedBy(CourseTypes type)
        {
            switch (type)
            {
                case CourseTypes.Id:
                    return da.Filter(null, (x) => x.OrderBy(y => y.Id));
                case CourseTypes.Title:
                    return da.Filter(null, (x) => x.OrderBy(y => y.Title));
                case CourseTypes.OnAir:
                    return da.Filter(null, (x) => x.OrderBy(y => y.OnAir));
                case CourseTypes.Public:
                    return da.Filter(null, (x) => x.OrderBy(y => y.Public));
                case CourseTypes.SchoolName:
                    return da.Filter(null, (x) => x.OrderBy(y => y.School.Profile.Name));
                case CourseTypes.SchoolEmail:
                    return da.Filter(null, (x) => x.OrderBy(y => y.School.Profile.Email));
                default:
                    break;
            }
            return new List<Course>();
        }

        public IEnumerable<Course> Search(string data)
        {
            return da.Filter(
                (x) => (
                x.School.Profile.Name.Contains(data) ||
                x.School.Profile.Email.Contains(data))
                );
        }

        public IEnumerable<Course> GetBySchoolId(int id)
        {
            return da.Filter((x) => x.SchoolId == id, null);
        }

        public IEnumerable<Course> GetByTeacherId(int id)
        {
            return da.Filter((x) => x.TeacherId == id, null);
        }
    }
    public enum CourseTypes
    {
        Id, Title, OnAir, Public, SchoolName, SchoolEmail
    }
}
