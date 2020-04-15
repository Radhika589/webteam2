using Microsoft.VisualStudio.TestTools.UnitTesting;
using Webteam2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Webteam2.Models;

namespace WebTeam2.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
       
        [TestMethod()]
        public void IndexActionTest()
        {
            var mock = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = mock.Object;

           
            var homeController = new HomeController(logger);
            var result = homeController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod()]
        public void PrivacyActionTest()
        {
            var mock = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = mock.Object;


            var homeController = new HomeController(logger);
            var result = homeController.Privacy() as ViewResult;
            Assert.AreEqual("Privacy", result.ViewName);
        }

       
       
    }
}