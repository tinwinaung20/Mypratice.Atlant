using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Atlant.Controllers;
using Atlant.Model;
using Atlant.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Atlant.Tests.Controllers
{
    [TestClass]
    public class CountryControllerTest
    {
        private Mock<ICountryService> _countryServicePack;
        CountryController objController;
        List<Country> listCountry;

        [TestInitialize]
        public void Initialize()
        {
            _countryServicePack = new Mock<ICountryService>();
            objController = new CountryController(_countryServicePack.Object);
            listCountry = new List<Country>() {
                new Country() {Id=1,Name="US" },
                new Country() {Id=2,Name="India" },
                new Country() {Id=3,Name="UK" }
            };
        }

        [TestMethod]
        public void Country_GetAll()
        {
            //Arrange
            _countryServicePack.Setup(x => x.GetAll()).Returns(listCountry);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<Country>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
        }

        [TestMethod]
        public void Valid_Country_Create()
        {
            //Arrange
            Country c = new Country() { Name = "test1" };

            //Act
            var result = (RedirectToRouteResult)objController.Create(c);

            //Assert
            _countryServicePack.Verify(m => m.Create(c), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Invalid_Country_Create()
        {
            // Arrange
            Country c = new Country() { Name = "" };
            objController.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult)objController.Create(c);

            //Assert
            _countryServicePack.Verify(m => m.Create(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }
    }
}
