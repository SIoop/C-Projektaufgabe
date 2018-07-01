using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Server.Framework;
using Server.Managers;
using Server.Services;

namespace Test
{
    [TestClass]
    public class BestRatingsTest
    {
        private readonly Item _mockItem = new Item
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
        };

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

        private ItemService _testItemService;

        [TestInitialize]
        public void TestInit()
        {
            var repositoryMock = new Mock<IRepository<Item>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<Item> {_mockItem});
            repositoryMock.Setup(x => x.Delete(_mockItem));
            repositoryMock.Setup(x => x.SaveOrUpdate(_mockItem));

            var testManager = new PersistenceManager<Item> {Repository = repositoryMock.Object};
            _testItemService = new ItemService {Manager = testManager};
        }

        [TestMethod]
        public void GetAllRatedItemsNotNull()
        {
            var list = _testItemService.GetRatedItemsByCategory(_catMock);
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GetAllRatedItemsSize()
        {
            var list = _testItemService.GetRatedItemsByCategory(_catMock);
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void GetAllRatedItemsContainsRightAmount()
        {
            var list = _testItemService.GetRatedItemsByCategory(_catMock);
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void GetAllRatedItemsReturnsCorrectItem()
        {
            var list = _testItemService.GetRatedItemsByCategory(_catMock);
            Assert.IsTrue(list[0].Name == _catMock.Items[0].Name);
        }

        [TestMethod]
        public void GetAllRatedItemsCorrectRatings()
        {
            var list = _testItemService.GetRatedItemsByCategory(_catMock);
            Assert.IsTrue(list[0].Ratings == _catMock.Items[0].Ratings.Count);
        }
    }
}