using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlert.NUnit.Authentication
{
    [TestFixture]
    class UserAuthenticatorTests
    {
        private User _user;
        private const String _SAMPLE_EMAIL = "jankowalski@uj.edu.pl";
        private Mock<IDBRepository<User>> _userDbRepositoryMock;
        private Mock<IBCryptWrapper> _bCryptWrapperMock;

        private UserAuthenticator _sut;

        [SetUp]
        public void SetUp()
        {
            _user = CreateUser();
            _userDbRepositoryMock = new Mock<IDBRepository<User>>();
            _bCryptWrapperMock = new Mock<IBCryptWrapper>();

            _userDbRepositoryMock.Setup(x => x.GetByKey<String>("Email", _SAMPLE_EMAIL)).Returns(_user);
            _bCryptWrapperMock.Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            _bCryptWrapperMock.Setup(x => x.Verify("correctpass", _user.HashedPassword)).Returns(true);

            _sut = new UserAuthenticator(_userDbRepositoryMock.Object, _bCryptWrapperMock.Object);
        }

        [TestCase(_SAMPLE_EMAIL, "correctpass", ExpectedResult = true)]
        [TestCase(_SAMPLE_EMAIL, "incorrectpass", ExpectedResult = false)]
        public bool TestPasswordVerification(string email, string unhashedPassword)
        {
            // Act
            var result = _sut.Verify(email, unhashedPassword);

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
