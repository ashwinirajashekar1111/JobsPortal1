using JobsPortal.Controllers;
using Moq;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using DatabaseAccessLayer;
using JobsPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTest1
{
    [TestFixture]
    public class JobControllerTests
    {
         private JobController _controller;

            [SetUp]
            public void SetUp()
            {
                // Mocking HttpContext for testing
                var mockHttpContext = new Mock<HttpContextBase>();
                var mockSession = new Mock<HttpSessionStateBase>();
                mockHttpContext.Setup(ctx => ctx.Session).Returns(mockSession.Object);

                // Mocking DbContext
                var mockDbContext = new Mock<JobsPortalDbEntities>();

                // Mocking Logger
                var mockLogger = new Mock<log4net.ILog>();

                // Set up log4net (assuming you have a log4net configuration file)
                log4net.Config.XmlConfigurator.Configure();

                // Ensure that the controller's constructor properly initializes log4net
                _controller = new JobController(mockDbContext.Object, mockLogger.Object);
                _controller.ControllerContext = new System.Web.Mvc.ControllerContext
                {
                    HttpContext = mockHttpContext.Object
                };
            }




        //public void MyAction_Post_ReturnsViewResult()
        //{
        //    // Arrange
        //    var JobController = CreateJobController();

        //    // Act
        //    var result = JobController.PostJob(new PostJobMV) as ViewResult;

        //    // Assert
        //    ClassicAssert.NotNull(result, message: "MyAction POST action should return a ViewResult");
        //}




        [Test]
        public void PostJob_ValidModel_RedirectsToCompanyJobsList()
        {
            // Arrange
            var jobController = CreateJobController();  // Use the correct type here

            var postJobModel = new PostJobMV
            {
                // Provide valid properties for testing
            };

            // Act
            var result = jobController.PostJob(postJobModel) as System.Web.Mvc.RedirectToRouteResult;

            // Assert
            ClassicAssert.IsNotNull(result, "PostJob action should redirect to CompanyJobsList on success");
            ClassicAssert.AreEqual("CompanyJobsList", result.RouteValues["action"]);
            ClassicAssert.AreEqual("Job", result.RouteValues["controller"]);
        }


        private object CreateJobController()
        {
            throw new NotImplementedException();
        }

        // Other test methods go here...
    }

}





            


    

