﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess.Repositories
{
    public class WhiteboardRepository:GenericRepository<Whiteboard.DataAccess.Models.WhiteboardNote>,IWhiteboardRepository
    {
    }
}
