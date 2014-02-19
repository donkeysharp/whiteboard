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
        public DbSet<School> Schools { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SchoolMember> SchoolMembers { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        // Request ... maybe should be done on a faster database, Redis ;)
        public DbSet<RequestCourseStudent> CourseStudentRequests { get; set; }
        public DbSet<RequestSchoolMember> SchoolMemberRequests { get; set; }

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
