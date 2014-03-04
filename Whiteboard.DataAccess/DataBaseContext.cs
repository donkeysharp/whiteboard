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

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleProfile> RoleProfiles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SchoolStudent> SchoolStudents { get; set; }
        public DbSet<CourseClass> CourseClasses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<SchoolTeacher> SchoolTeachers { get; set; }
        public DbSet<WhiteboardNote> Whiteboards { get; set; }

        // Request ... maybe should be done on a faster database, Redis ;)
        public static DataBaseContext Context {
            get { return context; }
        }

        private DataBaseContext() {

        }
        static DataBaseContext() {
            if (!context.Database.Exists()) {
                context.Database.CreateIfNotExists();
                context.Seed();
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void Seed() {
            DbGenerator generator = new DbGenerator(this);
            generator.GenerateSeedData();
        }
    }
}
