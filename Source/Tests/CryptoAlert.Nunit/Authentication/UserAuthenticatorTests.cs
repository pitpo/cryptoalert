using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;
using Moq;
using NUnit.Framework;
using System;

namespace CryptoAlert.NUnit.Authentication
{
    [TestFixture]
    class UserAuthenticatorTests
    {
        private User _user;
        private const String _SAMPLE_EMAIL = "jankowalski@uj.edu.pl";
        private Mock<IDBRepository<User>> _userDbRepositoryMock;
        private Mock<IBCryptWrapper> _bCryptWrapperMock;
        private Mock<IJWTWrapper> _jwtWrapperMock;
        private IParser _parser;

        private UserAuthenticator _sut;

        [SetUp]
        public void SetUp()
        {
            _user = CreateUser();
            _userDbRepositoryMock = new Mock<IDBRepository<User>>();
            _bCryptWrapperMock = new Mock<IBCryptWrapper>();
            _jwtWrapperMock = new Mock<IJWTWrapper>();
            _parser = new JsonParser();

            _userDbRepositoryMock.Setup(x => x.GetByKey<String>("Email", _SAMPLE_EMAIL)).Returns(_user);
            _bCryptWrapperMock.Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            _bCryptWrapperMock.Setup(x => x.Verify("correctpass", _user.HashedPassword)).Returns(true);
            _jwtWrapperMock.Setup(x => x.CreateToken(_SAMPLE_EMAIL)).Returns("token");

            _sut = new UserAuthenticator(_userDbRepositoryMock.Object, _parser, _bCryptWrapperMock.Object, _jwtWrapperMock.Object);
        }

        [TestCase(_SAMPLE_EMAIL, "correctpass", ExpectedResult = true)]
        [TestCase(_SAMPLE_EMAIL, "incorrectpass", ExpectedResult = false)]
        public bool TestPasswordVerification(string email, string unhashedPassword)
        {
            // Act
            var result = _sut.VerifyPassword(email, unhashedPassword);

            // Assert
            return result;
        }

        [TestCase("{\"Email\": \"" + _SAMPLE_EMAIL + "\", \"Password\": \"correctpass\"}", ExpectedResult = "token")]
        [TestCase("{\"Email\": \"" + _SAMPLE_EMAIL + "\", \"Password\": \"incorrectpass\"}", ExpectedResult = null)]
        public string TestUserAuthentication(string jsonString)
        {
            // Act
            var result = _sut.AuthenticateUser(jsonString);

            // Assert
            return result;
        }

        private User CreateUser()
        {
            User user = new User()
            {
                Email = _SAMPLE_EMAIL,
                HashedPassword = "hashedpass",
                Id = 1,
                Name = "Jan Kowalski"
            };
            return user;
        }
    }
}
