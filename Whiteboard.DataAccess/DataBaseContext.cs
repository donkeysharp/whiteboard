using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.DataAccess
{
    public class DataBaseContext:DbContext,IDisposable
    {
        private static DataBaseContext context = new DataBaseContext();

        public static DataBaseContext Context
        {
            get { return context; }
        }

        private DataBaseContext()
        {

        }
        static  DataBaseContext()
        {
            context.Database.CreateIfNotExists();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
