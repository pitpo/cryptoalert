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
        private Mock<IDBRepository<User>> _dbRepositoryMock;
        private Mock<IBCryptWrapper> _bCryptWrapperMock;

        private UserAuthenticator _sut;

        [SetUp]
        public void SetUp()
        {
            _user = CreateUser();
            _dbRepositoryMock = new Mock<IDBRepository<User>>();
            _bCryptWrapperMock = new Mock<IBCryptWrapper>();

            _dbRepositoryMock.Setup(x => x.GetByKey<String>("Email", "jankowalski@uj.edu.pl")).Returns(_user);
            _bCryptWrapperMock.Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            _bCryptWrapperMock.Setup(x => x.Verify("correctpass", _user.HashedPassword)).Returns(true);

            _sut = new UserAuthenticator(_dbRepositoryMock.Object, _bCryptWrapperMock.Object);
        }

        [TestCase("jankowalski@uj.edu.pl", "correctpass", ExpectedResult = true)]
        [TestCase("jankowalski@uj.edu.pl", "incorrectpass", ExpectedResult = false)]
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
                Email = "jankowalksi@uj.edu.pl",
                HashedPassword = "hashedpass",
                Id = 1,
                Name = "Jan Kowalski"
            };
            return user;
        }
    }
}
