using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.DataAccess.Models;

namespace Whiteboard.DataAccess {
    public class DbGenerator {
        private DataBaseContext context;

        public DbGenerator(DataBaseContext context) {
            this.context = context;
        }

        public void GenerateSeedData() {
            RoleGenerator();
            ProfileGenerator();
            SaveChanges();
            CourseGenerator();
            CourseStudentGenerator();
            SaveChanges();
        }

        private void CourseStudentGenerator() {
            CourseStudent cs = new CourseStudent();
            cs.CourseId = 1;
            cs.StudentId = 3;

            context.CourseStudents.Add(cs);
        }

        public void RoleGenerator() {
            Role schoolRole = new Role();
            schoolRole.Name = Role.ROLE_SCHOOL;
            Role teacherRole = new Role();
            teacherRole.Name = Role.ROLE_TEACHER;
            Role studentRole = new Role();
            studentRole.Name = Role.ROLE_STUDENT;

            context.Roles.Add(schoolRole);
            context.Roles.Add(teacherRole);
            context.Roles.Add(studentRole);
        }

        public void ProfileGenerator() {
            Profile schoolProfile = new Profile();
            schoolProfile.Name = "UMSA";
            schoolProfile.Email = "pizarron@umsa.edu.bo";
            schoolProfile.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            schoolProfile.Country = "BO";
            schoolProfile.PictureUrl = "user.png";

            Profile studentProfile = new Profile();
            studentProfile.Name = "Juan Perez";
            studentProfile.Email = "juan@gmail.com";
            studentProfile.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            studentProfile.Country = "BO";
            studentProfile.PictureUrl = "user.png";

            Profile teacherProfile = new Profile();
            teacherProfile.Name = "Simon Cruz";
            teacherProfile.Email = "simon@gmail.com";
            teacherProfile.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            teacherProfile.Country = "BO";
            teacherProfile.PictureUrl = "user.png";

            context.Profiles.Add(schoolProfile);
            context.Profiles.Add(teacherProfile);
            context.Profiles.Add(studentProfile);

            RoleProfileGenerator();
        }

        private void RoleProfileGenerator() {
            RoleProfile roleProfileSchool = new RoleProfile();
            roleProfileSchool.ProfileId = 1;
            roleProfileSchool.RoleId = (int)Role.Roles.School;

            RoleProfile roleProfileTeacher = new RoleProfile();
            roleProfileTeacher.ProfileId = 2;
            roleProfileTeacher.RoleId = (int)Role.Roles.Teacher;

            RoleProfile roleProfileStudent = new RoleProfile();
            roleProfileStudent.ProfileId = 3;
            roleProfileStudent.RoleId = (int)Role.Roles.Student;

            context.RoleProfiles.Add(roleProfileSchool);
            context.RoleProfiles.Add(roleProfileTeacher);
            context.RoleProfiles.Add(roleProfileStudent);
        }

        public void CourseGenerator() {
            Course course1 = new Course();
            course1.Title = "Matematicas con tom y jerry";
            course1.SchoolId = 1;
            course1.Syllabus = "Syllabus";
            course1.Schedule = "8am to 10am";
            course1.Lectures = "empty";
            course1.Description = "Introduccion a las matematicas";

            Course course2 = new Course();
            course2.Title = "Literatura";
            course2.SchoolId = 1;
            course2.Syllabus = "Syllabus 2";
            course2.Schedule = "9am to 11am";
            course2.Lectures = "empty";
            course2.Description = "COnocimiento literario basico";

            context.Courses.Add(course1);
            context.Courses.Add(course2);
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
