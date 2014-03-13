﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public interface ISchoolStudentRepository:IRepository<SchoolStudent>
    {
        IEnumerable<Profile> GetStudentsBySchoolId(int schoolId);

        IEnumerable<Profile> GetStudentsBySchoolIdNotInCourse(int schoolId, int courseId, string query);
    }
}
