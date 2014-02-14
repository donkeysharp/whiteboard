using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess {
    public class DataBaseContext : DbContext, IDisposable {
        private static DataBaseContext context = new DataBaseContext();
        public DbSet<Foo> Foos { get; set; }

        public static DataBaseContext Context {
            get { return context; }
        }

        private DataBaseContext() {

        }
        static DataBaseContext() {
            context.Database.CreateIfNotExists();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
