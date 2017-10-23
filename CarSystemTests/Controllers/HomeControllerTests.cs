using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CarSystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarSystemTests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void CalculateSquareAreaTest()
        {
            double par = 3.6;
            ContentResult expectedResult = new ContentResult { Content = "12.96" };
            HomeController controller = new HomeController();
            ContentResult result = controller.CalculateSquareArea(par) as ContentResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(expectedResult.Content, result.Content);
        }
    }
}