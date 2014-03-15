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
            CourseTeacherGenerator();
            SaveChanges();
            SchoolStudentGenerator();
            SaveChanges();
            SchoolTeacherGenerator();
            SaveChanges();
            SchoolCoursesGenerator();
            SaveChanges();
        }

        private void SchoolCoursesGenerator()
        {
            SchoolCourse sc1 = new SchoolCourse();
            sc1.CourseId = 1;
            sc1.SchoolId = 1;

            SchoolCourse sc2 = new SchoolCourse();
            sc2.CourseId = 2;
            sc2.SchoolId = 1;

            SchoolCourse sc3 = new SchoolCourse();
            sc3.CourseId = 3;
            sc3.SchoolId = 1;

            SchoolCourse sc4 = new SchoolCourse();
            sc4.CourseId = 4;
            sc4.SchoolId = 1;

            SchoolCourse sc5 = new SchoolCourse();
            sc5.CourseId = 5;
            sc5.SchoolId = 1;

            SchoolCourse sc6 = new SchoolCourse();
            sc6.CourseId = 6;
            sc6.SchoolId = 1;

            context.SchoolCourses.Add(sc1);
            context.SchoolCourses.Add(sc2);
            context.SchoolCourses.Add(sc3);
            context.SchoolCourses.Add(sc4);
            context.SchoolCourses.Add(sc5);
            context.SchoolCourses.Add(sc6);
        }

        private void SchoolTeacherGenerator()
        {
            SchoolTeacher st1 = new SchoolTeacher();
            st1.SchoolId = 1;
            st1.TeacherId = 2;

            SchoolTeacher st2 = new SchoolTeacher();
            st2.SchoolId = 1;
            st2.TeacherId = 4;

            context.SchoolTeachers.Add(st1);
            context.SchoolTeachers.Add(st2);
        }

        private void SchoolStudentGenerator()
        {
            SchoolStudent ss1 = new SchoolStudent();
            ss1.SchoolId = 1;
            ss1.StudentId = 3;
            context.SchoolStudents.Add(ss1);

            SchoolStudent ss2 = new SchoolStudent();
            ss2.SchoolId = 1;
            ss2.StudentId = 5;

            context.SchoolStudents.Add(ss1);
            context.SchoolStudents.Add(ss2);
        }

        private void CourseTeacherGenerator()
        {
            CourseTeacher ct1 = new CourseTeacher();
            ct1.CourseId = 1;
            ct1.TeacherId = 2;

            CourseTeacher ct2 = new CourseTeacher();
            ct2.CourseId = 2;
            ct2.TeacherId = 2;

            CourseTeacher ct3 = new CourseTeacher();
            ct3.CourseId = 3;
            ct3.TeacherId = 2;

            CourseTeacher ct4 = new CourseTeacher();
            ct4.CourseId = 4;
            ct4.TeacherId = 4;

            CourseTeacher ct5 = new CourseTeacher();
            ct5.CourseId = 5;
            ct5.TeacherId = 4;

            CourseTeacher ct6 = new CourseTeacher();
            ct6.CourseId = 6;
            ct6.TeacherId = 4;

            context.CourseTeachers.Add(ct1);
            context.CourseTeachers.Add(ct2);
            context.CourseTeachers.Add(ct3);
            context.CourseTeachers.Add(ct4);
            context.CourseTeachers.Add(ct5);
            context.CourseTeachers.Add(ct6);
        }

        private void CourseStudentGenerator() {
            CourseStudent cs = new CourseStudent();
            cs.CourseId = 1;
            cs.StudentId = 3;

            CourseStudent cs2 = new CourseStudent();
            cs2.CourseId = 2;
            cs2.StudentId = 3;

            CourseStudent cs3 = new CourseStudent();
            cs3.CourseId = 3;
            cs3.StudentId = 3;

            context.CourseStudents.Add(cs);
            context.CourseStudents.Add(cs2);
            context.CourseStudents.Add(cs3);
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
            // id 1
            Profile schoolProfile = new Profile();
            schoolProfile.Name = "UMSA";
            schoolProfile.Email = "pizarron@umsa.edu.bo";
            schoolProfile.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            schoolProfile.Country = "BO";
            schoolProfile.PictureUrl = "user.png";

            // id 2
            Profile studentProfile = new Profile();
            studentProfile.Name = "Juan Perez";
            studentProfile.Email = "juan@hotmail.com";
            studentProfile.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            studentProfile.Country = "BO";
            studentProfile.PictureUrl = "user.png";

            // id 3
            Profile teacherProfile = new Profile();
            teacherProfile.Name = "Simon Cruz";
            teacherProfile.Email = "simon@hotmail.com";
            teacherProfile.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            teacherProfile.Country = "BO";
            teacherProfile.PictureUrl = "user.png";

            // id 4
            Profile teacherProfile2 = new Profile();
            teacherProfile2.Name = "Rosa Flores";
            teacherProfile2.Email = "rosa@hotmail.com";
            teacherProfile2.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            teacherProfile2.Country = "BO";
            teacherProfile2.PictureUrl = "user.png";

            // id 5
            Profile studentProfile2 = new Profile();
            studentProfile2.Name = "Pepe";
            studentProfile2.Email = "pepe@hotmail.com";
            studentProfile2.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            studentProfile2.Country = "BO";
            studentProfile2.PictureUrl = "user.png";

            // id 6
            Profile schoolProfile2 = new Profile();
            schoolProfile2.Name = "UMSS";
            schoolProfile2.Email = "pizarron@umss.edu.bo";
            schoolProfile2.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            schoolProfile2.Country = "BO";
            schoolProfile2.PictureUrl = "user.png";

            // id 7
            Profile studentProfile3 = new Profile();
            studentProfile3.Name = "Maria";
            studentProfile3.Email = "maria@hotmail.com";
            studentProfile3.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            studentProfile3.Country = "BO";
            studentProfile3.PictureUrl = "user.png";

            context.Profiles.Add(schoolProfile); // 1
            context.Profiles.Add(teacherProfile); // 2
            context.Profiles.Add(studentProfile); // 3
            context.Profiles.Add(teacherProfile2); // 4
            context.Profiles.Add(studentProfile2); // 5
            context.Profiles.Add(schoolProfile2); // 6
            context.Profiles.Add(studentProfile3); // 7

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

            RoleProfile rp4 = new RoleProfile();
            rp4.ProfileId = 4;
            rp4.RoleId = (int)Role.Roles.Teacher;

            RoleProfile rp5 = new RoleProfile();
            rp5.ProfileId = 5;
            rp5.RoleId = (int)Role.Roles.Student;

            RoleProfile rp6 = new RoleProfile();
            rp6.ProfileId = 6;
            rp6.RoleId = (int)Role.Roles.School;

            RoleProfile rp7 = new RoleProfile();
            rp7.ProfileId = 7;
            rp7.RoleId = (int)Role.Roles.Student;

            context.RoleProfiles.Add(roleProfileSchool);
            context.RoleProfiles.Add(roleProfileTeacher);
            context.RoleProfiles.Add(roleProfileStudent);
            context.RoleProfiles.Add(rp4);
            context.RoleProfiles.Add(rp5);
            context.RoleProfiles.Add(rp6);
            context.RoleProfiles.Add(rp7);
        }

        public void CourseGenerator() {
            Course course1 = new Course();
            course1.Title = "Matematicas con tom y jerry";
            course1.SchoolId = 1;
            course1.Description = "Little description";
            course1.AboutCourse = "This is all about the <b>course</b>";
            course1.PictureUrl = "class_default.jpg";
            course1.Syllabus = "Syllabus";
            course1.Schedule = "8am to 10am";
            course1.Lectures = "empty";
            course1.IsPublic = false;
            course1.Description = "Introduccion a las matematicas";

            Course course2 = new Course();
            course2.Title = "Literatura";
            course2.SchoolId = 1;
            course2.Description = "Little description";
            course2.AboutCourse = "This is all about the <b>course</b>";
            course2.PictureUrl = "class_default.jpg";
            course2.Syllabus = "Syllabus 2";
            course2.Schedule = "9am to 11am";
            course2.Lectures = "empty";
            course2.IsPublic = false;
            course2.Description = "COnocimiento literario basico";

            Course course3 = new Course();
            course3.Title = "Curso privado de quimica";
            course3.SchoolId = 1;
            course3.Description = "Little description";
            course3.AboutCourse = "This is all about the <b>course</b>";
            course3.PictureUrl = "class_default.jpg";
            course3.Syllabus = "Syllabus quimica";
            course3.Schedule = "9am to 11am";
            course3.Lectures = "empty";
            course3.IsPublic = false;
            course3.Description = "COnocimiento quimica basico";

            Course course4 = new Course();
            course4.Title = "Fisica mecanica";
            course4.SchoolId = 1;
            course4.Description = "Little description";
            course4.AboutCourse = "This is all about the <b>course</b>";
            course4.PictureUrl = "class_default.jpg";
            course4.Syllabus = "Syllabus fisica";
            course4.Schedule = "9am to 11am";
            course4.Lectures = "empty";
            course4.IsPublic = true;
            course4.Description = "COnocimiento fisica basico";

            Course course5 = new Course();
            course5.Title = "Curso publico 3";
            course5.SchoolId = 1;
            course5.Description = "Little description";
            course5.AboutCourse = "This is all about the <b>course</b>";
            course5.PictureUrl = "class_default.jpg";
            course5.Syllabus = "Syllabus 3";
            course5.Schedule = "9am to 11am";
            course5.Lectures = "empty";
            course5.IsPublic = true;
            course5.Description = "COnocimiento literario basico";

            Course course6 = new Course();
            course6.Title = "Curso publico 4";
            course6.SchoolId = 1;
            course6.Description = "Little description";
            course6.AboutCourse = "This is all about the <b>course</b>";
            course6.PictureUrl = "class_default.jpg";
            course6.Syllabus = "Syllabus 4";
            course6.Schedule = "9am to 11am";
            course6.Lectures = "empty";
            course6.IsPublic = false;
            course6.Description = "COnocimiento literario basico";

            context.Courses.Add(course1);
            context.Courses.Add(course2);
            context.Courses.Add(course3);
            context.Courses.Add(course4);
            context.Courses.Add(course5);
            context.Courses.Add(course6);
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
