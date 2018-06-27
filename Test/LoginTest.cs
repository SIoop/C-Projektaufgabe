using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Server.Contracts;
using Server.Framework;
using Server.Managers;
using Server.Services;

namespace Test
{
    [TestClass]
    public class LoginTest
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
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<User> {_userMock});
            repositoryMock.Setup(x => x.Delete(_userMock));
            repositoryMock.Setup(x => x.SaveOrUpdate(_userMock));

            var testManager = new PersistenceManager<User> {Repository = repositoryMock.Object};
            _userTestService = new UserService {Manager = testManager};
        }


        [TestMethod]
        public void RightPasswordAndUsernameTest()
        {
            var receivedUser = _userTestService.LoginUser(UserName, UserPassword);
            Assert.AreEqual(_userMock, receivedUser);
        }

        [TestMethod]
        public void RightUsernameWrongPasswordTest()
        {
            var receivedUser = _userTestService.LoginUser(UserName, "passwort");
            Assert.IsNull(receivedUser);
        }

        [TestMethod]
        public void WrongUsernameTest()
        {
            var receivedUser = _userTestService.LoginUser("hans", UserPassword);
            Assert.IsNull(receivedUser);
        }

        [TestMethod]
        public void UppercaseTest()
        {
            var receivedUser = _userTestService.LoginUser(UserName.ToUpper(), UserPassword);
            Assert.AreEqual(_userMock, receivedUser);
        }

        [TestMethod]
        public void GetUserTest()
        {
            var receivedUser = _userTestService.GetUser(UserId);
            Assert.AreEqual(_userMock, receivedUser);
        }
    }
}