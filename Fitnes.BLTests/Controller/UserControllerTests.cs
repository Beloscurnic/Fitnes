using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitnes.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var username = Guid.NewGuid().ToString();

            //Act
            var usercontroller = new UserController(username);

            //Assert
            Assert.AreEqual(username,usercontroller.CurrentUser.Name); 
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var usernaem = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 180;
            var gender = "man";
            var controller = new UserController(usernaem);
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(usernaem);
            Assert.AreEqual(usernaem, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BrithDate);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
        }
    }
}