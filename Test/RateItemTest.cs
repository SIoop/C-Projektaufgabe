using System.Collections.Generic;
using Client.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Server.Framework;
using Server.Managers;
using Server.Services;

namespace Test
{
    [TestClass]
    public class RateItemTest
    {
        private Rating _mockRating = new Rating
        {
            Id = 1,
            Comment = "tolles tier",
            Score = 4,
            User = new User
            {
                Id = 1,
                Firstname = "Dirk",
                Lastname = "Müller",
                IsAdmin = false,
                Username = "dimü",
                Password = "blabla"
            }
        };

        private RatingService _ratTestService;

        [TestInitialize]
        public void TestInit()
        {
            var repositoryMock = new Mock<IRepository<Rating>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<Rating> { _mockRating });
            repositoryMock.Setup(x => x.Delete(_mockRating));
            repositoryMock.Setup(x => x.SaveOrUpdate(_mockRating));

            var testManager = new PersistenceManager<Rating> { Repository = repositoryMock.Object };
            _ratTestService = new RatingService { Manager = testManager };
        }

        [TestMethod]
        public void RatingWindowInitTest()
        {
            var con = new RateWindowController();
            con.Initialize();
            con.View.Close();
            Assert.IsNotNull(con.View);
        }

        [TestMethod]
        public void AddRatingTest()
        {
            var success = _ratTestService.AddRating(_mockRating);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void DeleteRatingTest()
        {
            var success = _ratTestService.DeleteRating(_mockRating);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void RateCancelTest()
        {

        }
    }
}