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
            PlanGenerator();
            SaveChanges();

            UsersGenerator();
            SaveChanges();

            OrganizationGenerator();
        }

        private void OrganizationGenerator() {
            Organization org1 = new Organization();
            org1.Name = "UMSA";
        }

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
            profile1.PictureUrl = Constants.DEFAULT_USER_PICTURE;

            Profile profile2 = new Profile();
            profile2.Name = "Simon Cruz";
            profile2.Email = "simon@hotmail.com";
            profile2.Country = "BO";
            profile2.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile2.PlanId = Plan.FREE_PLAN;
            profile2.Role = Profile.ROLE_COMMON;
            profile2.SignUpDate = now;

            Profile profile3 = new Profile();
            profile3.Name = "Pizarron Umsa";
            profile3.Email = "pizarron@umsa.edu.bo";
            profile3.Country = "BO";
            profile3.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile3.PlanId = Plan.FREE_PLAN;
            profile3.Role = Profile.ROLE_COMMON;
            profile3.SignUpDate = now;

            Profile profile4 = new Profile();
            profile4.Name = "Rosa Flores";
            profile4.Email = "rosa@hotmail.com";
            profile4.Country = "BO";
            profile4.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile4.PlanId = Plan.FREE_PLAN;
            profile4.Role = Profile.ROLE_COMMON;
            profile4.SignUpDate = now;

            Profile profile5 = new Profile();
            profile5.Name = "Pepe";
            profile5.Email = "pepe@hotmail.com";
            profile5.Country = "BO";
            profile5.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile5.PlanId = Plan.FREE_PLAN;
            profile5.Role = Profile.ROLE_COMMON;
            profile5.SignUpDate = now;

            Profile profile6 = new Profile();
            profile6.Name = "Dog Father";
            profile6.Email = "root@pizarron.org";
            profile6.Country = "BO";
            profile6.Password = "8cb2237d0679ca88db6464eac60da96345513964";
            profile6.PlanId = Plan.FREE_PLAN;
            profile6.Role = Profile.ROLE_ADMIN;
            profile6.SignUpDate = now;

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
