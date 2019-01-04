using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DbRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;
using Moq;
using NUnit.Framework;
using System;

namespace CryptoAlert.NUnit.Integration.Authentication
{
    [TestFixture]
    class UserAuthenticatorTests
    {
        private User _user;
        private const String _SAMPLE_EMAIL = "jankowalski@uj.edu.pl";
        private Mock<IDbRepository<User>> _userDbRepositoryMock;
        private Mock<IBCryptWrapper> _bCryptWrapperMock;
        private Mock<IJWTWrapper> _jwtWrapperMock;
        private IParser _parser;

        private UserAuthenticator _sut;

        [SetUp]
        public void SetUp()
        {
            _user = CreateUser();
            _userDbRepositoryMock = new Mock<IDbRepository<User>>();
            _bCryptWrapperMock = new Mock<IBCryptWrapper>();
            _jwtWrapperMock = new Mock<IJWTWrapper>();
            _parser = new JsonParser();

            _userDbRepositoryMock.Setup(x => x.GetByKey<String>("Email", _SAMPLE_EMAIL)).Returns(_user);
            _bCryptWrapperMock.Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            _bCryptWrapperMock.Setup(x => x.Verify("correctpass", _user.HashedPassword)).Returns(true);
            _jwtWrapperMock.Setup(x => x.CreateToken(_SAMPLE_EMAIL)).Returns(new Token("token"));

            _sut = new UserAuthenticator(_userDbRepositoryMock.Object, _parser, _bCryptWrapperMock.Object, _jwtWrapperMock.Object);
        }

        [TestCase(_SAMPLE_EMAIL, "correctpass", ExpectedResult = true)]
        [TestCase(_SAMPLE_EMAIL, "incorrectpass", ExpectedResult = false)]
        public bool TestPasswordVerification(string email, string unhashedPassword)
        {
            // Arrange
            UserLogin userLogin = new UserLogin
            {
                Email = email,
                Password = unhashedPassword,
            };

            // Act
            var result = _sut.VerifyPassword(userLogin);

            // Assert
            return result;
        }

        [TestCase(_SAMPLE_EMAIL, "correctpass", ExpectedResult = "token")]
        [TestCase(_SAMPLE_EMAIL, "incorrectpass", ExpectedResult = null)]
        public string TestUserAuthentication(string email, string unhashedPassword)
        {
            // Arrange
            UserLogin userLogin = new UserLogin
            {
                Email = email,
                Password = unhashedPassword,
            };

            // Act
            var token = _sut.AuthenticateUser(userLogin);
            string result = null;
            if (token != null)
            {
                result = token.Content;
            }

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
