﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;
using Whiteboard.DataAccess.Repositories;

namespace whiteboard.BusinessLogic.SchoolModule
{
    public class SchoolStudentService:GenericService<SchoolStudent>,ISchoolStudentService
    {
        private ISchoolStudentRepository Da {
            get {
                return da as ISchoolStudentRepository;
            }
        }
        private SchoolStudentService(ISchoolStudentRepository da):base(da)
        {

        }
        public static ISchoolStudentService GetInstance<T>() where T: ISchoolStudentRepository
        {
            ISchoolStudentRepository da = (ISchoolStudentRepository)Activator.CreateInstance<T>();
            return new SchoolStudentService(da);
        }

        public IEnumerable<Profile> GetStudentsBySchoolID(int SchoolID)
        {
            return Da.GetStudentsBySchoolId(SchoolID);
        }

        public IEnumerable<Profile> GetStudentsBySchoolIdNotInCourse(int schoolId, int courseId, string query) {
            return Da.GetStudentsBySchoolIdNotInCourse(schoolId, courseId, query);
        }
    }
}
