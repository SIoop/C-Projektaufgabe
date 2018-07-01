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
    public class StartPageTest
    {
        private readonly Category _catMock = new Category
        {
            Id = 1,
            Name = "Tiere",
            Items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Bär",
                    Ratings = new List<Rating>
                    {
                        new Rating
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
                        }
                    }
                }
            }
        };

        private CategoryService _catTestService;

        [TestInitialize]
        public void TestInit()
        {
            var repositoryMock = new Mock<IRepository<Category>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<Category> { _catMock });
            repositoryMock.Setup(x => x.Delete(_catMock));
            repositoryMock.Setup(x => x.SaveOrUpdate(_catMock));

            var testManager = new PersistenceManager<Category> { Repository = repositoryMock.Object };
            _catTestService = new CategoryService { Manager = testManager };
        }

        [TestMethod]
        public void GetAllCategoriesTest()
        {
            var expectedList = new List<Category> {_catMock};
            var cats = _catTestService.GetAll();
            cats.ForEach(c => Assert.AreEqual(expectedList[cats.IndexOf(c)], c));
        }

        [TestMethod]
        public void GetOneCategoryTest()
        {
            var cat = _catTestService.Get(_catMock.Id);
            Assert.AreEqual(_catMock, cat);
        }

        [TestMethod]
        public void DeleteCatTest()
        {
            var success = _catTestService.Delete(_catMock);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void StartPageInitTest()
        {
            var cat = _catTestService.Get(_catMock.Id);
            Assert.AreEqual(_catMock.Items, cat.Items);
        }

        [TestMethod]
        public void CorrectItemsReceived()
        {
            var cat = _catTestService.Get(_catMock.Id);
            Assert.AreEqual(_catMock.Items, cat.Items);
        }
    }
}