using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.Parsers;
using JWT;
using Moq;
using NUnit.Framework;
using System;

namespace CryptoAlert.NUnit.Authentication
{
    [TestFixture]
    class TokenVerifierTests
    {
        private const String _SAMPLE_EMAIL = "jankowalski@uj.edu.pl";
        private Mock<IJWTWrapper> _jwtWrapperMock;
        private IParser _parser;

        private TokenVerifier _sut;

        [SetUp]
        public void SetUp()
        {
            _jwtWrapperMock = new Mock<IJWTWrapper>();
            _parser = new JsonParser();

            _jwtWrapperMock.Setup(x => x.GetDecodedToken("kowalski")).Returns("{\"usr\": \"" + _SAMPLE_EMAIL + "\"}");
            _jwtWrapperMock.Setup(x => x.GetDecodedToken("tampered")).Throws(new SignatureVerificationException(""));
            _jwtWrapperMock.Setup(x => x.GetDecodedToken("outdated")).Throws(new TokenExpiredException(""));

            _sut = new TokenVerifier(_jwtWrapperMock.Object, _parser);
        }

        [Test]
        public void TestIfCorrectTokenIsVerified()
        {
            // Arrange
            string token = "kowalski";

            // Act
            (bool verified, string status) = _sut.VerifyToken(token);

            // Assert
            Assert.AreEqual(true, verified);
        }

        [Test]
        public void TestIfCorrectTokenHasOwnershipData()
        {
            // Arrange
            string token = "kowalski";

            // Act
            (bool verified, string status) = _sut.VerifyToken(token);

            // Assert
            Assert.AreEqual(_SAMPLE_EMAIL, status);
        }

        [Test]
        public void TestIfTamperedTokenIsHandledProperly()
        {
            // Arrange
            string token = "tampered";

            // Act
            (bool verified, string status) = _sut.VerifyToken(token);

            // Assert
            Assert.AreEqual(false, verified);
            Assert.AreEqual("Token has invalid signature", status);
        }

        [Test]
        public void TestIfOutdatedTokenIsHandledProperly()
        {
            // Arrange
            string token = "outdated";

            // Act
            (bool verified, string status) = _sut.VerifyToken(token);

            // Assert
            Assert.AreEqual(false, verified);
            Assert.AreEqual("Token has expired", status);
        }
    }
}
