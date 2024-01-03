using DatabaseAccessLayer;
using JobsPortal.Controllers;
using JobsPortal.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using NUnit;
 

namespace NUnitTest1
{
    [TestFixture]
    public class JobTestController
    {
        private Mock<JobsPortalDbEntities> mockDbEntities;
        private Mock<ControllerContext> mockControllerContext;

        [SetUp]
        public void Setup()
        {
            mockDbEntities = new Mock<JobsPortalDbEntities>();
            mockControllerContext = new Mock<ControllerContext>();
        }

        [Test]
        public void PostJob_Get_ReturnsViewResult()
        {
            // Arrange
            var controller = new JobController { ControllerContext = mockControllerContext.Object };
            mockControllerContext.SetupGet(p => p.HttpContext.Session["UserTypeID"]).Returns("1");

            // Act
            var result = controller.PostJob() as ViewResult;

            // Assert
            Assert.IsNotNull("");
            Assert.AreEqual("", result.ViewName);
        }

        [Test]
        public void PostJob_Post_ValidModel_RedirectsToCompanyJobsList()
        {
            // Arrange
            var controller = new JobController { ControllerContext = mockControllerContext.Object };
            mockControllerContext.SetupGet(p => p.HttpContext.Session["UserTypeID"]).Returns("1");
            var postJobMV = new PostJobMV();

            // Act
            var result = controller.PostJob(postJobMV) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("CompanyJobsList", result.RouteValues["action"]);
        }

        [Test]
        public void PostJob_Post_InvalidModel_ReturnsViewResult()
        {
            // Arrange
            var controller = new JobController { ControllerContext = mockControllerContext.Object };
            mockControllerContext.SetupGet(p => p.HttpContext.Session["UserTypeID"]).Returns("1");
            var postJobMV = new PostJobMV();
            controller.ModelState.AddModelError("key", "error message");

            // Act
            var result = controller.PostJob(postJobMV) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }

    }
}
