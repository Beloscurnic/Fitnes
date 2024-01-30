using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitnes.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitnes.BL.Model;

namespace Fitnes.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var usernaem = Guid.NewGuid().ToString();
            var controller = new UserController(usernaem);
            var eatingControlle = new EatingController(controller.CurrentUser);
            var foodname = Guid.NewGuid().ToString();
            var rnd = new Random();
            var food = new Food(foodname, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            //Act
            eatingControlle.Add(food, 100);

            Assert.AreEqual(food.Name, eatingControlle.Eating.Foods.Last().Key.Name);
        }
    }
} 