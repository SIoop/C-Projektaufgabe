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
    public class ChangePasswordTest
    {
        private const int UserId = 5;
        private const string UserName = "otto";
        private const string UserFirstName = "Otto";
        private const string UserLastName = "Müller";
        private const string UserPassword = "geheim";
        private const bool UserIsAdmin = true;

        private UserService _userTestService;

        private User _userMock;

        [TestInitialize]
        public void TestInit()
        {
            _userMock = new User
            {
                Firstname = UserFirstName,
                Id = UserId,
                IsAdmin = UserIsAdmin,
                Lastname = UserLastName,
                Password = BCrypt.Net.BCrypt.HashPassword(UserPassword),
                Username = UserName
            };

            var repositoryMock = new Mock<IRepository<User>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<User> { _userMock });
            repositoryMock.Setup(x => x.Delete(_userMock));
            repositoryMock.Setup(x => x.SaveOrUpdate(_userMock));

            var testManager = new PersistenceManager<User> { Repository = repositoryMock.Object };
            _userTestService = new UserService { Manager = testManager };
        }

        [TestMethod]
        public void ChangeWrongPasswordTest()
        {
            var success = _userTestService.ChangePassword(_userMock, "wrong", "geheim2");
           Assert.IsFalse(success);
        }

        [TestMethod]
        public void ChangeCorrectPasswordTest()
        {
            var success = _userTestService.ChangePassword(_userMock, UserPassword, "geheim2");
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void ChangeToEmptyStringTest()
        {
            var success = _userTestService.ChangePassword(_userMock, UserPassword, "");
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void ChangeToSamePasswordTest()
        {
            var success = _userTestService.ChangePassword(_userMock, UserPassword, UserPassword);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void ChangeToNullTest()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                _userTestService.ChangePassword(_userMock, UserPassword, null));
        }
    }
}