using System;
using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;
using Moq;
using NUnit.Framework;

namespace CryptoAlert.NUnit.Authentication
{
    [TestFixture]
    class UserCreatorTests
    {
        private Mock<IDBRepository<User>> _userDbRepositoryMock;
        private Mock<IBCryptWrapper> _bCryptWrapperMock;
        private IParser _parser;
        private const String _SAMPLE_EMAIL = "jankowalski@uj.edu.pl";
        private User _user;

        private UserCreator _sut;

        [SetUp]
        public void SetUp()
        {
            _parser = new JsonParser();
            _userDbRepositoryMock = new Mock<IDBRepository<User>>();
            _bCryptWrapperMock = new Mock<IBCryptWrapper>();
            _user = new User();

            _userDbRepositoryMock.Setup(x => x.GetByKey<string>("Email", _SAMPLE_EMAIL)).Returns((User)null);
            _userDbRepositoryMock.Setup(x => x.GetByKey<string>("Email", "existing")).Returns(_user);
            _userDbRepositoryMock.Setup(x => x.Insert(It.IsAny<User>())).Returns(true);
            _bCryptWrapperMock.Setup(x => x.HashPassword(It.IsAny<string>())).Returns("hashedPassword");

            _sut = new UserCreator(_parser, _userDbRepositoryMock.Object, _bCryptWrapperMock.Object);
        }

        [Test]
        public void TestNewUserCreation()
        {
            // Arrange
            string jsonString = "{\"Name\": \"Jan Kowalski\", \"Password\": \"password\", \"Email\": \"" + _SAMPLE_EMAIL + "\"}";

            // Act
            bool result = _sut.CreateUser(jsonString);

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestUserCreationWhenEmailIsAlreadyTaken()
        {
            // Arrange
            string jsonString = "{\"Name\": \"Jan Kowalski\", \"Password\": \"password\", \"Email\": \"existing\"}";

            // Act
            bool result = _sut.CreateUser(jsonString);

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
