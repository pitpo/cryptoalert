using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;
using JWT;
using Moq;
using NUnit.Framework;
using System;

namespace CryptoAlert.NUnit.Integration.Authentication
{
    [TestFixture]
    class TokenVerifierTests
    {
        private const String _SAMPLE_EMAIL = "jankowalski@uj.edu.pl";
        private Mock<IJWTWrapper> _jwtWrapperMock;
        private IParser _parser;
        private Token _goodToken;
        private Token _tamperedToken;
        private Token _outdatedToken;

        private TokenVerifier _sut;

        [SetUp]
        public void SetUp()
        {
            _jwtWrapperMock = new Mock<IJWTWrapper>();
            _parser = new JsonParser();
            _goodToken = new Token("kowalski");
            _tamperedToken = new Token("tampered");
            _outdatedToken = new Token("outdated");

            _jwtWrapperMock.Setup(x => x.GetDecodedToken(_goodToken)).Returns("{\"usr\": \"" + _SAMPLE_EMAIL + "\"}");
            _jwtWrapperMock.Setup(x => x.GetDecodedToken(_tamperedToken)).Throws(new SignatureVerificationException(""));
            _jwtWrapperMock.Setup(x => x.GetDecodedToken(_outdatedToken)).Throws(new TokenExpiredException(""));

            _sut = new TokenVerifier(_jwtWrapperMock.Object, _parser);
        }

        [Test]
        public void TestIfCorrectTokenIsVerified()
        {
            // Arrange
            Token token = _goodToken;

            // Act
            (bool verified, string status) = _sut.VerifyToken(token);

            // Assert
            Assert.AreEqual(true, verified);
        }

        [Test]
        public void TestIfCorrectTokenHasOwnershipData()
        {
            // Arrange
            Token token = _goodToken;

            // Act
            (bool verified, string status) = _sut.VerifyToken(token);

            // Assert
            Assert.AreEqual(_SAMPLE_EMAIL, status);
        }

        [Test]
        public void TestIfTamperedTokenIsHandledProperly()
        {
            // Arrange
            Token token = _tamperedToken;

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
            Token token = _outdatedToken;

            // Act
            (bool verified, string status) = _sut.VerifyToken(token);

            // Assert
            Assert.AreEqual(false, verified);
            Assert.AreEqual("Token has expired", status);
        }
    }
}
