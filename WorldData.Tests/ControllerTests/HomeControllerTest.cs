using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using DayOfWeek.Models;
using DayOfWeek.Controllers;

namespace DayOfWeek.Tests
{
  [TestClass]
  public class HomeControllerTest
  {
     [TestMethod]
     public void Index_ReturnCorrectView_true()
     {
         //Arrange
          HomeController controller = new HomeController();

          //Act
          IActionResult indexView = controller.Index();
          ViewResult result = indexView as ViewResult;

          //Assert
          Assert.IsInstanceOfType(result, typeof(ViewResult));
     }
  }
}
