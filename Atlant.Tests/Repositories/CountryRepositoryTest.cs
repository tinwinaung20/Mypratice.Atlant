using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlant.Model;
using Atlant.Repository;
using Effort.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlant.Tests.Repositories
{
    //Test
    [TestClass]
    public class CountryRepositoryTest
    {
        System.Data.Common.DbConnection connection;
        TestContext databaseContext;
        CountryRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            try
            {
                EffortProviderConfiguration.RegisterProvider();
                connection = Effort.DbConnectionFactory.CreateTransient();
                databaseContext = new TestContext(connection);
                objRepo = new CountryRepository(databaseContext);
            }
            catch (Exception ex) {

            }
        }

        

        [TestMethod]
        public void Country_Repository_GetAll()
        {
            try
            {
                //Act
                var result = objRepo.GetAll().ToList();

                //Assert

                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual("US", result[0].Name);
                Assert.AreEqual("India", result[1].Name);
            }
            catch (Exception ex)
            {
            }
        }

        [TestMethod]
        public void Country_Repository_Create()
        {
            try
            {
                //Arrange
                Country c = new Country() { Name = "UK" };

                //Act
                var result = objRepo.Add(c);
                databaseContext.SaveChanges();
            }
            catch (Exception ex) { }
        }
    }
}
