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
    public class ItemsTest
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

        private ItemService _testItemService;

        [TestInitialize]
        public void TestInit()
        {
            var repositoryMock = new Mock<IRepository<Item>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<Item> { _mockItem });
            repositoryMock.Setup(x => x.Delete(_mockItem));
            repositoryMock.Setup(x => x.SaveOrUpdate(_mockItem));

            var testManager = new PersistenceManager<Item> { Repository = repositoryMock.Object };
            _testItemService = new ItemService { Manager = testManager };
        }

        [TestMethod]
        public void GetAllItemsTest()
        {
            var receivedItems = _testItemService.GetAll();
            Assert.AreEqual(receivedItems[0], _mockItem);
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            var success = _testItemService.Delete(_mockItem);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void UpdateItemTest()
        {
            var updatedItem = new Item
            {
                Id = 1,
                Name = "Bärbär",
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
                            IsAdmin = true,
                            Username = "dimü",
                            Password = "blabla"
                        }
                    }
                }
            };
            var success = _testItemService.SaveOrUpdate(updatedItem);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void ItemsPageInitTest()
        {
            var success = _testItemService.Delete(_mockItem);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void SaveNewItemTest()
        {
            var item = new Item
            {
                Id = 2,
                Name = "Bärbär",
                Ratings = new List<Rating>
                {
                    new Rating
                    {
                        Id = 2,
                        Comment = "tolles tier",
                        Score = 4,
                        User = new User
                        {
                            Id = 2,
                            Firstname = "Dirk",
                            Lastname = "Müller",
                            IsAdmin = true,
                            Username = "dede",
                            Password = "blabla"
                        }
                    }
                }
            };
            _testItemService.SaveOrUpdate(item);
        }
    }
}