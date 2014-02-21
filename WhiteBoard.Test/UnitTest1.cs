using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using whiteboard.BusinessLogic.ProfileModule;
using Whiteboard.DataAccess.Repositories;
using System.Collections.Generic;
using Whiteboard.DataAccess.Models;

namespace WhiteBoard.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestProfile()
        {
            IProfileService profileService = ProfileService.GetInstance<ProfileRepository>();
            var result = (profileService.GetAll() as List<Profile>).Count;
            Assert.AreEqual(1, result);
        }
    }
}
