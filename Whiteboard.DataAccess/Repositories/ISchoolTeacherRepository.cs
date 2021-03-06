﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess.Repositories
{
    public interface ISchoolTeacherRepository:IRepository<SchoolTeacher>
    {
        IEnumerable<Profile> GetTeachersBySchoolId(int schoolId, string query);
    }
}
