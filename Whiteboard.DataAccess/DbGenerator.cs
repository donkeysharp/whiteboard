using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Common;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess {
    public class DbGenerator {
        private DataBaseContext context;

        public DbGenerator(DataBaseContext context) {
            this.context = context;
        }

        public void GenerateSeedData() {
            // Plans
            PlanGenerator();
            SaveChanges();

            // Users
            UsersGenerator();
            SaveChanges();

            // Organizations and relations
            OrganizationGenerator();
            SaveChanges();
            OrganizationAdmins();
            OrganizationTeachers();
            SaveChanges();

            // Courses and its relations
            CourseGenerator();
            SaveChanges();
            CourseAttendees();
            SaveChanges();
        }

        #region "Course Generator"
        private void CourseGenerator() {
            Course course1 = new Course();
            course1.IsPublic = true;
            course1.Title = "Applied Mathematics";
            course1.PictureUrl = "course.png";
            course1.OwnerId = 2;
            course1.AboutCourse = "It is a course of applied mathematics";
            course1.Lectures = "No lectures";
            course1.Description = "This is a long description of any course, (seed data)";

            Course course2 = new Course();
            course2.IsPublic = true;
            course2.Title = "Physics for children";
            course2.PictureUrl = "course.png";
            course2.OwnerId = 2;
            course2.AboutCourse = "It is a course of physics for children";
            course2.Lectures = "No lectures";
            course2.Description = "This is a long description of any course, (seed data)";
            course2.OrganizationId = 2;

            Course course3 = new Course();
            course3.IsPublic = true;
            course3.Title = "Database Design";
            course3.PictureUrl = "course.png";
            course3.OwnerId = 4;
            course3.AboutCourse = "It is a course of databases desing";
            course3.Lectures = "No lectures";
            course3.Description = "This is a long description of any course, (seed data)";
            course3.OrganizationId = 1;

            Course course4 = new Course();
            course4.IsPublic = true;
            course4.Title = "OS design and implementation";
            course4.PictureUrl = "course.png";
            course4.OwnerId = 4;
            course4.AboutCourse = "It is a course of OS design and implementation";
            course4.Lectures = "No lectures";
            course4.Description = "This is a long description of any course, (seed data)";

            context.Courses.Add(course1);
            context.Courses.Add(course2);
            context.Courses.Add(course3);
            context.Courses.Add(course4);
        }

        private void CourseAttendees() {
            CourseAttendee ca11 = new CourseAttendee();
            ca11.CourseId = 1;
            ca11.AttendeeId = 1;

            CourseAttendee ca21 = new CourseAttendee();
            ca21.CourseId = 2;
            ca21.AttendeeId = 1;

            CourseAttendee ca41 = new CourseAttendee();
            ca41.CourseId = 4;
            ca41.AttendeeId = 1;

            context.CourseAttendees.Add(ca11);
            context.CourseAttendees.Add(ca21);
            context.CourseAttendees.Add(ca41);
        }
        #endregion

        #region "Organization Generator"
        private void OrganizationGenerator() {
            Organization org1 = new Organization();
            org1.Name = "UMSA";
            org1.PictureUrl = "course.png";
            org1.Email = "pizarron@umsa.edu.bo";
            org1.WebSite = "http://umsa.edu.bo";

            Organization org2 = new Organization();
            org2.Name = "Olimpiadas Bolivianas de Informática";
            org2.PictureUrl = "course.png";
            org2.Email = "obi@gmail.com";
            org2.WebSite = "http://obi.org.bo";

            context.Organizations.Add(org1);
            context.Organizations.Add(org2);
        }

        private void OrganizationAdmins() {
            OrganizationAdmin admin11 = new OrganizationAdmin();
            admin11.OrganizationId = 1;
            admin11.ProfileId = 3;

            OrganizationAdmin admin21 = new OrganizationAdmin();
            admin21.OrganizationId = 2;
            admin21.ProfileId = 5;

            context.OrganizationAdmins.Add(admin11);
            context.OrganizationAdmins.Add(admin21);
        }

        private void OrganizationTeachers() {
            OrganizationTeacher teacher11 = new OrganizationTeacher();
            teacher11.OrganizationId = 1;
            teacher11.TeacherId = 4;

            OrganizationTeacher teacher21 = new OrganizationTeacher();
            teacher21.OrganizationId = 2;
            teacher21.TeacherId = 2;

            context.OrganizationTeachers.Add(teacher11);
            context.OrganizationTeachers.Add(teacher21);
        }

        #endregion

        #region "User Generation"
        private void UsersGenerator() {
            long now = TimeUtil.Now;

            Profile profile1 = new Profile();
            profile1.Name = "Juan Perez";
            profile1.Email = "juan@hotmail.com";
            profile1.Country = "BO";
            profile1.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile1.PlanId = Plan.FREE_PLAN;
            profile1.Role = Profile.ROLE_COMMON;
            profile1.SignUpDate = now;
            profile1.PictureUrl = "user.png";

            Profile profile2 = new Profile();
            profile2.Name = "Simon Cruz";
            profile2.Email = "simon@hotmail.com";
            profile2.Country = "BO";
            profile2.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile2.PlanId = Plan.FREE_PLAN;
            profile2.Role = Profile.ROLE_COMMON;
            profile2.SignUpDate = now;
            profile2.PictureUrl = "user.png";

            Profile profile3 = new Profile();
            profile3.Name = "Pizarron Umsa";
            profile3.Email = "pizarron@umsa.edu.bo";
            profile3.Country = "BO";
            profile3.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile3.PlanId = Plan.FREE_PLAN;
            profile3.Role = Profile.ROLE_COMMON;
            profile3.SignUpDate = now;
            profile3.PictureUrl = "user.png";

            Profile profile4 = new Profile();
            profile4.Name = "Rosa Flores";
            profile4.Email = "rosa@hotmail.com";
            profile4.Country = "BO";
            profile4.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile4.PlanId = Plan.FREE_PLAN;
            profile4.Role = Profile.ROLE_COMMON;
            profile4.SignUpDate = now;
            profile4.PictureUrl = "user.png";

            Profile profile5 = new Profile();
            profile5.Name = "Pepe Obi";
            profile5.Email = "pepe@hotmail.com";
            profile5.Country = "BO";
            profile5.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile5.PlanId = Plan.FREE_PLAN;
            profile5.Role = Profile.ROLE_COMMON;
            profile5.SignUpDate = now;
            profile5.PictureUrl = "user.png";

            Profile profile6 = new Profile();
            profile6.Name = "Dog Father";
            profile6.Email = "root@pizarron.org";
            profile6.Country = "BO";
            profile6.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile6.PlanId = Plan.FREE_PLAN;
            profile6.Role = Profile.ROLE_ADMIN;
            profile6.SignUpDate = now;
            profile6.PictureUrl = "user.png";

            context.Profiles.Add(profile1);
            context.Profiles.Add(profile2);
            context.Profiles.Add(profile3);
            context.Profiles.Add(profile4);
            context.Profiles.Add(profile5);
            context.Profiles.Add(profile6);
        }
        #endregion

        #region "Plan Generator"
        private void PlanGenerator() {
            Plan freePlan = new Plan();
            freePlan.Name = "Free Plan";
            freePlan.Description = "Free Plan";

            Plan premiumPlan = new Plan();
            premiumPlan.Name = "Premium Plan";
            premiumPlan.Description = "Premium Plan";

            context.Plans.Add(freePlan);
            context.Plans.Add(premiumPlan);
        }
        #endregion

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
