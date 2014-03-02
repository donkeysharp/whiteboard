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

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseClass> CourseClasses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleProfile> RoleProfiles { get; set; }
        public DbSet<Whiteboard.DataAccess.Models.WhiteboardNote> Whiteboards { get; set; }

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
            Role schoolRole = new Role();
            schoolRole.Name = Role.ROLE_SCHOOL;
            Role teacherRole = new Role();
            teacherRole.Name = Role.ROLE_TEACHER;
            Role studentRole = new Role();
            studentRole.Name = Role.ROLE_STUDENT;

            this.Roles.Add(schoolRole);
            this.Roles.Add(teacherRole);
            this.Roles.Add(studentRole);

            Profile schoolProfile = new Profile();
            schoolProfile.Name = "UMSA";
            schoolProfile.Email = "pizarron@umsa.edu.bo";
            schoolProfile.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            schoolProfile.Country = "BO";
            schoolProfile.PictureUrl = "user.png";

            this.Profiles.Add(schoolProfile);

            RoleProfile roleProfileStudent = new RoleProfile();
            roleProfileStudent.ProfileId = 1;
            roleProfileStudent.RoleId = (int)Role.Roles.Student;

            RoleProfile roleProfileSchool = new RoleProfile();
            roleProfileSchool.ProfileId = 1;
            roleProfileSchool.RoleId = (int)Role.Roles.School;

            this.RoleProfiles.Add(roleProfileStudent);
            this.RoleProfiles.Add(roleProfileSchool);

            this.SaveChanges();
        }

        ///*
        // * Seed data initializers
        // */
        //public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext> {
        //    protected override void Seed(DataBaseContext context) {
        //        context.Seed(context);
        //        base.Seed(context);
        //    }
        //}
        //public class CreateInitializer : CreateDatabaseIfNotExists<DataBaseContext> {
        //    protected override void Seed(DataBaseContext context) {
        //        context.Seed(context);

        //        base.Seed(context);
        //    }
        //}

    }
}
