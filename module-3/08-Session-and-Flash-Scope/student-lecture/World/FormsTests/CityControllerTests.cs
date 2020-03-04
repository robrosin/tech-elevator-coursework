using Forms.Web.Controllers;
using Forms.Web.Models;
using FormsTests.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormsTests
{
/****
 * TODO 99: Write tests for the CityController, and HomeController
 *      Show how the Mock objects are used to 1) remove integration from the tests, and 2) control the 
 *      data we want to test for.
 ****/

    [TestClass]
    public class CityControllerTests
    {
        [TestMethod]
        public void TestIndex()
        {
            //// Arrange
            //CityMockDAO cityDAO = new CityMockDAO();
            //CountryMockDAO countryDAO = new CountryMockDAO();
            //CityController controller = new CityController(cityDAO, countryDAO);

            //// Act
            //IActionResult result = controller.Index();

            //// Assert
            //ViewResult vr = result as ViewResult;
            //Assert.IsNotNull(vr, "Index did not return a ViewResult");

        }


        [TestMethod]
        public void TestSearch()
        {
            //// Arrange
            //CityMockDAO cityDAO = new CityMockDAO();
            //CountryMockDAO countryDAO = new CountryMockDAO();
            //CityController controller = new CityController(cityDAO, countryDAO);

            //// Act
            //CitySearchVM vm = new CitySearchVM()
            //{
            //    CountryCode = "CC1",
            //    District = ""
            //};
            //IActionResult result = controller.Search(vm);

            //// Assert
            //ViewResult vr = result as ViewResult;
            //CitySearchVM vmResult = vr.Model as CitySearchVM;
            //Assert.IsNotNull(vmResult, "Search did not return a CitySearchVM");

            //Assert.AreEqual(2, vmResult.Cities.Count);
            //Assert.AreEqual("City1", vmResult.Cities[0].Name);
            //Assert.AreEqual("City2", vmResult.Cities[1].Name);
        }
    }
}
