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

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationAdmin> OrganizationAdmins { get; set; }
        public DbSet<OrganizationTeacher> OrganizationTeachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAttendee> CourseAttendees { get; set; }
        public DbSet<CourseClass> CourseClasses { get; set; }
        public DbSet<ClassNote> ClassNotes { get; set; }
        public DbSet<WhiteboardNote> WhiteboardNotes { get; set; }
        public DbSet<Message> Messages { get; set; }


        public static DataBaseContext Context {
            get { return context; }
        }

        private DataBaseContext() {
        }
        static DataBaseContext() {
            CheckDatabase();
        }
        public static void CheckDatabase() {
            if (!context.Database.Exists()) {
                context.Database.CreateIfNotExists();
                context.Seed();
            } else if (!context.Database.CompatibleWithModel(false)) {
                context.Database.Delete();
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
