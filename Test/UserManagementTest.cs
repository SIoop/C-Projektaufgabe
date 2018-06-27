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
    public class UserManagementTest
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
        public void GetUserTest()
        {
            var receivedUser = _userTestService.GetUser(UserId);
            Assert.AreEqual(_userMock, receivedUser);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var expectedList = new List<User> {_userMock};
            var allUsers = _userTestService.GetAllUsers();
            allUsers.ForEach(c => Assert.AreEqual(expectedList[allUsers.IndexOf(c)], c));
        }

        [TestMethod]
        public void AddExistingUserTest()
        {
            var success = _userTestService.AddOrUpdateUser(_userMock);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void AddNewUserTest()
        {
            var testUser = new User
            {
                Firstname = "hans",
                IsAdmin = UserIsAdmin,
                Lastname = "günter",
                Password = "geheim",
                Username = "DerGünter"
            };
            var success = _userTestService.AddOrUpdateUser(testUser);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var success = _userTestService.DeleteUser(_userMock);
            Assert.IsTrue(success);
        }
    }
}