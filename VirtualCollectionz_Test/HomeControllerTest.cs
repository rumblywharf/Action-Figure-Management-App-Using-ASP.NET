using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_1.Controllers;
using Assignment_1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VirtualCollectionz_Test
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexReturnsResult()
        {
            //Arrange
            var controller = new HomeController(null);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void PrivacyLoadsPrivacyView()
        {
            var controller = new HomeController(null);
            var result = (ViewResult)controller.Privacy();
            Assert.AreEqual("Privacy", result.ViewName);
        }


    }
}
